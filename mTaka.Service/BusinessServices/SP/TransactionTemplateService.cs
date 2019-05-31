using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.BusinessEntities.TRN;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.BusinessServices.CP;
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
    public interface ITransactionTemplateService
    {
        List<TransactionTemplate> GetAllTransactionTemplate();
        TransactionTemplate GetTransactionTemplateById(string _TransactionTemplateId);
        TransactionTemplate GetTransactionTemplateBy(TransactionTemplate _TransactionTemplate);
        int AddTransactionTemplate(TransactionTemplate[] ListTransactionTemplate_API);
        int UpdateTransactionTemplate(TransactionTemplate _TransactionTemplate);
        int DeleteTransactionTemplate(TransactionTemplate _TransactionTemplate);
    }
    public class TransactionTemplateService : ITransactionTemplateService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public TransactionTemplateService()
        {
            _IUoW = new UnitOfWork();
        }
        public TransactionTemplateService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public List<TransactionTemplate> GetAllTransactionTemplate()
        {
            try
            {
                List<TransactionTemplate> OBJ_LIST_TransactionTemplate = new List<TransactionTemplate>();
                var _ListTransactionTemplate = _IUoW.Repository<TransactionTemplate>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.TransactionTemplateId);
                foreach (var item in _ListTransactionTemplate)
                {
                    TransactionTemplate OBJ_TransactionTemplate = new TransactionTemplate();
                    DefineServiceService OBJ_DefineServiceService = new DefineServiceService();
                    AccTypeService OBJ_AccTypeService = new AccTypeService();
                    CommonServiceService OBJ_CommonServiceService = new CommonServiceService();

                    OBJ_TransactionTemplate.TransactionTemplateId = item.TransactionTemplateId;
                    OBJ_TransactionTemplate.DefineServiceId = item.DefineServiceId;
                    foreach (var item1 in OBJ_DefineServiceService.GetDefineServiceForDD())
                    {
                        if (item1.Value == OBJ_TransactionTemplate.DefineServiceId)
                        {
                            OBJ_TransactionTemplate.DefineServiceName = item1.Text;
                        }
                    }
                    OBJ_TransactionTemplate.SourceofAccountId = item.SourceofAccountId;
                    foreach (var item1 in OBJ_CommonServiceService.GetSourceofAccForDD())
                    {
                        if (item1.Value == OBJ_TransactionTemplate.SourceofAccountId)
                        {
                            OBJ_TransactionTemplate.SourceofAccountName = item1.Text;
                        }
                    }
                    OBJ_TransactionTemplate.TypeofAccountId = item.TypeofAccountId;
                    foreach (var item1 in OBJ_CommonServiceService.GetTypeofAccForDD())
                    {
                        if (item1.Value == OBJ_TransactionTemplate.TypeofAccountId)
                        {
                            OBJ_TransactionTemplate.TypeofAccountName = item1.Text;
                        }
                    }
                    OBJ_TransactionTemplate.AccountTypeId = item.AccountTypeId;
                    foreach (var item1 in OBJ_AccTypeService.GetAccTypeForDD())
                    {
                        if (item1.Value == OBJ_TransactionTemplate.AccountTypeId)
                        {
                            OBJ_TransactionTemplate.AccountTypeName = item1.Text;
                        }
                    }
                    OBJ_TransactionTemplate.GLAccSl = item.GLAccSl;
                    OBJ_TransactionTemplate.DebitOrCredit = item.DebitOrCredit;
                    foreach (var item1 in OBJ_CommonServiceService.GetAccBalanceTypeForDD())
                    {
                        if (item1.Value == OBJ_TransactionTemplate.DebitOrCredit)
                        {
                            OBJ_TransactionTemplate.BalanceTypeName = item1.Text;
                        }
                    }
                    OBJ_TransactionTemplate.Narration = item.Narration;
                    //OBJ_TransactionTemplate.ChargeRuleId = item.ChargeRuleId;
                    //foreach (var item1 in OBJ_CommonServiceService.GetChargeRuleForDD())
                    //{
                    //    if (item1.Value == OBJ_TransactionTemplate.ChargeRuleId)
                    //    {
                    //        OBJ_TransactionTemplate.ChargeRuleName = item1.Text;
                    //    }
                    //}
                    OBJ_TransactionTemplate.AuthStatusId = item.AuthStatusId;
                    OBJ_TransactionTemplate.LastAction = item.LastAction;
                    OBJ_TransactionTemplate.LastUpdateDT = item.LastUpdateDT;
                    OBJ_TransactionTemplate.MakeBy = item.MakeBy;
                    OBJ_TransactionTemplate.MakeDT = System.DateTime.Now;
                    OBJ_TransactionTemplate.TransDT = item.TransDT;
                    OBJ_LIST_TransactionTemplate.Add(OBJ_TransactionTemplate);
                }
                return OBJ_LIST_TransactionTemplate;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllTransactionTemplate()", string.Empty);
                return null;
            }
        }

        public TransactionTemplate GetTransactionTemplateById(string _TransactionTemplateId)
        {
            try
            {
                return _IUoW.Repository<TransactionTemplate>().GetById(_TransactionTemplateId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetTransactionTemplateById(string)", string.Empty);
                return null;
            }
        }
        public TransactionTemplate GetTransactionTemplateBy(TransactionTemplate _TransactionTemplate)
        {
            try
            {
                if (_TransactionTemplate == null)
                {
                    return _TransactionTemplate;
                }
                return _IUoW.Repository<TransactionTemplate>().GetBy(x => x.TransactionTemplateId == _TransactionTemplate.TransactionTemplateId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetTransactionTemplateBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddTransactionTemplate(TransactionTemplate[] ListTransactionTemplate_API)
        {
            try
            {
                int result = 0;
                if (ListTransactionTemplate_API != null && ListTransactionTemplate_API.Length > 0)
                {
                    List<TransactionTemplate> List_Obj_TransactionTemplate = new List<TransactionTemplate>();
                    var _max = _IUoW.Repository<TransactionTemplate>().GetMaxValue(x => x.TransactionTemplateId) + 1;
                    for (int i = 0; i < ListTransactionTemplate_API.Length; i++)
                    {
                        TransactionTemplate _Obj_TransactionTemplate = new TransactionTemplate();
                        //_Obj_TransactionTemplate = ObjectCopier.DeepCopy(element);
                        _Obj_TransactionTemplate.TransactionTemplateId = (_max++).ToString().PadLeft(3, '0');
                        _Obj_TransactionTemplate.DefineServiceId = ListTransactionTemplate_API[i].DefineServiceId;
                        _Obj_TransactionTemplate.SourceofAccountId = ListTransactionTemplate_API[i].SourceofAccountId;
                        _Obj_TransactionTemplate.TypeofAccountId = ListTransactionTemplate_API[i].TypeofAccountId;
                        _Obj_TransactionTemplate.AccountTypeId = ListTransactionTemplate_API[i].AccountTypeId;
                        _Obj_TransactionTemplate.DebitOrCredit = ListTransactionTemplate_API[i].DebitOrCredit;
                        _Obj_TransactionTemplate.GLAccSl = ListTransactionTemplate_API[i].GLAccSl;
                        _Obj_TransactionTemplate.Narration = ListTransactionTemplate_API[i].Narration;
                        _Obj_TransactionTemplate.ChargeRuleId = ListTransactionTemplate_API[i].ChargeRuleId;
                        _Obj_TransactionTemplate.AuthStatusId = "U";
                        _Obj_TransactionTemplate.LastAction = "ADD";
                        _Obj_TransactionTemplate.MakeBy = "prova";
                        _Obj_TransactionTemplate.MakeDT = System.DateTime.Now;
                        _Obj_TransactionTemplate.TransDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
                        List_Obj_TransactionTemplate.Add(_Obj_TransactionTemplate);                        
                    }
                    result = _IUoW.Repository<TransactionTemplate>().AddRange(List_Obj_TransactionTemplate);
                    if (result == 1)
                    {
                        _IAuthLogService = new AuthLogService();
                        long _outMaxSlAuthLogDtl = 0;
                        result = _IAuthLogService.AddAuthLog(_IUoW, null, List_Obj_TransactionTemplate, "ADD", "0001", "090102016", 1, "TransactionTemplate", "MTK_SP_TRANSACTION_TEMPLATE", "TransactionTemplateId", null, "prova", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                    }
                    //foreach (var element in List_Obj_TransactionTemplate)
                    //{
                    //    #region Auth Log
                    //    if (result == 1)
                    //    {
                    //        _IAuthLogService = new AuthLogService();
                    //        long _outMaxSlAuthLogDtl = 0;
                    //        result = _IAuthLogService.AddAuthLog(_IUoW, null, element, "ADD", "0001", "090102016", 1, "MTK_SP_TRANSACTION_TEMPLATE", "TransactionTemplateId", element.TransactionTemplateId, "prova", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                    //        if (result == 0) break;
                    //    }
                    //    #endregion
                    //}
                }
                if (result == 1)
                {
                    _IUoW.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddTransactionTemplate(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateTransactionTemplate(TransactionTemplate _TransactionTemplate)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_TransactionTemplate.TransactionTemplateId))
                {
                    IsRecordExist = _IUoW.Repository<TransactionTemplate>().IsRecordExist(x => x.TransactionTemplateId == _TransactionTemplate.TransactionTemplateId);
                    if (IsRecordExist)
                    {
                        var _oldTransactionTemplate = _IUoW.Repository<TransactionTemplate>().GetBy(x => x.TransactionTemplateId == _TransactionTemplate.TransactionTemplateId);
                        var _oldTransactionTemplateForLog = ObjectCopier.DeepCopy(_oldTransactionTemplate);

                        _oldTransactionTemplate.AuthStatusId = _TransactionTemplate.AuthStatusId = "U";
                        _oldTransactionTemplate.LastAction = _TransactionTemplate.LastAction = "EDT";
                        _oldTransactionTemplate.LastUpdateDT = _TransactionTemplate.LastUpdateDT = System.DateTime.Now;
                        _TransactionTemplate.MakeBy = "prova";
                        result = _IUoW.Repository<TransactionTemplate>().Update(_oldTransactionTemplate);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldTransactionTemplateForLog, _TransactionTemplate, "EDT", "0001", _TransactionTemplate.FunctionId, 1, "TransactionTemplate", "MTK_SP_TRANSACTION_TEMPLATE", "TransactionTemplateId", _TransactionTemplate.TransactionTemplateId, _TransactionTemplate.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateTransactionTemplate(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteTransactionTemplate(TransactionTemplate _TransactionTemplate)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_TransactionTemplate.TransactionTemplateId))
                {
                    IsRecordExist = _IUoW.Repository<TransactionTemplate>().IsRecordExist(x => x.TransactionTemplateId == _TransactionTemplate.TransactionTemplateId);
                    if (IsRecordExist)
                    {
                        var _oldTransactionTemplate = _IUoW.Repository<TransactionTemplate>().GetBy(x => x.TransactionTemplateId == _TransactionTemplate.TransactionTemplateId);
                        var _oldTransactionTemplateForLog = ObjectCopier.DeepCopy(_oldTransactionTemplate);

                        _oldTransactionTemplate.AuthStatusId = _TransactionTemplate.AuthStatusId = "U";
                        _oldTransactionTemplate.LastAction = _TransactionTemplate.LastAction = "DEL";
                        _oldTransactionTemplate.LastUpdateDT = _TransactionTemplate.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<TransactionTemplate>().Update(_oldTransactionTemplate);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldTransactionTemplateForLog, _TransactionTemplate, "DEL", "0001", "090102010", 1, "TransactionTemplate", "MTK_SP_TRANSACTION_TEMPLATE", "TransactionTemplateId", _TransactionTemplate.TransactionTemplateId, "prova", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteTransactionTemplate(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        //#region GetGLAccNoByDefineServiceId
        //public TransactionTemplate GetGLAccNoByDefineServiceId(string defineServiceId)
        //{
        //    try
        //    {
        //        var Transaction_Template = _IUoW.Repository<TransactionTemplate>().GetBy(x => (x.DefineServiceId == defineServiceId) &&
        //                                                                               x.AuthStatusId == "A" && x.LastAction != "DEL");
        //        return Transaction_Template;
        //    }
        //    catch (Exception ex)
        //    {
        //        _ObjErrorLogService = new ErrorLogService();
        //        _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetGLAccNoByDefineServiceId(obj)", string.Empty);
        //        throw ex;
        //    }
        //}
        //#endregion

    }
}