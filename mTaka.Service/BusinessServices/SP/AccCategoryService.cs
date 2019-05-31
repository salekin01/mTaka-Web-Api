using mTaka.Data.BusinessEntities;
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
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.SP
{
    public interface IAccCategoryService
    {
        IEnumerable<AccCategory> GetAllAccCategory();
        AccCategory GetAccCategoryById(string _AccCategoryId);
        AccCategory GetAccCategoryBy(AccCategory _AccCategory);
        int AddAccCategory(AccCategory _AccCategory);
        int UpdateAccCategory(AccCategory _AccCategory);
        int DeleteAccCategory(AccCategory _AccCategory);
        IEnumerable<SelectListItem> GetAccCategoryForDD();
    }

    public class AccCategoryService : IAccCategoryService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public AccCategoryService()
        {
            _IUoW = new UnitOfWork();
        }
        public AccCategoryService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public IEnumerable<AccCategory> GetAllAccCategory()
        {
            try
            {
                var AllAccCategory = _IUoW.Repository<AccCategory>().Get(x => x.AuthStatusId == "A" &&
                                                               x.LastAction != "DEL").OrderByDescending(x => x.AccCategoryId);
                return AllAccCategory;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllAccCategory()", string.Empty);
                return null;
            }
        }

        public AccCategory GetAccCategoryById(string _AccCategoryId)
        {
            try
            {
                return _IUoW.Repository<AccCategory>().GetById(_AccCategoryId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public AccCategory GetAccCategoryBy(AccCategory _AccCategory)
        {
            try
            {
                if(_AccCategory == null)
                {
                    return _AccCategory;
                }
                return _IUoW.Repository<AccCategory>().GetBy(x => x.AccCategoryId == _AccCategory.AccCategoryId &&
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
        public int AddAccCategory(AccCategory _AccCategory)
        {
            try
            {
                var _max = _IUoW.Repository<AccCategory>().GetMaxValue(x => x.AccCategoryId) + 1;
                _AccCategory.AccCategoryId = _max.ToString().PadLeft(3, '0');
                _AccCategory.AuthStatusId = "U";
                _AccCategory.LastAction = "ADD";
                _AccCategory.MakeDT = System.DateTime.Now;
                var result = _IUoW.Repository<AccCategory>().Add(_AccCategory);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    _IAuthLogService.AddAuthLog(_IUoW, null, _AccCategory, "ADD", "0001", _AccCategory.FunctionId, 1, "AccCategory", "MTK_SP_ACC_CATEGORY", "AccCategoryId", _AccCategory.AccCategoryId, _AccCategory.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddAccCategory(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateAccCategory(AccCategory _AccCategory)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_AccCategory.AccCategoryId))
                {
                    IsRecordExist = _IUoW.Repository<AccCategory>().IsRecordExist(x => x.AccCategoryId == _AccCategory.AccCategoryId);
                    if (IsRecordExist)
                    {
                        var _oldAccCategory = _IUoW.Repository<AccCategory>().GetBy(x => x.AccCategoryId == _AccCategory.AccCategoryId);
                        var _oldAccCategoryForLog = ObjectCopier.DeepCopy(_oldAccCategory);

                        _oldAccCategory.AuthStatusId = _AccCategory.AuthStatusId = "U";
                        _oldAccCategory.LastAction = _AccCategory.LastAction = "EDT";
                        _oldAccCategory.LastUpdateDT = _AccCategory.LastUpdateDT = System.DateTime.Now;
                        _AccCategory.MakeBy = "mtaka";
                        result = _IUoW.Repository<AccCategory>().Update(_oldAccCategory);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldAccCategoryForLog, _AccCategory, "EDT", "0001", _AccCategory.FunctionId, 1, "AccCategory", "MTK_SP_ACC_CATEGORY", "AccCategoryId", _AccCategory.AccCategoryId, _AccCategory.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateAccCategory(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteAccCategory(AccCategory _AccCategory)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_AccCategory.AccCategoryId))
                {
                    IsRecordExist = _IUoW.Repository<AccCategory>().IsRecordExist(x => x.AccCategoryId == _AccCategory.AccCategoryId);
                    if (IsRecordExist)
                    {
                        var _oldAccCategory = _IUoW.Repository<AccCategory>().GetBy(x => x.AccCategoryId == _AccCategory.AccCategoryId);
                        var _oldAccCategoryForLog = ObjectCopier.DeepCopy(_oldAccCategory);

                        _oldAccCategory.AuthStatusId = _AccCategory.AuthStatusId = "U";
                        _oldAccCategory.LastAction = _AccCategory.LastAction = "DEL";
                        _oldAccCategory.LastUpdateDT = _AccCategory.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<AccCategory>().Update(_oldAccCategory);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldAccCategoryForLog, _AccCategory, "DEL", "0001", _AccCategory.FunctionId, 1, "AccCategory", "MTK_SP_ACC_CATEGORY", "AccCategoryId", _AccCategory.AccCategoryId, _AccCategory.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                    //result = _IUoW.Repository<AccCategory>().Delete(_AccCategory);
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteAccCategory(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Dropdown
        public IEnumerable<SelectListItem> GetAccCategoryForDD()
        {
            try
            {
                var List_Acc_Group = _IUoW.Repository<AccCategory>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.AccCategoryId, n.AccCategoryNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Acc_Group)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.AccCategoryId,
                        Text = element.AccCategoryNm
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
