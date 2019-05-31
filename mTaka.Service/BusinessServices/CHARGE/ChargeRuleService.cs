using mTaka.Data.BusinessEntities.Charge;
using mTaka.Data.BusinessEntities.Charge.ViewModel;
using mTaka.Data.Common;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.Charge
{
    public interface IChargeRuleService
    {
        IEnumerable<ChargeRuleViewModel> GetAllChargeRules();
        ChargeRule GetChargeRuleById(string _ChargeRuleId);
        ChargeRule GetChargeRuleBy(ChargeRule _ChargeRule);
        int AddChargeRule(ChargeRule _ChargeRule);
        int UpdateChargeRule(ChargeRule _ChargeRule);
        int DeleteChargeRule(ChargeRule _ChargeRule);
        IEnumerable<SelectListItem> GetChargeRuleForDD();
    }

    public class ChargeRuleService : IChargeRuleService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public ChargeRuleService()
        {
            _IUoW = new UnitOfWork();
        }
        public ChargeRuleService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public IEnumerable<ChargeRuleViewModel> GetAllChargeRules()
        {
            try
            {
                //var AllChargeRule = _IUoW.Repository<ChargeRule>().Get(x => x.AuthStatusId == "A" &&
                //                                               x.LastAction != "DEL").OrderByDescending(x => x.ChargeRuleId);
                var AllChargeRule = _IUoW.mTakaDbQuery().ChargeRules();
                return AllChargeRule;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllChargeRule()", string.Empty);
                return null;
            }
        }

        public ChargeRule GetChargeRuleById(string _ChargeRuleId)
        {
            try
            {
                return _IUoW.Repository<ChargeRule>().GetById(_ChargeRuleId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ChargeRule GetChargeRuleBy(ChargeRule _ChargeRule)
        {
            try
            {
                if (_ChargeRule == null)
                {
                    return _ChargeRule;
                }
                return _IUoW.Repository<ChargeRule>().GetBy(x => x.ChargeRuleId == _ChargeRule.ChargeRuleId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add
        public int AddChargeRule(ChargeRule _ChargeRule)
        {
            try
            {
                var _max = _IUoW.Repository<ChargeRule>().GetMaxValue(x => x.ChargeRuleId) + 1;
                _ChargeRule.ChargeRuleId = _max.ToString().PadLeft(4, '0');
                _ChargeRule.PointTimeBalFlag = "0";
                _ChargeRule.InsuffBalRefId = "1";
                _ChargeRule.DeductPrdId = "Y";
                _ChargeRule.DeductCondtionFlag = "0";
                //_ChargeRule.CustomerFilterAppFlag = "0";
                _ChargeRule.StaffAccExcFlag = "0";
                _ChargeRule.ChargeAppConFlag = "0";
                _ChargeRule.TaxPenaltyRate = 0;
                _ChargeRule.AuthStatusId = "U";
                _ChargeRule.LastAction = "ADD";
                _ChargeRule.MakeDT = System.DateTime.Now;
                var result = _IUoW.Repository<ChargeRule>().Add(_ChargeRule);

                List<ChargeDeductCust> ListChargeDeductCust = new List<ChargeDeductCust>();
                var _maxCus = _IUoW.Repository<ChargeDeductCust>().GetMaxValue(x => x.SL) + 1;
                for (int i = 0; i < _ChargeRule.ListChargeDeductCust.Length; i++)
                {
                    ChargeDeductCust _ObjChargeDeductCust = new ChargeDeductCust();
                    
                    _ObjChargeDeductCust.SL = _maxCus.ToString().PadLeft(6, '0');
                    _ObjChargeDeductCust.ChargeRuleId = _ChargeRule.ChargeRuleId;
                    _ObjChargeDeductCust.CusCatId = _ChargeRule.ListChargeDeductCust[i].CusCatId;
                    _ObjChargeDeductCust.AuthStatusId = "U";
                    _ObjChargeDeductCust.LastAction = "ADD";
                    _ObjChargeDeductCust.MakeBy = "mTaka";
                    _ObjChargeDeductCust.MakeDT = System.DateTime.Now;
                    ListChargeDeductCust.Add(_ObjChargeDeductCust);
                    _maxCus += 1;
                }
                result = _IUoW.Repository<ChargeDeductCust>().AddRange(ListChargeDeductCust);

                List<ChargeApplyDateTime> ListChargeApplyDateTime = new List<ChargeApplyDateTime>();
                var _maxDT = _IUoW.Repository<ChargeApplyDateTime>().GetMaxValue(x => x.SL) + 1;
                for (int i = 0; i < _ChargeRule.ListChargeApplyDT.Length; i++)
                {
                    ChargeApplyDateTime _ObjChargeApplyDateTime = new ChargeApplyDateTime();

                    _ObjChargeApplyDateTime.SL = _maxDT.ToString().PadLeft(6, '0');
                    _ObjChargeApplyDateTime.ChargeRuleId = _ChargeRule.ChargeRuleId;
                    _ObjChargeApplyDateTime.Saturday = _ChargeRule.ListChargeApplyDT[i].Saturday == "True" ? "1" : "0"; 
                    _ObjChargeApplyDateTime.Sunday = _ChargeRule.ListChargeApplyDT[i].Sunday == "True" ? "1" : "0";
                    _ObjChargeApplyDateTime.Monday = _ChargeRule.ListChargeApplyDT[i].Monday == "True" ? "1" : "0";
                    _ObjChargeApplyDateTime.Tuesday = _ChargeRule.ListChargeApplyDT[i].Tuesday == "True" ? "1" : "0";
                    _ObjChargeApplyDateTime.Wednesday = _ChargeRule.ListChargeApplyDT[i].Wednesday == "True" ? "1" : "0";
                    _ObjChargeApplyDateTime.Thursday = _ChargeRule.ListChargeApplyDT[i].Thursday == "True" ? "1" : "0";
                    _ObjChargeApplyDateTime.Friday = _ChargeRule.ListChargeApplyDT[i].Friday == "True" ? "1" : "0";
                    _ObjChargeApplyDateTime.FromHour = _ChargeRule.ListChargeApplyDT[i].FromHour.Split(':')[0].ToString();
                    _ObjChargeApplyDateTime.FromMinute = _ChargeRule.ListChargeApplyDT[i].FromHour.Split(':')[1].ToString();
                    _ObjChargeApplyDateTime.ToHour = _ChargeRule.ListChargeApplyDT[i].ToHour.Split(':')[0].ToString();
                    _ObjChargeApplyDateTime.ToMinute = _ChargeRule.ListChargeApplyDT[i].ToHour.Split(':')[1].ToString();
                    _ObjChargeApplyDateTime.AuthStatusId = "U";
                    _ObjChargeApplyDateTime.LastAction = "ADD";
                    _ObjChargeApplyDateTime.MakeBy = "mTaka";
                    _ObjChargeApplyDateTime.MakeDT = System.DateTime.Now;
                    ListChargeApplyDateTime.Add(_ObjChargeApplyDateTime);
                    _maxDT += 1;
                }
                result = _IUoW.Repository<ChargeApplyDateTime>().AddRange(ListChargeApplyDateTime);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _ChargeRule, "ADD", "0001", _ChargeRule.FunctionId, 1, "ChargeRule", "MTK_CHG_RULE", "ChargeRuleId", _ChargeRule.ChargeRuleId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                    if (result == 1 && ListChargeDeductCust != null && ListChargeDeductCust.Count() > 0)
                        result = _IAuthLogService.AddAuthLog(_IUoW, null, ListChargeDeductCust, "ADD", "0001", _ChargeRule.FunctionId, 0, "ChargeDeductCust", "MTK_CHG_DEDUCT_CUST", "SL", null, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                    if (result == 1 && ListChargeApplyDateTime != null && ListChargeApplyDateTime.Count() > 0)
                        result = _IAuthLogService.AddAuthLog(_IUoW, null, ListChargeApplyDateTime, "ADD", "0001", _ChargeRule.FunctionId, 0, "ChargeApplyDateTime", "MTK_CHG_APPLY_DT", "SL", null, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddChargeRule(obj)", string.Empty);
                return 0;
            }
        }
        //public int AddChargeDeductCust(ChargeDeductCust[] _ChargeDeductCust,string id)
        //{
        //    try
        //    {

        //        List<ChargeDeductCust> ListChargeDeductCust = new List<ChargeDeductCust>();

        //        for (int i = 0; i < _ChargeDeductCust.Length; i++)
        //        {
        //            ChargeDeductCust _ObjChargeDeductCust = new ChargeDeductCust();

        //            _ObjChargeDeductCust.ChargeRuleId = id;
        //            _ObjChargeDeductCust.CusCatId = _ChargeDeductCust[i].CusCatId;
        //            _ObjChargeDeductCust.AuthStatusId = "U";
        //            _ObjChargeDeductCust.LastAction = "ADD";
        //            _ObjChargeDeductCust.MakeBy = "mTaka";
        //            _ObjChargeDeductCust.MakeDT = System.DateTime.Now;
        //            ListChargeDeductCust.Add(_ObjChargeDeductCust);
        //        }
        //        var result = _IUoW.Repository<ChargeDeductCust>().AddRange(ListChargeDeductCust);
        //        //#region Auth Log
        //        //if (result == 1)
        //        //{
        //        //    _IAuthLogService = new AuthLogService();
        //        //    long _outMaxSlAuthLogDtl = 0;
        //        //    _IAuthLogService.AddAuthLog(_IUoW, null, AddChargeDeductCust, "ADD", "0001", functionId, 1, "MTK_CHG_RULE", "ChargeRuleId", _ChargeRule.ChargeRuleId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
        //        //}
        //        //#endregion

        //        if (result == 1)
        //        {
        //            _IUoW.Commit();
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        _ObjErrorLogService = new ErrorLogService();
        //        _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddChargeRule(obj)", string.Empty);
        //        return 0;
        //    }
        //}


        #endregion

        #region Edit
        public int UpdateChargeRule(ChargeRule _ChargeRule)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_ChargeRule.ChargeRuleId))
                {
                    IsRecordExist = _IUoW.Repository<ChargeRule>().IsRecordExist(x => x.ChargeRuleId == _ChargeRule.ChargeRuleId);
                    if (IsRecordExist)
                    {
                        var _oldChargeRule = _IUoW.Repository<ChargeRule>().GetBy(x => x.ChargeRuleId == _ChargeRule.ChargeRuleId);
                        var _oldChargeRuleForLog = ObjectCopier.DeepCopy(_oldChargeRule);

                        _oldChargeRule.AuthStatusId = _ChargeRule.AuthStatusId = "U";
                        _oldChargeRule.LastAction = _ChargeRule.LastAction = "EDT";
                        _oldChargeRule.LastUpdateDT = _ChargeRule.LastUpdateDT = System.DateTime.Now;
                        _ChargeRule.MakeBy = "mtaka";
                        result = _IUoW.Repository<ChargeRule>().Update(_oldChargeRule);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldChargeRuleForLog, _ChargeRule, "EDT", "0001", "090102003", 1, "ChargeRule", "MTK_CHG_RULE", "ChargeRuleId", _ChargeRule.ChargeRuleId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateChargeRule(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteChargeRule(ChargeRule _ChargeRule)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_ChargeRule.ChargeRuleId))
                {
                    IsRecordExist = _IUoW.Repository<ChargeRule>().IsRecordExist(x => x.ChargeRuleId == _ChargeRule.ChargeRuleId);
                    if (IsRecordExist)
                    {
                        var _oldChargeRule = _IUoW.Repository<ChargeRule>().GetBy(x => x.ChargeRuleId == _ChargeRule.ChargeRuleId);
                        var _oldChargeRuleForLog = ObjectCopier.DeepCopy(_oldChargeRule);

                        _oldChargeRule.AuthStatusId = _ChargeRule.AuthStatusId = "U";
                        _oldChargeRule.LastAction = _ChargeRule.LastAction = "DEL";
                        _oldChargeRule.LastUpdateDT = _ChargeRule.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<ChargeRule>().Update(_oldChargeRule);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldChargeRuleForLog, _ChargeRule, "DEL", "0001", "090102003", 1, "ChargeRule", "MTK_CHG_RULE", "ChargeRuleId", _ChargeRule.ChargeRuleId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                    //result = _IUoW.Repository<ChargeRule>().Delete(_ChargeRule);
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteChargeRule(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Dropdown
        public IEnumerable<SelectListItem> GetChargeRuleForDD()
        {
            try
            {
                var List_ChargeRule = _IUoW.Repository<ChargeRule>().GetBy(x => x.AuthStatusId == "A" &&
                                                                                x.LastAction != "DEL", n => new { n.ChargeRuleId, n.ChargeRuleName })
                                                                    .OrderBy(x => x.ChargeRuleName);
                var selectList = new List<SelectListItem>();
                foreach (var element in List_ChargeRule)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.ChargeRuleId,
                        Text = element.ChargeRuleName
                    });
                }
                if (selectList != null)
                    return selectList;
                else
                    throw new Exception("Invalid");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
