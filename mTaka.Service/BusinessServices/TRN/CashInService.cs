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
using mTaka.Utility.ISO20022.Camt054;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace mTaka.Service.BusinessServices.TRN
{
    public interface ICashInService
    {
        string AddCashIn(UserTransaction _UserTransaction, out mTaka.Utility.ISO20022.Camt054.Document document);
        //string AddCashIn(CashIn _CashIn);
        Task<string> AddCashIn(UserTransaction _UserTransaction);
        string TotalCashIn();
        IEnumerable<IndPerformanceMonitoringView> DailyCashIn(UserTransaction _UserTransaction);
    }
    public class CashInService : ICashInService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public CashInService()
        {
            _IUoW = new UnitOfWork();
        }
        public CashInService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Add

        /*
        public string AddCashIn(CashIn _CashIn)
        {
            int result = 0;
            _CashIn.TransDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
            string split_result = string.Empty;
            string MainAuthFlag = string.Empty;
            AccMasterService _AccInfoService = new AccMasterService();
            AccMaster _AccInfo_Post = new AccMaster();
            AccMaster _AccInfo_Get = new AccMaster();

            StatusWiseServiceService _StatusWiseServiceService = new StatusWiseServiceService();
            StatusWiseService _StatusWiseService= new StatusWiseService();
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
                _AccInfo_Post.FromSystemAccountNo = _CashIn.FromSystemAccountNo;
                _AccInfo_Post.ToSystemAccountNo = _CashIn.ToSystemAccountNo;
                _AccInfo_Post.FunctionId = _CashIn.FunctionId;
                _AccInfo_Get = _AccInfoService.GetAccInfo(_AccInfo_Post);                
                if (_AccInfo_Get == null || _AccInfo_Get.FromSystemAccountNo == null || _AccInfo_Get.ToSystemAccountNo == null)
                {
                    split_result = result + ":" + "Account No. not valid..";
                    return split_result;
                }
                #endregion

                #region Check StatusWiseService
                _StatusWiseService.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                _StatusWiseService.DefineServiceId = _CashIn.DefineServiceId;
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
                _TransactionRules.DefineServiceId = _CashIn.DefineServiceId;
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
                _AccLimitSetup.DefineServiceId = _CashIn.DefineServiceId;
                _AccLimitSetup.Amount = _CashIn.Amount;
                _AccLimitSetup.TransDT = _CashIn.TransDT;
                CheckAccLimit = _AccLimitSetupService.CheckAccLimit(_AccLimitSetup);
                if (CheckAccLimit != "true")
                {
                    split_result = result + ":" + CheckAccLimit;
                    return split_result;
                }
                #endregion

                if (_AccInfo_Get.FromSystemAccountNo != null && _AccInfo_Get.ToSystemAccountNo != null && CheckStatusWiseService != 0 && CheckTransactionRules != 0 && CheckAccLimit == "true")
                {
                    var _max = _IUoW.Repository<CashIn>().GetMaxValue(x => x.CashInId) + 1;
                    _CashIn.CashInId = _max.ToString().PadLeft(3, '0');
                    _CashIn.AuthStatusId = "U";
                    _CashIn.LastAction = "ADD";
                    _CashIn.MakeDT = System.DateTime.Now;
                    _CashIn.MakeBy = "prova";
                    _CashIn.FromSystemAccountNo = _AccInfo_Get.FromSystemAccountNo;
                    _CashIn.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                    result = _IUoW.Repository<CashIn>().Add(_CashIn);

                    #region Auth Log
                    if (result == 1)
                    {
                        string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetAuthPermissionByFunctionId/" + _CashIn.FunctionId + "/" + _CashIn.FunctionName + "?format=json";
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
                            result = _IAuthLogService.AddAuthLog(_IUoW, null, _CashIn, "ADD", "0001", _CashIn.FunctionId, 1, "CashIn", "MTK_USER_TXN", "CashInId", _CashIn.CashInId, "prova", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        if (MainAuthFlag == "0")
                        {
                            _IAuthLogService = new AuthLogService();
                            FTAuthLog _ObjAuthLog = new FTAuthLog();
                            _ObjAuthLog.TableNm = "MTK_USER_TXN";
                            _ObjAuthLog.AuthStatusId = "A";
                            _ObjAuthLog.LastAction = "ADD";
                            _ObjAuthLog.FunctionId = _CashIn.FunctionId;
                            _ObjAuthLog.TablePkColVal = _CashIn.CashInId;
                            result = _IAuthLogService.SetTableObject_FT<CashIn>(_IUoW, _ObjAuthLog, _CashIn);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddCashIn(obj)", string.Empty);
                split_result = result + ":" + "";
            }
            return split_result;
        }
        */

        public async Task<string> AddCashIn(UserTransaction _UserTransaction)
        {
            string txn_id = string.Empty;
            int count = 0;
            int countTxnId = 0;
            await Task.Run(() =>
            {
                //Parallel.For(0, _UserTransaction.NumberOfCashIn, i =>
                //{
                    using (mTakaDbContext _dbContext = new mTakaDbContext())
                    {
                        //using (_dbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                        //{
                            try
                            {
                                //_dbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted);
                                count++;
                                var param = new OracleParameter("PWALLET_ACC_NO_F", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _UserTransaction.FromSystemAccountNo };
                                var param1 = new OracleParameter("PWALLET_ACC_NO_T", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _UserTransaction.ToSystemAccountNo };
                                var param2 = new OracleParameter("PDEFINE_SERVICE_ID", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _UserTransaction.DefineServiceId };
                                var param3 = new OracleParameter("PAMOUNT", OracleDbType.Decimal, ParameterDirection.Input) { Value = _UserTransaction.Amount };
                                var param4 = new OracleParameter("PFUNCTIONID", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _UserTransaction.FunctionId };
                                var param5 = new OracleParameter("PNARRATION", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _UserTransaction.Narration };
                                var param6 = new OracleParameter("PMAKE_BY", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = _UserTransaction.MakeBy };
                                var param7 = new OracleParameter("PTXN_ID", OracleDbType.NVarchar2, ParameterDirection.Output) { Size = 100 };
                                var param8 = new OracleParameter("pSL", OracleDbType.NVarchar2, ParameterDirection.Input) { Value = count };


                                //var newId = DbContext.Database.SqlQuery<int>("EXEC dbo.MyProc @MyID = {0}", parm).First()

                                string commandText = "BEGIN MTK_TXN.CREATE_TRANS(:PWALLET_ACC_NO_F,:PWALLET_ACC_NO_T,:PDEFINE_SERVICE_ID,:PAMOUNT,:PFUNCTIONID,:PNARRATION,:PMAKE_BY,:PTXN_ID,:pSL); end;";
                                 _dbContext.Database.SqlQuery<string>(commandText, param, param1, param2, param3, param4, param5, param6, param7, param8).ToListAsync();
                                //dbContextTransaction.Commit();
                                txn_id = param7.Value.ToString();
                                if (txn_id != null && txn_id !="")
                                    countTxnId++;
                            }

                            catch (Exception ex)
                            {
                                //dbContextTransaction.Rollback();
                            }
                        //}

                        //Log.Info("Thread Id is-->" + Thread.CurrentThread.ManagedThreadId);
                    }
                //});
            });
            return txn_id+" - "+ count+" -- "+ countTxnId;
        }

        #endregion

        #region Add
        public string AddCashIn(UserTransaction _UserTransaction, out mTaka.Utility.ISO20022.Camt054.Document document)
        {
            document = new Document();
            var grpHdr = document.BkToCstmrDbtCdtNtfctn.GrpHdr;
            grpHdr.MsgId = mTaka.Utility.ISO.ISOHelper.RandomString();
            grpHdr.CreDtTm = DateTime.Now;
            var ntfctn = document.BkToCstmrDbtCdtNtfctn.Ntfctn.FirstOrDefault();
            var ntry = ntfctn?.Ntry.FirstOrDefault();
            if (ntry != null)
            {
                ntry.Amt = new ActiveOrHistoricCurrencyAndAmount(){Ccy = "BDT", Value = _UserTransaction.Amount};
                ntry.CdtDbtInd = CreditDebitCode.DBIT;
                ntry.Sts = new EntryStatus1Choice(){Item = "Other", ItemElementName = ItemChoiceType9.Prtry};

            }

            grpHdr.MsgPgntn.LastPgInd = true;
            grpHdr.MsgPgntn.PgNb = "1";
            int result = 0;
            _UserTransaction.TransDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
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
                _AccInfo_Post.FromSystemAccountNo = _UserTransaction.FromSystemAccountNo;
                _AccInfo_Post.ToSystemAccountNo = _UserTransaction.ToSystemAccountNo;
                _AccInfo_Post.FunctionId = _UserTransaction.FunctionId;
                _AccInfo_Get = _AccInfoService.GetAccInfo(_AccInfo_Post);
                if (_AccInfo_Get == null || _AccInfo_Get.FromSystemAccountNo == null || _AccInfo_Get.ToSystemAccountNo == null)
                {
                    split_result = result + ":" + "Account No. not valid..";
                    grpHdr.AddtlInf = "Account No. not valid..";


                    return split_result;
                }
                #endregion

                #region Check StatusWiseService
                _StatusWiseService.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                _StatusWiseService.DefineServiceId = _UserTransaction.DefineServiceId;
                CheckStatusWiseService = _StatusWiseServiceService.CheckStatusWiseService(_StatusWiseService);
                if (CheckStatusWiseService == 0)
                {
                    split_result = result + ":" + "Account No. is not active for this transaction..";
                    grpHdr.AddtlInf = "Account No. is not active for this transaction..";
                    return split_result;
                }
                #endregion

                #region Check TransactionRules
                _TransactionRules.FromSystemAccountNo = _AccInfo_Get.FromSystemAccountNo;
                _TransactionRules.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                _TransactionRules.DefineServiceId = _UserTransaction.DefineServiceId;
                CheckTransactionRules = _TransactionRulesService.CheckTransactionRules(_TransactionRules);
                if (CheckTransactionRules == 0)
                {
                    split_result = result + ":" + "Transaction is not allowed..";
                    grpHdr.AddtlInf = "Transaction is not allowed..";
                    return split_result;
                }
                #endregion

                #region Check Limit
                _AccLimitSetup.FromSystemAccountNo = _AccInfo_Get.FromSystemAccountNo;
                _AccLimitSetup.FromAccType = _AccInfo_Get.FromAccType;
                _AccLimitSetup.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                _AccLimitSetup.ToAccType = _AccInfo_Get.ToAccType;
                _AccLimitSetup.DefineServiceId = _UserTransaction.DefineServiceId;
                _AccLimitSetup.Amount = _UserTransaction.Amount;
                _AccLimitSetup.TransDT = _UserTransaction.TransDT;
                CheckAccLimit = _AccLimitSetupService.CheckAccLimit(_AccLimitSetup);
                if (CheckAccLimit != "true")
                {
                    split_result = result + ":" + CheckAccLimit;
                    return split_result;
                }
                #endregion

                if (_AccInfo_Get.FromSystemAccountNo != null && _AccInfo_Get.ToSystemAccountNo != null && CheckStatusWiseService != 0 && CheckTransactionRules != 0 && CheckAccLimit == "true")
                {
                    var _max = _IUoW.Repository<UserTransaction>().GetMaxValue(x => x.SerialId) + 1;
                    _UserTransaction.SerialId = _max.ToString().PadLeft(3, '0');
                    _UserTransaction.AuthStatusId = "U";
                    _UserTransaction.LastAction = "ADD";
                    _UserTransaction.MakeDT = System.DateTime.Now;
                    _UserTransaction.MakeBy = "prova";
                    _UserTransaction.FromSystemAccountNo = _AccInfo_Get.FromSystemAccountNo;
                    _UserTransaction.ToSystemAccountNo = _AccInfo_Get.ToSystemAccountNo;
                    result = _IUoW.Repository<UserTransaction>().Add(_UserTransaction);

                    #region Auth Log
                    if (result == 1)
                    {
                        string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetAuthPermissionByFunctionId/" + _UserTransaction.FunctionId + "/" + _UserTransaction.FunctionName + "?format=json";
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
                            result = _IAuthLogService.AddAuthLog(_IUoW, null, _UserTransaction, "ADD", "0001", _UserTransaction.FunctionId, 1, "CashIn", "MTK_USER_TXN", "SerialId", _UserTransaction.SerialId, "prova", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        if (MainAuthFlag == "0")
                        {
                            _IAuthLogService = new AuthLogService();
                            FTAuthLog _ObjAuthLog = new FTAuthLog();
                            _ObjAuthLog.TableNm = "MTK_USER_TXN";
                            _ObjAuthLog.AuthStatusId = "A";
                            _ObjAuthLog.LastAction = "ADD";
                            _ObjAuthLog.FunctionId = _UserTransaction.FunctionId;
                            _ObjAuthLog.TablePkColVal = _UserTransaction.SerialId;
                            result = _IAuthLogService.SetTableObject_FT<UserTransaction>(_IUoW, _ObjAuthLog, _UserTransaction);
                        }
                    }
                    #endregion

                    if (result == 1)
                    {
                        _IUoW.Commit();
                        
                        split_result = result + ":" + "Saved Successfully";
                        grpHdr.AddtlInf = "Saved Successfully";
                    }
                    else
                    {
                        split_result = result + ":" + "information hasn't been added";
                        grpHdr.AddtlInf = "information hasn't been added";
                    }
                }
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddCashIn(obj)", string.Empty);
                split_result = result + ":" + "";
                grpHdr.AddtlInf = "";
            }
            return split_result;
        }
        #endregion

        #region Total CashIn
        public string TotalCashIn()
        {
            try
            {

                var _TotalCashIn = _IUoW.mTakaDbQuery().GetTotalCashIn_LQ();
                return _TotalCashIn;

            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "TotalCashIn()", string.Empty);
                return null;
            }
        }
        #endregion

        #region DailyCashIn
        public IEnumerable<IndPerformanceMonitoringView> DailyCashIn(UserTransaction _UserTransaction)
        {
            try
            {
                var color = "#2E2EFE";
                var walletAccNo = _UserTransaction.WalletAccountNo;
                var date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                if (walletAccNo == null || walletAccNo == "")
                {
                    if (_UserTransaction.FromDate != null && _UserTransaction.ToDate != null)
                    {
                        var FormDate = _UserTransaction.FromDate.Value.Date;
                        var Todate = _UserTransaction.ToDate.Value.Date;

                        var _DailyCashIn = _IUoW.Repository<UserTransaction>().Get(x => x.TransDT >= FormDate
                                                                    && x.TransDT <= Todate).
                                                                    Select(s => new IndPerformanceMonitoringView
                                                                    {
                                                                        amount = s.Amount,
                                                                        time = s.TransDT,
                                                                        color = color
                                                                    }).ToList();

                        return _DailyCashIn;
                    }
                    if (_UserTransaction.Today == true)
                    {
                        var _DailyCashIn = _IUoW.Repository<UserTransaction>().Get(x => x.TransDT == date)
                                                                      .Select(s => new IndPerformanceMonitoringView
                                                                      {
                                                                          amount = s.Amount,
                                                                          time = s.TransDT,
                                                                          color = color
                                                                      }).ToList();

                        return _DailyCashIn;
                    }
                    else
                    {
                        var _DailyCashIn = _IUoW.Repository<UserTransaction>().Get(x => x.AuthStatusId == "A")
                                                                      .Select(s => new IndPerformanceMonitoringView
                                                                      {
                                                                          amount = s.Amount,
                                                                          time = s.TransDT,
                                                                          color = color
                                                                      }).ToList();

                        return _DailyCashIn;
                    }
                }
                else
                {
                    var result = _IUoW.Repository<AccMaster>().Get(a => a.WalletAccountNo == walletAccNo).Select(s => s.SystemAccountNo).ToList();
                    string sysAccNo = result[0];

                    if (_UserTransaction.FromDate != null && _UserTransaction.ToDate != null)
                    {
                        var FormDate = _UserTransaction.FromDate.Value.Date;
                        var Todate = _UserTransaction.ToDate.Value.Date;

                        var _DailyCashIn = _IUoW.Repository<UserTransaction>().Get(x => x.TransDT >= FormDate
                                                                    && x.TransDT <= Todate &&
                                                                    x.FromSystemAccountNo == sysAccNo).
                                                                    Select(s => new IndPerformanceMonitoringView
                                                                    {
                                                                        amount = s.Amount,
                                                                        time = s.TransDT,
                                                                        color = color
                                                                    }).ToList();

                        return _DailyCashIn;
                    }
                    if (_UserTransaction.Today == true)
                    {
                        var _DailyCashIn = _IUoW.Repository<UserTransaction>().Get(x => x.TransDT == date &&
                                                                    x.FromSystemAccountNo == sysAccNo).
                                                                    Select(s => new IndPerformanceMonitoringView
                                                                    {
                                                                        amount = s.Amount,
                                                                        time = s.TransDT,
                                                                        color = color
                                                                    }).ToList();

                        return _DailyCashIn;
                    }
                    else
                    {
                        var _DailyCashIn = _IUoW.Repository<UserTransaction>().Get(x => x.AuthStatusId == "A" &&
                                                                      x.FromSystemAccountNo == sysAccNo)
                                                                      .Select(s => new IndPerformanceMonitoringView
                                                                      {
                                                                          amount = s.Amount,
                                                                          time = s.TransDT,
                                                                          color = color
                                                                      }).ToList();

                        return _DailyCashIn;
                    }
                }
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DailyCashIn()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}

