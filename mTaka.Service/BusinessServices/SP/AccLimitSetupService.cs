using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.LEDGER;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.BusinessServices.LEDGER;
using mTaka.Service.Common;
using mTaka.Service.OtherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.SP
{
    public interface IAccLimitSetupService
    {
        IEnumerable<AccLimitSetup> GetAllAccLimit();
        AccLimitSetup GetAccLimitById(string _AccLimitId);
        AccLimitSetup GetAccLimitBy(AccLimitSetup _AccLimit);
        int AddAccLimit(AccLimitSetup _AccLimit);
        int UpdateAccLimit(AccLimitSetup _AccLimit);
        int DeleteAccLimit(AccLimitSetup _AccLimit);
        string CheckAccLimit(AccLimitSetup _AccLimit);
    }

    public class AccLimitSetupService:IAccLimitSetupService
    {

        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;

        public AccLimitSetupService()
        {
            _IUoW = new UnitOfWork();
        }
        public AccLimitSetupService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public IEnumerable<AccLimitSetup> GetAllAccLimit()
        {
            try
            {
                var _AccLimit = _IUoW.mTakaDbQuery().AccLimit_LQ();
                return _AccLimit;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllAccLimit()", string.Empty);
                return null;
                //throw ex;
            }
        }

        public AccLimitSetup GetAccLimitById(string _AccLimitId)
        {
            try
            {
                return _IUoW.Repository<AccLimitSetup>().GetById(_AccLimitId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAccLimitById(string)", string.Empty);
                return null;
            }
        }

        public AccLimitSetup GetAccLimitBy(AccLimitSetup _AccLimit)
        {
            try
            {
                if (_AccLimit == null)
                {
                    return _AccLimit;
                }
                return _IUoW.Repository<AccLimitSetup>().GetBy(x => x.AccLimitId == _AccLimit.AccLimitId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAccLimitBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddAccLimit(AccLimitSetup _AccLimit)
        {
            try
            {
                int result = 0;
                var _max = _IUoW.Repository<AccLimitSetup>().GetMaxValue(x => x.AccLimitId) + 1;
                if (_AccLimit.AllAccCategory == "True")
                {
                    var List_Acc_Group = _IUoW.Repository<AccCategory>().GetBy(x => x.AuthStatusId == "A" &&
                                                                                    x.LastAction != "DEL", n => new { n.AccCategoryId, n.AccCategoryNm });

                    List<AccLimitSetup> List_AccLimitSetup = new List<AccLimitSetup>();
                    foreach (var element in List_Acc_Group)
                    {
                        AccLimitSetup _AccLimitTemp = new AccLimitSetup();
                        _AccLimitTemp = ObjectCopier.DeepCopy(_AccLimit);
                        _AccLimitTemp.AccLimitId = (_max++).ToString().PadLeft(3, '0');
                        _AccLimitTemp.AccCategoryId = element.AccCategoryId;
                        _AccLimitTemp.AuthStatusId = "A";
                        _AccLimitTemp.LastAction = "ADD";
                        _AccLimit.MakeBy = "prova";
                        _AccLimitTemp.MakeDT = System.DateTime.Now;
                        _AccLimitTemp.TransDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
                        List_AccLimitSetup.Add(_AccLimitTemp);
                        //result = _IUoW.Repository<AccLimitSetup>().AddRange(List_AccLimitSetup);

                    }
                    result = _IUoW.Repository<AccLimitSetup>().AddRange(List_AccLimitSetup);
                    //if(result == 1)
                    //{
                    //    _IUoW.Commit();
                    //}
                }
                if (_AccLimit.AllAccType == "True")
                {
                    var List_Acc_Type = _IUoW.Repository<AccType>().GetBy(x => x.AuthStatusId == "A" &&
                                                                                    x.LastAction != "DEL", n => new { n.AccTypeId, n.AccTypeNm });

                    List<AccLimitSetup> List_AccLimitSetup = new List<AccLimitSetup>();
                    foreach (var element in List_Acc_Type)
                    {
                        AccLimitSetup _AccLimitTemp = new AccLimitSetup();
                        _AccLimitTemp = ObjectCopier.DeepCopy(_AccLimit);
                        _AccLimitTemp.AccLimitId = (_max++).ToString().PadLeft(3, '0');
                        _AccLimitTemp.AccTypeId = element.AccTypeId;
                        _AccLimitTemp.AuthStatusId = "A";
                        _AccLimitTemp.LastAction = "ADD";
                        _AccLimit.MakeBy = "prova";
                        _AccLimitTemp.MakeDT = System.DateTime.Now;
                        _AccLimitTemp.TransDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
                        List_AccLimitSetup.Add(_AccLimitTemp);
                        //result = _IUoW.Repository<AccLimitSetup>().AddRange(List_AccLimitSetup);

                    }
                    result = _IUoW.Repository<AccLimitSetup>().AddRange(List_AccLimitSetup);
                    //if (result == 1)
                    //{
                    //    _IUoW.Commit();
                    //}
                }
                if (_AccLimit.AllDefineService == "True")
                {
                    var List_DefineService = _IUoW.Repository<DefineService>().GetBy(x => x.AuthStatusId == "A" &&
                                                                                    x.LastAction != "DEL", n => new { n.DefineServiceId, n.DefineServiceNm });

                    List<AccLimitSetup> List_AccLimitSetup = new List<AccLimitSetup>();
                    foreach (var element in List_DefineService)
                    {
                        AccLimitSetup _AccLimitTemp = new AccLimitSetup();
                        _AccLimitTemp = ObjectCopier.DeepCopy(_AccLimit);
                        _AccLimitTemp.AccLimitId = (_max++).ToString().PadLeft(3, '0');
                        _AccLimitTemp.DefineServiceId = element.DefineServiceId;
                        _AccLimitTemp.AuthStatusId = "A";
                        _AccLimitTemp.LastAction = "ADD";
                        _AccLimit.MakeBy = "prova";
                        _AccLimitTemp.MakeDT = System.DateTime.Now;
                        _AccLimitTemp.TransDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
                        List_AccLimitSetup.Add(_AccLimitTemp);
                        //result = _IUoW.Repository<AccLimitSetup>().AddRange(List_AccLimitSetup);

                    }
                    result = _IUoW.Repository<AccLimitSetup>().AddRange(List_AccLimitSetup);
                    //if (result == 1)
                    //{
                    //    _IUoW.Commit();
                    //}
                    //return result;
                }
                if(_AccLimit != null && string.IsNullOrWhiteSpace(_AccLimit.AllAccCategory) && string.IsNullOrWhiteSpace(_AccLimit.AllAccType) && string.IsNullOrWhiteSpace(_AccLimit.AllDefineService))
                {
                    _AccLimit.AccLimitId = _max.ToString().PadLeft(3, '0');
                    _AccLimit.AuthStatusId = "A";
                    _AccLimit.LastAction = "ADD";
                    _AccLimit.MakeBy = "prova";
                    _AccLimit.MakeDT = System.DateTime.Now;
                    _AccLimit.TransDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
                    result = _IUoW.Repository<AccLimitSetup>().Add(_AccLimit);

                    //if (result == 1)
                    //{
                    //    _IUoW.Commit();
                    //}
                    //return result;
                }
                //#region Auth Log
                //if (result == 1)
                //{
                //    _IAuthLogService = new AuthLogService();
                //    long _outMaxSlAuthLogDtl = 0;
                //    result = _IAuthLogService.AddAuthLog(_IUoW, null, _AccLimit, "ADD", "0001", "090102008", 1, "MTK_SP_CUS_TYPE", "AccLimitId", _AccLimit.AccLimitId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                //}
                //#endregion
                if (result == 1)
                {
                    _IUoW.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddAccLimit(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateAccLimit(AccLimitSetup _AccLimit)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_AccLimit.AccLimitId))
                {
                    IsRecordExist = _IUoW.Repository<AccLimitSetup>().IsRecordExist(x => x.AccLimitId == _AccLimit.AccLimitId);
                    if (IsRecordExist)
                    {
                        var _oldAccLimit = _IUoW.Repository<AccLimitSetup>().GetBy(x => x.AccLimitId == _AccLimit.AccLimitId);
                        var _oldAccLimitForLog = ObjectCopier.DeepCopy(_oldAccLimit);

                        _oldAccLimit.AuthStatusId = _AccLimit.AuthStatusId = "U";
                        _oldAccLimit.LastAction = _AccLimit.LastAction = "EDT";
                        _oldAccLimit.LastUpdateDT = _AccLimit.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<AccLimitSetup>().Update(_oldAccLimit);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldAccLimitForLog, _AccLimit, "EDT", "0001", _AccLimit.FunctionId, 1, "AccLimitSetup", "MTK_ACC_LIMIT_SETUP", "AccLimitId", _AccLimit.AccLimitId, _AccLimit.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateAccLimit(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteAccLimit(AccLimitSetup _AccLimit)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_AccLimit.AccLimitId))
                {
                    IsRecordExist = _IUoW.Repository<AccLimitSetup>().IsRecordExist(x => x.AccLimitId == _AccLimit.AccLimitId);
                    if (IsRecordExist)
                    {
                        var _oldAccLimit = _IUoW.Repository<AccLimitSetup>().GetBy(x => x.AccLimitId == _AccLimit.AccLimitId);
                        var _oldAccLimitForLog = ObjectCopier.DeepCopy(_oldAccLimit);

                        _oldAccLimit.AuthStatusId = _AccLimit.AuthStatusId = "U";
                        _oldAccLimit.LastAction = _AccLimit.LastAction = "DEL";
                        _oldAccLimit.LastUpdateDT = _AccLimit.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<AccLimitSetup>().Update(_oldAccLimit);

                        #region Auth Log
                        _IAuthLogService = new AuthLogService();
                        //result = _IAuthLogService.AddAuthLog(_IUoW, _oldAccLimitForLog, _AccLimit, "DEL", "0001", "090102008", 1, "AccLimitSetup", "MFS_ACC_LIMIT", "MFS_ACC_LIMIT", _AccLimit.AccLimitId, "prova");
                        #endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    } 
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteAccLimit(obj)", string.Empty);
                return 0;
            }
        }
        #endregion 

        #region CheckAccLimit
        public string CheckAccLimit(AccLimitSetup _AccLimit)
        {
            AccLimitSetup Acc_Limit_Setup_From = new AccLimitSetup();
            AccLimitSetup Acc_Limit_Setup_To = new AccLimitSetup();
            LedgerMaster _LedgerMaster = new LedgerMaster();
            LedgerService _LedgerService = new LedgerService();
            try
            {
                #region From Account Limit Check                
                var _From_Acc_Limit = _IUoW.Repository<AccLimitSetup>().GetBy(x => x.AuthStatusId == "A" && x.LastAction != "DEL" &&
                    x.DefineServiceId == _AccLimit.DefineServiceId && x.AccTypeId == _AccLimit.FromAccType);
                var _To_Acc_Limit = _IUoW.Repository<AccLimitSetup>().GetBy(x => x.AuthStatusId == "A" && x.LastAction != "DEL" &&
                   x.DefineServiceId == _AccLimit.DefineServiceId && x.AccTypeId == _AccLimit.ToAccType);               
                
                if (_From_Acc_Limit == null)
                {
                    return "no transaction limit has set for this service and from account type";
                }
                if (_To_Acc_Limit == null)
                {
                    return "no transaction limit has set for this service and to account type";
                }

                #region Checking by Ledger BalanceLimit
                //if (_From_Acc_Limit.AllDefineService == "0")
                //{
                //    _LedgerMaster.SystemAccountNo = _AccLimit.FromSystemAccountNo;
                //    _LedgerMaster.Amount = _AccLimit.Amount;
                //    _LedgerMaster.BalanceLimit = _From_Acc_Limit.BalanceLimit;
                //    _LedgerMaster.DefineServiceId = _AccLimit.DefineServiceId;
                //    var msg = _LedgerService.IfAccCrossTheBalanceLimit(_LedgerMaster);

                //    if (msg != "true")
                //    {
                //        return msg;
                //    }
                //}
                #endregion

                //#region Checking by Event
                //else
                //{
                //    var _ListLedgerTxnFrom = (List<LedgerTxn>)_IUoW.Repository<LedgerTxn>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL" &&
                //    x.DefineServiceId == _AccLimit.DefineServiceId && x.FromSystemAccountNo == _AccLimit.FromSystemAccountNo && x.TransectionDate == _AccLimit.TransDT);
                //    var _ListLedgerTxnTo = (List<LedgerTxn>)_IUoW.Repository<LedgerTxn>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL" &&
                //    x.DefineServiceId == _AccLimit.DefineServiceId && x.FromSystemAccountNo == _AccLimit.ToSystemAccountNo && x.TransectionDate == _AccLimit.TransDT);

                //    #region Get Daily Number Of Transaction
                //    Acc_Limit_Setup_From.NoOfOccurrence = (_ListLedgerTxnFrom.Count()).ToString();
                //    Acc_Limit_Setup_To.NoOfOccurrence = (_ListLedgerTxnTo.Count()).ToString();
                //    #endregion

                //    #region Get Daily Transaction Amount
                //    Acc_Limit_Setup_From.AmountOftotalOccurrences = Convert.ToDecimal(_ListLedgerTxnFrom.Select(m => m.PaymentAmount + m.ReceiveAmount).Sum());
                //    Acc_Limit_Setup_To.AmountOftotalOccurrences = Convert.ToDecimal(_ListLedgerTxnTo.Select(m => m.PaymentAmount + m.ReceiveAmount).Sum());
                //    #endregion

                //    #region Checking Transaction Limit For From Account
                //    if (Convert.ToInt32(Acc_Limit_Setup_From.NoOfOccurrence) > Convert.ToInt32(_From_Acc_Limit.NoOfOccurrence))
                //    {
                //        return "from account has crossed daily number of transaction limit! the actual limit is " + _From_Acc_Limit.NoOfOccurrence;
                //    }
                //    if (Acc_Limit_Setup_From.AmountOftotalOccurrences > _From_Acc_Limit.AmountOftotalOccurrences)
                //    {
                //        return "from account has crossed daily total amount of transaction limit! the actual limit is " + _From_Acc_Limit.AmountOftotalOccurrences;
                //    }
                //    if (_AccLimit.Amount > _From_Acc_Limit.AmountOfOccurrence)
                //    {
                //        return "from account has crossed amount of transaction limit! the actual limit is " + _From_Acc_Limit.AmountOfOccurrence;
                //    }
                //    #endregion

                //    #region Checking Transaction Limit For To Account
                //    if (Convert.ToInt32(Acc_Limit_Setup_To.NoOfOccurrence) > Convert.ToInt32(_To_Acc_Limit.NoOfOccurrence))
                //    {
                //        return "to account has crossed daily number of transaction limit! the actual limit is " + _To_Acc_Limit.NoOfOccurrence;
                //    }
                //    if (Acc_Limit_Setup_To.AmountOftotalOccurrences > _To_Acc_Limit.AmountOftotalOccurrences)
                //    {
                //        return "to account has crossed daily total amount of transaction limit! the actual limit is " + _To_Acc_Limit.AmountOftotalOccurrences;
                //    }
                //    if (_AccLimit.Amount > _To_Acc_Limit.AmountOfOccurrence)
                //    {
                //        return "to account has crossed amount of transaction limit! the actual limit is " + _To_Acc_Limit.AmountOfOccurrence;
                //    }
                //    #endregion
                //}
                //#endregion
                #endregion
                return "true";
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "CheckStatusWiseService(obj)", string.Empty);
                return "false";
            }
        }
        #endregion
    }
}
