using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.Common;
using mTaka.Service.OtherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Service.BusinessServices.SP
{
    public interface ITransactionRulesService
    {
        IEnumerable<TransactionRules> GetAllTransactionRules();
        TransactionRules GetAccountRuleById(string _TransactionRules);
        TransactionRules GetAccountRuleBy(TransactionRules _TransactionRules);
        int AddTransactionRules(TransactionRules _TransactionRules);
        int EditTransactionRules(TransactionRules _TransactionRules);
        int DeleteTransactionRules(TransactionRules _TransactionRules);
        int CheckTransactionRules(TransactionRules _TransactionRules);
    }

    public class TransactionRulesService:ITransactionRulesService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;

        public TransactionRulesService()
        {

            _IUoW = new UnitOfWork();
        }

        public TransactionRulesService(IUnitOfWork _IUnitOfWork)
        {

            this._IUoW = _IUnitOfWork;
        }

        #region INDEX

        public IEnumerable<TransactionRules> GetAllTransactionRules()
        {
            try
            {
                //var AllTransactionRules = _IUoW.Repository<TransactionRules>().Get(x => x.AuthStatusId == "A" &&
                //                                               x.LastAction != "DEL").OrderByDescending(x => x.TransactionRuleId);

                var AllTransactionRules = _IUoW.mTakaDbQuery().GetAllTransactionRules_LQ();
                return AllTransactionRules;
            }
            
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllTransactionRules()", string.Empty);
                return null;
            }
        }

        public TransactionRules GetAccountRuleById(string _TransactionRules)
        {
            try
            {
                return _IUoW.Repository<TransactionRules>().GetById(_TransactionRules);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TransactionRules GetAccountRuleBy(TransactionRules _TransactionRules)
        {
            try
            {
                if (_TransactionRules == null)
                {
                    return _TransactionRules;
                }
                return _IUoW.Repository<TransactionRules>().GetBy(x => x.TransactionRuleId == _TransactionRules.TransactionRuleId &&
                                                                   x.AuthStatusId != "D" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ADD
        public int AddTransactionRules(TransactionRules _TransactionRules) 
        {
            try
            {
                var _max = _IUoW.Repository<TransactionRules>().GetMaxValue(x => x.TransactionRuleId) + 1;
                _TransactionRules.TransactionRuleId = _max.ToString().PadLeft(3, '0');
                _TransactionRules.AuthStatusId = "U";
                _TransactionRules.LastAction = "ADD";
                _TransactionRules.MakeBy = "prova";
                _TransactionRules.MakeDT= System.DateTime.Now;

                #region Switch

                if (_TransactionRules.TranactionAllowed == "True")
                {
                    _TransactionRules.TranactionAllowed = "1";
                }
                else
                {
                    _TransactionRules.TranactionAllowed = "0";
                }
                if (_TransactionRules.commissionAllowed == "True")
                {
                    _TransactionRules.commissionAllowed = "1";
                }
                else
                {
                    _TransactionRules.commissionAllowed = "0";
                }
                #endregion

                _TransactionRules.MakeDT = System.DateTime.Now;
                var result = _IUoW.Repository<TransactionRules>().Add(_TransactionRules);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    _IAuthLogService.AddAuthLog(_IUoW, null, _TransactionRules, "ADD", "0001", _TransactionRules.FunctionId, 1, "TransactionRules", "MTK_SP_TRANSACTION_RULES", "TransactionRuleId", _TransactionRules.TransactionRuleId, _TransactionRules.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                }
                #endregion

                if (result == 1)
                {
                    _IUoW.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddTransactionRules(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region EDIT
        public int EditTransactionRules(TransactionRules _TransactionRules)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_TransactionRules.TransactionRuleId))
                {
                    IsRecordExist = _IUoW.Repository<TransactionRules>().IsRecordExist(x => x.TransactionRuleId == _TransactionRules.TransactionRuleId);
                    if (IsRecordExist)
                    {
                        var _OldTransactionRule = _IUoW.Repository<TransactionRules>().GetBy(x => x.TransactionRuleId == _TransactionRules.TransactionRuleId);
                        var _OldTransactionRuleForLog = ObjectCopier.DeepCopy(_OldTransactionRule);

                        _OldTransactionRule.AuthStatusId = "U";
                        _OldTransactionRule.LastAction = "EDT";
                        _OldTransactionRule.LastUpdateDT = System.DateTime.Now;

                        #region Switch
                        
                        if (_TransactionRules.TranactionAllowed == "True")
                        {
                            _TransactionRules.TranactionAllowed = "1";
                        }
                        else
                        {
                            _TransactionRules.TranactionAllowed = "0";
                        }
                        if (_TransactionRules.commissionAllowed == "True")
                        {
                            _TransactionRules.commissionAllowed = "1";
                        }
                        else
                        {
                            _TransactionRules.commissionAllowed = "0";
                        }
                        #endregion

                        result = _IUoW.Repository<TransactionRules>().Update(_OldTransactionRule);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _OldTransactionRuleForLog, _TransactionRules, "EDT", "0001", _TransactionRules.FunctionId, 1, "TransactionRules", "MTK_SP_TRANSACTION_RULES", "TransactionRuleId", _TransactionRules.TransactionRuleId, _TransactionRules.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
            }catch(Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "EditTransactionRules(obj)", string.Empty);
                return 0;
            }

        }
        #endregion

        #region DELETE

        public int DeleteTransactionRules(TransactionRules _TransactionRules)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;

                if (!string.IsNullOrWhiteSpace(_TransactionRules.TransactionRuleId))
                {
                    IsRecordExist = _IUoW.Repository<TransactionRules>().IsRecordExist(x => x.TransactionRuleId == _TransactionRules.TransactionRuleId);
                    if (IsRecordExist)
                    {
                        var _OldTransactionRule = _IUoW.Repository<TransactionRules>().GetBy(x => x.TransactionRuleId == _TransactionRules.TransactionRuleId);
                        var _OldTransactionRuleForLog = ObjectCopier.DeepCopy(_OldTransactionRule);

                        _OldTransactionRule.AuthStatusId = "D";
                        _OldTransactionRule.LastUpdateDT = System.DateTime.Now;
                        _OldTransactionRule.LastAction = "DEL";

                        result = _IUoW.Repository<TransactionRules>().Update(_OldTransactionRule);

                        #region Auth log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _OldTransactionRuleForLog, _TransactionRules, "DEL", "0001", _TransactionRules.FunctionId, 1, "TransactionRules", "MTK_SP_TRANSACTION_RULES", "TransactionRuleId", _TransactionRules.TransactionRuleId, _TransactionRules.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
            catch(Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteTransactionRules(obj)", string.Empty);
                return 0;
            }
        }
        #endregion       

        #region CheckTransactionRules
        public int CheckTransactionRules(TransactionRules _TransactionRules)
        {
            int Check = 0;
            TransactionRules _Transaction_Rules = null;
            try
            {
                var _Acc_Info_From = _IUoW.Repository<AccMaster>().GetBy(x => x.AuthStatusId == "A" && x.LastAction != "DEL" &&
                    x.SystemAccountNo == _TransactionRules.FromSystemAccountNo);
                var _Acc_Info_To = _IUoW.Repository<AccMaster>().GetBy(x => x.AuthStatusId == "A" && x.LastAction != "DEL" &&
                    x.SystemAccountNo == _TransactionRules.ToSystemAccountNo);

                if (_Acc_Info_From != null && _Acc_Info_To != null)
                {
                    if (_TransactionRules.DefineServiceId == "001")
                    {
                        _Transaction_Rules = _IUoW.Repository<TransactionRules>().GetBy(x => x.AuthStatusId == "A" && x.LastAction != "DEL" &&
                            x.AccountType1 == _Acc_Info_From.AccTypeId && x.DefineServiceId == _TransactionRules.DefineServiceId
                            && x.AccountType2 == _Acc_Info_To.AccTypeId);
                    }
                    if (_TransactionRules.DefineServiceId == "002")
                    {
                        _Transaction_Rules = _IUoW.Repository<TransactionRules>().GetBy(x => x.AuthStatusId == "A" && x.LastAction != "DEL" &&
                            x.AccountType1 == _Acc_Info_To.AccTypeId && x.DefineServiceId == _TransactionRules.DefineServiceId
                            && x.AccountType2 == _Acc_Info_From.AccTypeId);
                    }
                    if (_TransactionRules.DefineServiceId == "003")
                    {
                        _Transaction_Rules = _IUoW.Repository<TransactionRules>().GetBy(x => x.AuthStatusId == "A" && x.LastAction != "DEL" &&
                            x.AccountType1 == _Acc_Info_From.AccTypeId && x.DefineServiceId == _TransactionRules.DefineServiceId
                            && x.AccountType2 == _Acc_Info_To.AccTypeId);
                    }
                    if (_TransactionRules.DefineServiceId == "004")
                    {
                        _Transaction_Rules = _IUoW.Repository<TransactionRules>().GetBy(x => x.AuthStatusId == "A" && x.LastAction != "DEL" &&
                            x.AccountType1 == _Acc_Info_To.AccTypeId && x.DefineServiceId == _TransactionRules.DefineServiceId
                            && x.AccountType2 == _Acc_Info_From.AccTypeId);
                    }
                    if (_TransactionRules.DefineServiceId == "011")
                    {
                        _Transaction_Rules = _IUoW.Repository<TransactionRules>().GetBy(x => x.AuthStatusId == "A" && x.LastAction != "DEL" &&
                            x.AccountType1 == _Acc_Info_To.AccTypeId && x.DefineServiceId == _TransactionRules.DefineServiceId
                            && x.AccountType2 == _Acc_Info_From.AccTypeId);
                    }
                    if (_Transaction_Rules != null)
                    {
                        if (_Transaction_Rules.TranactionAllowed == "0")
                        {
                            Check = 0;
                        }
                        if (_Transaction_Rules.TranactionAllowed == "1")
                        {
                            Check = 1;
                        }
                    }                    
                }
                return Check;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "CheckStatusWiseService(obj)", string.Empty);
                return Check;
            }
        }
        #endregion
    }
}
