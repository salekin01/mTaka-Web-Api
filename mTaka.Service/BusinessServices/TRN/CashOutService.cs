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
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.TRN
{
    public interface ICashOutService
    {
        //string AddCashOut(CashOut _CashOut);
        Task<string> AddCashOut(CashOut _CashOut);
        string TotalCashOut();

        IEnumerable<IndPerformanceMonitoringView> DailyCashOut(CashOut _CashOut);
    }
    public class CashOutService : ICashOutService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public CashOutService()
        {
            _IUoW = new UnitOfWork();
        }
        public CashOutService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Add

        /*
        public string AddCashOut(CashOut _CashOut)
        {
            int result = 0;
            _CashOut.TransDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
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
                _AccInfo_Post.FromSystemAccountNo = _CashOut.FromSystemAccountNo;
                _AccInfo_Post.ToSystemAccountNo = _CashOut.ToSystemAccountNo;
                _AccInfo_Post.FunctionId = _CashOut.FunctionId;
                _AccInfo_Get = _AccInfoService.GetAccInfo(_AccInfo_Post);
                if (_AccInfo_Get == null || _AccInfo_Get.FromSystemAccountNo == null || _AccInfo_Get.ToSystemAccountNo == null)
                {
                    split_result = result + ":" + "Account No. not valid..";
                    return split_result;
                }
                #endregion

                #region Check StatusWiseService
                _StatusWiseService.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                _StatusWiseService.DefineServiceId = _CashOut.DefineServiceId;
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
                _TransactionRules.DefineServiceId = _CashOut.DefineServiceId;
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
                _AccLimitSetup.DefineServiceId = _CashOut.DefineServiceId;
                _AccLimitSetup.Amount = _CashOut.Amount;
                _AccLimitSetup.TransDT = _CashOut.TransDT;
                CheckAccLimit = _AccLimitSetupService.CheckAccLimit(_AccLimitSetup);
                if (CheckAccLimit != "true")
                {
                    split_result = result + ":" + CheckAccLimit;
                    return split_result;
                }
                #endregion

                if (_AccInfo_Get.FromSystemAccountNo != null && _AccInfo_Get.ToSystemAccountNo != null && CheckStatusWiseService != 0 && CheckTransactionRules != 0 && CheckAccLimit == "true")
                {
                     var _max = _IUoW.Repository<CashOut>().GetMaxValue(x => x.CashOutId) + 1;
                     _CashOut.CashOutId = _max.ToString().PadLeft(3, '0');
                     _CashOut.AuthStatusId = "U";
                     _CashOut.LastAction = "ADD";
                     _CashOut.MakeDT = System.DateTime.Now;
                     _CashOut.MakeBy = "prova";
                    _CashOut.FromSystemAccountNo = _AccInfo_Get.FromSystemAccountNo;
                    _CashOut.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                    result = _IUoW.Repository<CashOut>().Add(_CashOut);

                     #region Auth Log
                     if (result == 1)
                     {
                         string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetAuthPermissionByFunctionId/" + _CashOut.FunctionId + "/" + _CashOut.FunctionName + "?format=json";
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
                             result = _IAuthLogService.AddAuthLog(_IUoW, null, _CashOut, "ADD", "0001", "090107004", 1, "CashOut", "MTK_TRN_CASH_OUT", "CashOutId", _CashOut.CashOutId, "prova", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                         }
                         if (MainAuthFlag == "0")
                         {
                             _IAuthLogService = new AuthLogService();
                             FTAuthLog _ObjAuthLog = new FTAuthLog();
                             _ObjAuthLog.TableNm = "MTK_TRN_CASH_OUT";
                             _ObjAuthLog.AuthStatusId = "A";
                             _ObjAuthLog.LastAction = "ADD";
                             _ObjAuthLog.FunctionId = _CashOut.FunctionId;
                             _ObjAuthLog.TablePkColVal = _CashOut.CashOutId;                             
                             result = _IAuthLogService.SetTableObject_FT<CashOut>(_IUoW, _ObjAuthLog, _CashOut);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddCashOut(obj)", string.Empty);
                split_result = result + ":" + "";
            }
            return split_result;
            
        }
        */

        public async Task<string> AddCashOut(CashOut _CashOut)
        {
            string txn_id = string.Empty;
            await Task.Run(() =>
            {
                using (mTakaDbContext _dbContext = new mTakaDbContext())
                {
                    using (var dbContextTransaction = _dbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                        try
                        {
                            //_dbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted);

                            var param = new OracleParameter("PWALLET_ACC_NO_F", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _CashOut.FromSystemAccountNo };
                            var param1 = new OracleParameter("PWALLET_ACC_NO_T", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _CashOut.ToSystemAccountNo };
                            var param2 = new OracleParameter("PDEFINE_SERVICE_ID", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _CashOut.DefineServiceId };
                            var param3 = new OracleParameter("PAMOUNT", OracleDbType.Decimal, ParameterDirection.Input) { Value = _CashOut.Amount };
                            var param4 = new OracleParameter("PFUNCTIONID", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _CashOut.FunctionId };
                            var param5 = new OracleParameter("PNARRATION", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _CashOut.Narration };
                            var param6 = new OracleParameter("PMAKE_BY", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _CashOut.MakeBy };
                            var param7 = new OracleParameter("PTXN_ID", OracleDbType.NVarchar2, ParameterDirection.Output) { Size = 100 };

                            //var newId = DbContext.Database.SqlQuery<int>("EXEC dbo.MyProc @MyID = {0}", parm).First()

                            string commandText = "BEGIN MTK_TXN.CREATE_TRANS(:PWALLET_ACC_NO_F,:PWALLET_ACC_NO_T,:PDEFINE_SERVICE_ID,:PAMOUNT,:PFUNCTIONID,:PNARRATION,:PMAKE_BY,:PTXN_ID); end;";
                            _dbContext.Database.SqlQuery<string>(commandText, param, param1, param2, param3, param4, param5, param6, param7).FirstAsync();
                            dbContextTransaction.Commit();
                            txn_id = param7.Value.ToString();
                        }

                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                        }
                    }

                    //Log.Info("Thread Id is-->" + Thread.CurrentThread.ManagedThreadId);
                }
            });
            return txn_id;
        }
        #endregion

        #region Total CashOut
        public string TotalCashOut()
        {
            try
            {

                var _TotalCashOut = _IUoW.mTakaDbQuery().GetTotalCashOut_LQ();
                return _TotalCashOut;

            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "TotalCashOut()", string.Empty);
                return null;
            }
        }
        #endregion

        #region DailyCashOut
        public IEnumerable<IndPerformanceMonitoringView> DailyCashOut(CashOut _CashOut)
        {
            try
            {
                var color = "#2E2EFE";
                var walletAccNo = _CashOut.WalletAccountNo;
                var date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                
                if (walletAccNo==null || walletAccNo == "")
                {
                    if(_CashOut.FormDate != null && _CashOut.ToDate != null)
                    {
                        var FormDate = _CashOut.FormDate.Value.Date;
                        var Todate = _CashOut.ToDate.Value.Date;

                        var _DailyCashOut = _IUoW.Repository<CashOut>().Get(x => x.TransDT >= FormDate
                                                                    && x.TransDT <= Todate).
                                                                    Select(s => new IndPerformanceMonitoringView
                                                                    {   amount = s.Amount,
                                                                        time = s.TransDT,
                                                                        color = color}).ToList();

                        return _DailyCashOut;
                    }
                    if (_CashOut.Today == true)
                    {
                        var _DailyCashOut = _IUoW.Repository<CashOut>().Get(x => x.TransDT == date)
                                                                      .Select(s => new IndPerformanceMonitoringView
                                                                      {
                                                                          amount = s.Amount,
                                                                          time = s.TransDT,
                                                                          color = color
                                                                      }).ToList();

                        return _DailyCashOut;
                    }
                    else
                    {
                        var _DailyCashOut = _IUoW.Repository<CashOut>().Get(x => x.AuthStatusId == "A")
                                                                      .Select(s => new IndPerformanceMonitoringView
                                                                      {
                                                                          amount = s.Amount,
                                                                          time = s.TransDT,
                                                                          color = color
                                                                      }).ToList();

                        return _DailyCashOut;
                    }
                }
                else
                {
                    var result = _IUoW.Repository<AccMaster>().Get(a => a.WalletAccountNo == walletAccNo).Select(s => s.SystemAccountNo).ToList();
                    var sysAccNo = result[0];

                    if (_CashOut.FormDate != null && _CashOut.ToDate != null)
                    {
                        var FormDate = _CashOut.FormDate.Value.Date;
                        var Todate = _CashOut.ToDate.Value.Date;

                        var _DailyCashOut = _IUoW.Repository<CashOut>().Get(x => x.TransDT >= FormDate
                                                                    && x.TransDT <= Todate &&
                                                                    x.FromSystemAccountNo == sysAccNo).
                                                                    Select(s => new IndPerformanceMonitoringView
                                                                    {
                                                                        amount = s.Amount,
                                                                        time = s.TransDT,
                                                                        color = color
                                                                    }).ToList();

                        return _DailyCashOut;
                    }
                    if (_CashOut.Today == true)
                    {
                        var _DailyCashOut = _IUoW.Repository<CashOut>().Get(x => x.TransDT == date &&
                                                                    x.FromSystemAccountNo == sysAccNo).
                                                                    Select(s => new IndPerformanceMonitoringView
                                                                      {
                                                                          amount = s.Amount,
                                                                          time = s.TransDT,
                                                                          color = color
                                                                      }).ToList();

                        return _DailyCashOut;
                    }
                    else
                    {
                        var _DailyCashOut = _IUoW.Repository<CashOut>().Get(x => x.TransDT == date &&
                                                                      x.FromSystemAccountNo == sysAccNo)
                                                                      .Select(s => new IndPerformanceMonitoringView
                                                                      {
                                                                          amount = s.Amount,
                                                                          time = s.TransDT,
                                                                          color = color
                                                                      }).ToList();

                        return _DailyCashOut;
                    }
                }
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DailyCashOut()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}
