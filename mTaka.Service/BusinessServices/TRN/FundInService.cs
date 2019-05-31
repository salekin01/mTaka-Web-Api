using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.AUTH;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.BusinessEntities.LEDGER;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.BusinessEntities.TRN;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.ACC;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.BusinessServices.CP;
using mTaka.Service.BusinessServices.LEDGER;
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
    public interface IFundInService
    {
        Task<string> AddFundIn(FundIn _FundIn);
        //List<FundIn> GetAllFundIn();
        //FundIn GetFundInById(string _FundInId);
        //FundIn GetFundInBy(FundIn _FundIn);
        //string AddFundIn(FundIn _FundIn);
        //int UpdateFundIn(FundIn _FundIn);
        //int DeleteFundIn(FundIn _FundIn);

        IEnumerable<IndPerformanceMonitoringView> DailyFundIn(FundIn _FundIn);
    }
    public class FundInService : IFundInService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public FundInService()
        {
            _IUoW = new UnitOfWork();
        }
        public FundInService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        //#region Index
        //public List<FundIn> GetAllFundIn()
        //{
        //    try
        //    {
        //        List<FundIn> OBJ_LIST_FundIn = new List<FundIn>();
        //        foreach (var item in _IUoW.Repository<FundIn>().GetAll())
        //        {
        //            FundIn OBJ_FundIn = new FundIn();
        //            BranchInfoService OBJ_BranchInfoService = new BranchInfoService();

        //            OBJ_FundIn.FundInId = item.FundInId;
        //            OBJ_FundIn.ToAccountNo = item.ToAccountNo;
        //            OBJ_FundIn.ToBranchId = item.ToBranchId;
        //            foreach (var item1 in OBJ_BranchInfoService.GetBranchInfoForDD())
        //            {
        //                if (item1.Value == OBJ_FundIn.ToBranchId)
        //                {
        //                    OBJ_FundIn.ToBranchNm = item1.Text;
        //                }
        //            }
        //            OBJ_FundIn.FromAccountBalance = item.FromAccountBalance;
        //            OBJ_FundIn.Amount = item.Amount;
        //            OBJ_FundIn.Narration = item.Narration;
        //            OBJ_FundIn.FromAccountNo = item.FromAccountNo;
        //            OBJ_FundIn.FromBranchId = item.FromBranchId;
        //            foreach (var item1 in OBJ_BranchInfoService.GetBranchInfoForDD())
        //            {
        //                if (item1.Value == OBJ_FundIn.FromBranchId)
        //                {
        //                    OBJ_FundIn.FromBranchNm = item1.Text;
        //                }
        //            }
        //            OBJ_FundIn.AuthStatusId = item.AuthStatusId;
        //            OBJ_FundIn.LastAction = item.LastAction;
        //            OBJ_FundIn.LastUpdateDT = item.LastUpdateDT;
        //            OBJ_FundIn.MakeBy = item.MakeBy;
        //            OBJ_FundIn.MakeDT = System.DateTime.Now;
        //            OBJ_FundIn.TransDT = item.TransDT;
        //            OBJ_LIST_FundIn.Add(OBJ_FundIn);
        //        }
        //        return OBJ_LIST_FundIn;

        //        //var fundin = _IUoW.Repository<FundIn>().GetBy(x => x.AuthStatusId == "A" &&
        //        //                                                 x.LastAction != "DEL", n => new { n.FundInId, n.ToAccountNo, n.ToBranchId, n.FromAccountBalance, n.Amount, n.Narration, n.FromAccountNo, n.FromBranchId });
        //        //var branch = _IUoW.Repository<BranchInfo>().GetBy(x => x.AuthStatusId == "A" &&
        //        //                                                             x.LastAction != "DEL", n => new { n.BranchId, n.BranchNm });

        //        //List<FundIn> OBJ_LIST_FundIn = fundin
        //        //    .Join(branch, f => f.ToBranchId, b => b.BranchId, (f, b) => new  {f, b})
        //        //    .Join(branch,  f1 => f1.f.FromBranchId, b1 => b1.BranchId, (f1, b1) => new  {f1, b1})
        //        //.Select(m => new FundIn 
        //        //{                
        //        //    FundInId = m.f1.f.FundInId,
        //        //    ToAccountNo = m.f1.f.ToAccountNo,
        //        //    ToBranchId = m.f1.f.ToBranchId,
        //        //    ToBranchNm = m.f1.b.BranchNm,
        //        //    FromAccountBalance = m.f1.f.FromAccountBalance,
        //        //    Amount = m.f1.f.Amount,
        //        //    Narration = m.f1.f.Narration,
        //        //    FromAccountNo = m.f1.f.FromAccountNo,
        //        //    FromBranchId = m.f1.f.FromBranchId,
        //        //    FromBranchNm = m.b1.BranchNm                    
        //        //}).ToList();
        //        //return OBJ_LIST_FundIn;

        //        //List<FundIn> OBJ_LIST_FundIn = branch.GroupJoin(fundin, b => b.BranchId, f => f.FromBranchId, (bb, ff) => new { b = bb, f = ff.SingleOrDefault() }).Select(m => new FundIn 
        //        //{                
        //        //    FundInId = m.f.FundInId,
        //        //    ToAccountNo = m.f.ToAccountNo,
        //        //    ToBranchId = m.f.ToBranchId,
        //        //    ToBranchNm = m.b.BranchNm,
        //        //    FromAccountBalance = m.f.FromAccountBalance,
        //        //    Amount = m.f.Amount,
        //        //    Narration = m.f.Narration,
        //        //    FromAccountNo = m.f.FromAccountNo,
        //        //    FromBranchId = m.f.FromBranchId,
        //        //    FromBranchNm = m.b.BranchNm                    
        //        //}).ToList();
        //        //return OBJ_LIST_FundIn;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public FundIn GetFundInById(string _FundInId)
        //{
        //    try
        //    {
        //        return _IUoW.Repository<FundIn>().GetById(_FundInId);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public FundIn GetFundInBy(FundIn _FundIn)
        //{
        //    try
        //    {
        //        if (_FundIn == null)
        //        {
        //            return _FundIn;
        //        }
        //        return _IUoW.Repository<FundIn>().GetBy(x => x.FundInId == _FundIn.FundInId &&
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
        /*
        public string AddFundIn(FundIn _FundIn)
        {
            int result = 0;
            _FundIn.TransDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
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
                _AccInfo_Post.FromSystemAccountNo = _FundIn.FromSystemAccountNo;
                _AccInfo_Post.ToSystemAccountNo = _FundIn.ToSystemAccountNo;
                _AccInfo_Post.FunctionId = _FundIn.FunctionId;
                _AccInfo_Get = _AccInfoService.GetAccInfo(_AccInfo_Post);
                if (_AccInfo_Get == null || _AccInfo_Get.FromSystemAccountNo == null || _AccInfo_Get.ToSystemAccountNo == null)
                {
                    split_result = result + ":" + "Account No. not valid..";
                    return split_result;
                }
                #endregion

                #region Check StatusWiseService
                _StatusWiseService.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                _StatusWiseService.DefineServiceId = _FundIn.DefineServiceId;
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
                _TransactionRules.DefineServiceId = _FundIn.DefineServiceId;
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
                _AccLimitSetup.DefineServiceId = _FundIn.DefineServiceId;
                _AccLimitSetup.Amount = _FundIn.Amount;
                _AccLimitSetup.TransDT = _FundIn.TransDT;
                CheckAccLimit = _AccLimitSetupService.CheckAccLimit(_AccLimitSetup);
                if (CheckAccLimit != "true")
                {
                    split_result = result + ":" + CheckAccLimit;
                    return split_result;
                }
                #endregion

                if (_AccInfo_Get.FromSystemAccountNo != null && _AccInfo_Get.ToSystemAccountNo != null && CheckStatusWiseService != 0 && CheckTransactionRules != 0 && CheckAccLimit == "true")
                {
                    var _max = _IUoW.Repository<FundIn>().GetMaxValue(x => x.FundInId) + 1;
                    _FundIn.FundInId = _max.ToString().PadLeft(3, '0');
                    _FundIn.AuthStatusId = "U";
                    _FundIn.LastAction = "ADD";
                    //_FundIn.MakeDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
                    _FundIn.MakeDT = System.DateTime.Now;
                    _FundIn.MakeBy = "prova";
                    _FundIn.FromSystemAccountNo = _AccInfo_Get.FromSystemAccountNo;
                    _FundIn.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                    result = _IUoW.Repository<FundIn>().Add(_FundIn);
                    #region Auth Log
                    if (result == 1)
                    {
                        string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetAuthPermissionByFunctionId/" + _FundIn.FunctionId + "/" + _FundIn.FunctionName + "?format=json";
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
                            result = _IAuthLogService.AddAuthLog(_IUoW, null, _FundIn, "ADD", "0001", "090107001", 1, "FundIn", "MTK_TRN_FUND_IN", "FundInId", _FundIn.FundInId, "prova", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        if (MainAuthFlag == "0")
                        {
                            _IAuthLogService = new AuthLogService();
                            FTAuthLog _ObjAuthLog = new FTAuthLog();
                            _ObjAuthLog.TableNm = "MTK_TRN_FUND_IN";
                            _ObjAuthLog.AuthStatusId = "A";
                            _ObjAuthLog.LastAction = "ADD";
                            _ObjAuthLog.FunctionId = _FundIn.FunctionId;
                            _ObjAuthLog.TablePkColVal = _FundIn.FundInId;
                            //_FundIn.FromSystemAccountNo = _AccInfo_Get.FromSystemAccountNo;
                            //_FundIn.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                            result = _IAuthLogService.SetTableObject_FT<FundIn>(_IUoW, _ObjAuthLog, _FundIn);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddFundIn(obj)", string.Empty);
                split_result = result + ":" + "";
            }
            return split_result;
        }
        */
        public async Task<string> AddFundIn(FundIn _FundIn)
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
                            var param = new OracleParameter("PWALLET_ACC_NO_F", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _FundIn.FromSystemAccountNo };
                            var param1 = new OracleParameter("PWALLET_ACC_NO_T", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _FundIn.ToSystemAccountNo };
                            var param2 = new OracleParameter("PDEFINE_SERVICE_ID", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _FundIn.DefineServiceId };
                            var param3 = new OracleParameter("PAMOUNT", OracleDbType.Decimal, ParameterDirection.Input) { Value = _FundIn.Amount };
                            var param4 = new OracleParameter("PFUNCTIONID", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _FundIn.FunctionId };
                            var param5 = new OracleParameter("PNARRATION", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _FundIn.Narration };
                            var param6 = new OracleParameter("PMAKE_BY", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _FundIn.MakeBy };
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
        #endregion

        #region DailyFundIn
        public IEnumerable<IndPerformanceMonitoringView> DailyFundIn(FundIn _FundIn)
        {
            try
            {
                var color = "#2E2EFE";
                var walletAccNo = _FundIn.WalletAccountNo;
                var date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                if (walletAccNo == null || walletAccNo == "")
                {
                    if (_FundIn.FormDate != null && _FundIn.ToDate != null)
                    {
                        var FormDate = _FundIn.FormDate.Value.Date;
                        var Todate = _FundIn.ToDate.Value.Date;

                        var _DailyFundIn = _IUoW.Repository<FundIn>().Get(x => x.TransDT >= FormDate
                                                                    && x.TransDT <= Todate).
                                                                    Select(s => new IndPerformanceMonitoringView
                                                                    {
                                                                        amount = s.Amount,
                                                                        time = s.TransDT,
                                                                        color = color
                                                                    }).ToList();

                        return _DailyFundIn;
                    }
                    if (_FundIn.Today == true)
                    {
                        var _DailyFundIn = _IUoW.Repository<FundIn>().Get(x => x.TransDT == date)
                                                                      .Select(s => new IndPerformanceMonitoringView
                                                                      {
                                                                          amount = s.Amount,
                                                                          time = s.TransDT,
                                                                          color = color
                                                                      }).ToList();

                        return _DailyFundIn;
                    }
                    else
                    {
                        var _DailyFundIn = _IUoW.Repository<FundIn>().Get(x => x.AuthStatusId == "A")
                                                                      .Select(s => new IndPerformanceMonitoringView
                                                                      {
                                                                          amount = s.Amount,
                                                                          time = s.TransDT,
                                                                          color = color
                                                                      }).ToList();

                        return _DailyFundIn;
                    }
                }
                else
                {
                    var result = _IUoW.Repository<AccMaster>().Get(a => a.WalletAccountNo == walletAccNo).Select(s => s.SystemAccountNo).ToList();
                    var sysAccNo = result[0];

                    if (_FundIn.FormDate != null && _FundIn.ToDate != null)
                    {
                        var FormDate = _FundIn.FormDate.Value.Date;
                        var Todate = _FundIn.ToDate.Value.Date;

                        var _DailyFundIn = _IUoW.Repository<FundIn>().Get(x => x.TransDT >= FormDate
                                                                    && x.TransDT <= Todate &&
                                                                    x.FromSystemAccountNo == sysAccNo).
                                                                    Select(s => new IndPerformanceMonitoringView
                                                                    {
                                                                        amount = s.Amount,
                                                                        time = s.TransDT,
                                                                        color = color
                                                                    }).ToList();

                        return _DailyFundIn;
                    }
                    if (_FundIn.Today == true)
                    {
                        var _DailyFundIn = _IUoW.Repository<FundIn>().Get(x => x.TransDT == date &&
                                                                    x.FromSystemAccountNo == sysAccNo).
                                                                    Select(s => new IndPerformanceMonitoringView
                                                                    {
                                                                        amount = s.Amount,
                                                                        time = s.TransDT,
                                                                        color = color
                                                                    }).ToList();

                        return _DailyFundIn;
                    }
                    else
                    {
                        var _DailyFundIn = _IUoW.Repository<FundIn>().Get(x => x.AuthStatusId == "A" &&
                                                                      x.FromSystemAccountNo == sysAccNo)
                                                                      .Select(s => new IndPerformanceMonitoringView
                                                                      {
                                                                          amount = s.Amount,
                                                                          time = s.TransDT,
                                                                          color = color
                                                                      }).ToList();

                        return _DailyFundIn;
                    }
                }
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DailyFundIn()", string.Empty);
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
