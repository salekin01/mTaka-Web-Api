using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.AUTH;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.BusinessEntities.TRN;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.ACC;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.BusinessServices.CP;
using mTaka.Service.BusinessServices.SP;
using mTaka.Service.OtherServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.TRN
{
    public interface IFundTransferService
    {
        string AddFundTransfer(FundTransfer _FundTransfer);
    }
    public class FundTransferService : IFundTransferService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public FundTransferService()
        {
            _IUoW = new UnitOfWork();
        }
        public FundTransferService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Add
        public string AddFundTransfer(FundTransfer _FundTransfer)
        {
            int result = 0;
            _FundTransfer.TransDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
            string split_result = string.Empty;
            string MainAuthFlag = string.Empty;
            AccMasterService _AccInfoService = new AccMasterService();
            AccMaster _AccInfo_Post = new AccMaster();
            AccMaster _AccInfo_Get = new AccMaster();

            StatusWiseServiceService _StatusWiseServiceService = new StatusWiseServiceService();
            StatusWiseService _StatusWiseService = new StatusWiseService();
            int CheckStatusWiseService = 0;

            TransactionRulesService _TransactionRulesService = new TransactionRulesService();
            TransactionRules _TransactionRules = new TransactionRules();
            int CheckTransactionRules = 0;

            AccLimitSetupService _AccLimitSetupService = new AccLimitSetupService();
            AccLimitSetup _AccLimitSetup = new AccLimitSetup();
            string CheckAccLimit = string.Empty;
            try
            {
                #region Get SystemAccountNo by WalletAccountNo
                _AccInfo_Post.FromSystemAccountNo = _FundTransfer.FromSystemAccountNo;
                _AccInfo_Post.ToSystemAccountNo = _FundTransfer.ToSystemAccountNo;
                _AccInfo_Post.FunctionId = _FundTransfer.FunctionId;
                _AccInfo_Get = _AccInfoService.GetAccInfo(_AccInfo_Post);
                if (_AccInfo_Get == null || _AccInfo_Get.FromSystemAccountNo == null || _AccInfo_Get.ToSystemAccountNo == null)
                {
                    split_result = result + ":" + "Account No. not valid..";
                    return split_result;
                }
                #endregion

                #region Check StatusWiseService
                _StatusWiseService.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                _StatusWiseService.DefineServiceId = _FundTransfer.DefineServiceId;
                CheckStatusWiseService = _StatusWiseServiceService.CheckStatusWiseService(_StatusWiseService);
                if (CheckStatusWiseService == 0)
                {
                    split_result = result + ":" + "Account No. is not active for this transaction..";
                    return split_result;
                }
                #endregion

                #region Check TransactionRules
                _TransactionRules.FromSystemAccountNo = _AccInfo_Get.FromSystemAccountNo;
                _TransactionRules.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                _TransactionRules.DefineServiceId = _FundTransfer.DefineServiceId;
                CheckTransactionRules = _TransactionRulesService.CheckTransactionRules(_TransactionRules);
                if (CheckTransactionRules == 0)
                {
                    split_result = result + ":" + "Transaction is not allowed..";
                    return split_result;
                }
                #endregion

                #region Check Limit
                _AccLimitSetup.FromSystemAccountNo = _AccInfo_Get.FromSystemAccountNo;
                _AccLimitSetup.FromAccType = _AccInfo_Get.FromAccType;
                _AccLimitSetup.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                _AccLimitSetup.ToAccType = _AccInfo_Get.ToAccType;
                _AccLimitSetup.DefineServiceId = _FundTransfer.DefineServiceId;
                _AccLimitSetup.Amount = _FundTransfer.Amount;
                _AccLimitSetup.TransDT = _FundTransfer.TransDT;
                CheckAccLimit = _AccLimitSetupService.CheckAccLimit(_AccLimitSetup);
                if (CheckAccLimit != "true")
                {
                    split_result = result + ":" + CheckAccLimit;
                    return split_result;
                }
                #endregion

                if (_AccInfo_Get.FromSystemAccountNo != null && _AccInfo_Get.ToSystemAccountNo != null && CheckStatusWiseService != 0 && CheckTransactionRules != 0 && CheckAccLimit == "true")
                {
                    var _max = _IUoW.Repository<FundTransfer>().GetMaxValue(x => x.FundTransferId) + 1;
                    _FundTransfer.FundTransferId = _max.ToString().PadLeft(9, '0');
                    _FundTransfer.AuthStatusId = "U";
                    _FundTransfer.LastAction = "ADD";
                    _FundTransfer.MakeDT = System.DateTime.Now;
                    _FundTransfer.MakeBy = "prova";
                    _FundTransfer.FromSystemAccountNo = _AccInfo_Get.FromSystemAccountNo;
                    _FundTransfer.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                    result = _IUoW.Repository<FundTransfer>().Add(_FundTransfer);

                    #region Auth Log
                    if (result == 1)
                    {
                        string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetAuthPermissionByFunctionId/" + _FundTransfer.FunctionId + "/" + _FundTransfer.FunctionName + "?format=json";
                        using (WebClient wc = new WebClient())
                        {
                            TransactionRules OBJ_TransactionRules = new TransactionRules();
                            var json = wc.DownloadString(url);
                            OBJ_TransactionRules = JsonConvert.DeserializeObject<TransactionRules>(json);
                            MainAuthFlag = OBJ_TransactionRules.GetAuthPermissionByFunctionIdResult;
                        }
                        if (MainAuthFlag == "1")
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, null, _FundTransfer, "ADD", "0001", _FundTransfer.FunctionId, 1, "FundTransfer", "MTK_TRN_FUND_TRANSFER", "FundTransferId", _FundTransfer.FundTransferId, "prova", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        if (MainAuthFlag == "0")
                        {
                            _IAuthLogService = new AuthLogService();
                            FTAuthLog _ObjAuthLog = new FTAuthLog();
                            _ObjAuthLog.TableNm = "MTK_TRN_FUND_TRANSFER";
                            _ObjAuthLog.AuthStatusId = "A";
                            _ObjAuthLog.LastAction = "ADD";
                            _ObjAuthLog.FunctionId = _FundTransfer.FunctionId;
                            _ObjAuthLog.TablePkColVal = _FundTransfer.FundTransferId;
                            result = _IAuthLogService.SetTableObject_FT<FundTransfer>(_IUoW, _ObjAuthLog, _FundTransfer);
                        }
                    }
                    #endregion

                    if (result == 1)
                    {
                        _IUoW.Commit();
                        split_result = result + ":" + "Saved Successfully";
                    }
                    else
                    {
                        split_result = result + ":" + "information hasn't been added";
                    }
                }
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddFundTransfer(obj)", string.Empty);
                split_result = result + ":" + "";
            }
            return split_result;
        }
        #endregion
    }
}
