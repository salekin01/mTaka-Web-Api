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
    public interface IFundOutService
    {
        Task<string> AddFundOut(FundOut _FundOut);
        //List<FundOut> GetAllFundOut();
        //FundOut GetFundOutById(string _FundOutId);
        //FundOut GetFundOutBy(FundOut _FundOut);
        //string AddFundOut(FundOut _FundOut);
        IEnumerable<IndPerformanceMonitoringView> DailyFundOut(FundOut _FundOut);
        //int UpdateFundOut(FundOut _FundOut);
        //int DeleteFundOut(FundOut _FundOut);
    }
    public class FundOutService : IFundOutService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public FundOutService()
        {
            _IUoW = new UnitOfWork();
        }
        public FundOutService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        //#region Index
        //public List<FundOut> GetAllFundOut()
        //{
        //    try
        //    {
        //        List<FundOut> OBJ_LIST_FundOut = new List<FundOut>();
        //        foreach (var item in _IUoW.Repository<FundOut>().GetAll())
        //        {
        //            FundOut OBJ_FundOut = new FundOut();
        //            BranchInfoService OBJ_BranchInfoService = new BranchInfoService();

        //            OBJ_FundOut.FundOutId = item.FundOutId;
        //            OBJ_FundOut.ToAccountNo = item.ToAccountNo;
        //            OBJ_FundOut.ToBranchId = item.ToBranchId;
        //            foreach (var item1 in OBJ_BranchInfoService.GetBranchInfoForDD())
        //            {
        //                if (item1.Value == OBJ_FundOut.ToBranchId)
        //                {
        //                    OBJ_FundOut.ToBranchNm = item1.Text;
        //                }
        //            }
        //            OBJ_FundOut.ToAccountBalance = item.ToAccountBalance;
        //            OBJ_FundOut.Amount = item.Amount;
        //            OBJ_FundOut.Narration = item.Narration;
        //            OBJ_FundOut.FromAccountNo = item.FromAccountNo;
        //            OBJ_FundOut.FromBranchId = item.FromBranchId;
        //            foreach (var item1 in OBJ_BranchInfoService.GetBranchInfoForDD())
        //            {
        //                if (item1.Value == OBJ_FundOut.FromBranchId)
        //                {
        //                    OBJ_FundOut.FromBranchNm = item1.Text;
        //                }
        //            }
        //            OBJ_FundOut.AuthStatusId = item.AuthStatusId;
        //            OBJ_FundOut.LastAction = item.LastAction;
        //            OBJ_FundOut.LastUpdateDT = item.LastUpdateDT;
        //            OBJ_FundOut.MakeBy = item.MakeBy;
        //            OBJ_FundOut.MakeDT = System.DateTime.Now;
        //            OBJ_FundOut.TransDT = item.TransDT;
        //            OBJ_LIST_FundOut.Add(OBJ_FundOut);
        //        }
        //        return OBJ_LIST_FundOut;

        //        //var fundout = _IUoW.Repository<FundOut>().GetBy(x => x.AuthStatusId == "A" &&
        //        //                                                 x.LastAction != "DEL", n => new { n.FundOutId, n.ToAccountNo, n.ToBranchId, n.ToAccountBalance, n.Amount, n.Narration, n.FromAccountNo, n.FromBranchId });
        //        //var branch = _IUoW.Repository<BranchInfo>().GetBy(x => x.AuthStatusId == "A" &&
        //        //                                                             x.LastAction != "DEL", n => new { n.BranchId, n.BranchNm });

        //        //List<FundOut> OBJ_LIST_FundOut = fundout
        //        //    .Join(branch, f => f.ToBranchId, b => b.BranchId, (f, b) => new { f, b })
        //        //    .Join(branch, f1 => f1.f.FromBranchId, b1 => b1.BranchId, (f1, b1) => new { f1, b1 })
        //        //.Select(m => new FundOut
        //        //{
        //        //    FundOutId = m.f1.f.FundOutId,
        //        //    ToAccountNo = m.f1.f.ToAccountNo,
        //        //    ToBranchId = m.f1.f.ToBranchId,
        //        //    ToBranchNm = m.f1.b.BranchNm,
        //        //    ToAccountBalance = m.f1.f.ToAccountBalance,
        //        //    Amount = m.f1.f.Amount,
        //        //    Narration = m.f1.f.Narration,
        //        //    FromAccountNo = m.f1.f.FromAccountNo,
        //        //    FromBranchId = m.f1.f.FromBranchId,
        //        //    FromBranchNm = m.b1.BranchNm                    
        //        //}).ToList();
        //        //return OBJ_LIST_FundOut;                
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public FundOut GetFundOutById(string _FundOutId)
        //{
        //    try
        //    {
        //        return _IUoW.Repository<FundOut>().GetById(_FundOutId);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public FundOut GetFundOutBy(FundOut _FundOut)
        //{
        //    try
        //    {
        //        if (_FundOut == null)
        //        {
        //            return _FundOut;
        //        }
        //        return _IUoW.Repository<FundOut>().GetBy(x => x.FundOutId == _FundOut.FundOutId &&
        //                                                           x.AuthStatusId == "A" &&
        //                                                           x.LastAction != "DEL");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //#endregion

        #region Add
        public async Task<string> AddFundOut(FundOut _FundOut)
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
                            var param = new OracleParameter("PWALLET_ACC_NO_F", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _FundOut.FromSystemAccountNo };
                            var param1 = new OracleParameter("PWALLET_ACC_NO_T", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _FundOut.ToSystemAccountNo };
                            var param2 = new OracleParameter("PDEFINE_SERVICE_ID", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _FundOut.DefineServiceId };
                            var param3 = new OracleParameter("PAMOUNT", OracleDbType.Decimal, ParameterDirection.Input) { Value = _FundOut.Amount };
                            var param4 = new OracleParameter("PFUNCTIONID", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _FundOut.FunctionId };
                            var param5 = new OracleParameter("PNARRATION", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _FundOut.Narration };
                            var param6 = new OracleParameter("PMAKE_BY", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _FundOut.MakeBy };
                            var param7 = new OracleParameter("PTXN_ID", OracleDbType.NVarchar2, ParameterDirection.Output) { Size = 100 };

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
        /*
                public string AddFundOut(FundOut _FundOut)
                  {
                    int result = 0;
                    _FundOut.TransDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
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
                        _AccInfo_Post.FromSystemAccountNo = _FundOut.FromSystemAccountNo;
                        _AccInfo_Post.ToSystemAccountNo = _FundOut.ToSystemAccountNo;
                        _AccInfo_Post.FunctionId = _FundOut.FunctionId;
                        _AccInfo_Get = _AccInfoService.GetAccInfo(_AccInfo_Post);
                        if (_AccInfo_Get == null || _AccInfo_Get.FromSystemAccountNo == null || _AccInfo_Get.ToSystemAccountNo == null)
                        {
                            split_result = result + ":" + "Account No. not valid..";
                            return split_result;
                        }
                        #endregion

                        #region Check StatusWiseService
                        _StatusWiseService.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                        _StatusWiseService.DefineServiceId = _FundOut.DefineServiceId;
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
                        _TransactionRules.DefineServiceId = _FundOut.DefineServiceId;
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
                        _AccLimitSetup.DefineServiceId = _FundOut.DefineServiceId;
                        _AccLimitSetup.Amount = _FundOut.Amount;
                        _AccLimitSetup.TransDT = _FundOut.TransDT;
                        CheckAccLimit = _AccLimitSetupService.CheckAccLimit(_AccLimitSetup);
                        if (CheckAccLimit != "true")
                        {
                            split_result = result + ":" + CheckAccLimit;
                            return split_result;
                        }
                        #endregion

                        if (_AccInfo_Get.FromSystemAccountNo != null && _AccInfo_Get.ToSystemAccountNo != null && CheckStatusWiseService != 0 && CheckTransactionRules != 0 && CheckAccLimit == "true")
                        {
                            var _max = _IUoW.Repository<FundOut>().GetMaxValue(x => x.FundOutId) + 1;
                            _FundOut.FundOutId = _max.ToString().PadLeft(3, '0');
                            _FundOut.AuthStatusId = "U";
                            _FundOut.LastAction = "ADD";
                            _FundOut.MakeDT = System.DateTime.Now;
                            _FundOut.MakeBy = "prova";
                            _FundOut.FromSystemAccountNo = _AccInfo_Get.FromSystemAccountNo;
                            _FundOut.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                            result = _IUoW.Repository<FundOut>().Add(_FundOut);
                            #region Auth Log
                            if (result == 1)
                            {
                                string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetAuthPermissionByFunctionId/" + _FundOut.FunctionId + "/" + _FundOut.FunctionName + "?format=json";
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
                                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _FundOut, "ADD", "0001", "090107002", 1, "FundOut", "MTK_TRN_FUND_OUT", "FundOutId", _FundOut.FundOutId, "prova", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                                }
                                if (MainAuthFlag == "0")
                                {
                                    _IAuthLogService = new AuthLogService();
                                    FTAuthLog _ObjAuthLog = new FTAuthLog();
                                    _ObjAuthLog.TableNm = "MTK_TRN_FUND_OUT";
                                    _ObjAuthLog.AuthStatusId = "A";
                                    _ObjAuthLog.LastAction = "ADD";
                                    _ObjAuthLog.FunctionId = _FundOut.FunctionId;
                                    _ObjAuthLog.TablePkColVal = _FundOut.FundOutId;                            
                                    result = _IAuthLogService.SetTableObject_FT<FundOut>(_IUoW, _ObjAuthLog, _FundOut);
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
                        _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddFundOut(obj)", string.Empty);
                        split_result = result + ":" + "";                
                    }
                    return split_result;
                }
           */
        #endregion

        #region DailyFundOut
        public IEnumerable<IndPerformanceMonitoringView> DailyFundOut(FundOut _FundOut)
        {
            try
            {
                var color = "#F78181";
                var walletAccNo = _FundOut.WalletAccountNo;
                var date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                if (walletAccNo == null || walletAccNo == "")
                {
                    if (_FundOut.FormDate != null && _FundOut.ToDate != null)
                    {
                        var FormDate = _FundOut.FormDate.Value.Date;
                        var Todate = _FundOut.ToDate.Value.Date;

                        var _DailyFundOut = _IUoW.Repository<FundOut>().Get(x => x.TransDT >= FormDate
                                                                    && x.TransDT <= Todate).
                                                                    Select(s => new IndPerformanceMonitoringView
                                                                    {
                                                                        amount = s.Amount,
                                                                        time = s.TransDT,
                                                                        color = color
                                                                    }).ToList();

                        return _DailyFundOut;
                    }
                    if (_FundOut.Today == true)
                    {
                        var _DailyFundOut = _IUoW.Repository<FundOut>().Get(x => x.TransDT == date)
                                                                      .Select(s => new IndPerformanceMonitoringView
                                                                      {
                                                                          amount = s.Amount,
                                                                          time = s.TransDT,
                                                                          color = color
                                                                      }).ToList();

                        return _DailyFundOut;
                    }
                    else
                    {
                        var _DailyFundOut = _IUoW.Repository<FundOut>().Get(x => x.AuthStatusId == "A")
                                                                      .Select(s => new IndPerformanceMonitoringView
                                                                      {
                                                                          amount = s.Amount,
                                                                          time = s.TransDT,
                                                                          color = color
                                                                      }).ToList();

                        return _DailyFundOut;
                    }
                }
                else
                {
                    var result = _IUoW.Repository<AccMaster>().Get(a => a.WalletAccountNo == walletAccNo).Select(s => s.SystemAccountNo).ToList();
                    var sysAccNo = result[0];

                    if (_FundOut.FormDate != null && _FundOut.ToDate != null)
                    {
                        var FormDate = _FundOut.FormDate.Value.Date;
                        var Todate = _FundOut.ToDate.Value.Date;

                        var _DailyFundOut = _IUoW.Repository<FundOut>().Get(x => x.TransDT >= FormDate
                                                                    && x.TransDT <= Todate &&
                                                                    x.FromSystemAccountNo == sysAccNo).
                                                                    Select(s => new IndPerformanceMonitoringView
                                                                    {
                                                                        amount = s.Amount,
                                                                        time = s.TransDT,
                                                                        color = color
                                                                    }).ToList();

                        return _DailyFundOut;
                    }
                    if (_FundOut.Today == true)
                    {
                        var _DailyFundOut = _IUoW.Repository<FundOut>().Get(x => x.TransDT == date &&
                                                                    x.FromSystemAccountNo == sysAccNo).
                                                                    Select(s => new IndPerformanceMonitoringView
                                                                    {
                                                                        amount = s.Amount,
                                                                        time = s.TransDT,
                                                                        color = color
                                                                    }).ToList();

                        return _DailyFundOut;
                    }
                    else
                    {
                        var _DailyFundOut = _IUoW.Repository<FundOut>().Get(x => x.TransDT == date &&
                                                                      x.FromSystemAccountNo == sysAccNo)
                                                                      .Select(s => new IndPerformanceMonitoringView
                                                                      {
                                                                          amount = s.Amount,
                                                                          time = s.TransDT,
                                                                          color = color
                                                                      }).ToList();

                        return _DailyFundOut;
                    }
                }
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DailyFundOut()", string.Empty);
                return null;
            }
        }

        public IEnumerable<string> GetSysNo(string WNo)
        {
            var result = _IUoW.Repository<AccMaster>().Get(a => a.WalletAccountNo == WNo).Select(s => s.SystemAccountNo).ToList();

            return result;
        }
        #endregion
    }
}