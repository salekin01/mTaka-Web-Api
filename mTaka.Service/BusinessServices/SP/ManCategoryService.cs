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
    public interface IManagerCategoryService
    {
        IEnumerable<ManCategory> GetAllManagerCategory();
        ManCategory GetManagerCategoryById(string ManCategoryId);
        ManCategory GetManagerCategoryBy(ManCategory ManCategory);
        int AddManagerCategory(ManCategory _ManCategory);
        int UpdateManagerCategory(ManCategory _ManCategory);
        int DeleteManagerCategory(ManCategory _ManCategory);
        IEnumerable<SelectListItem> GetManagerCategoryForDD();
    }
    public class ManagerCategoryService:IManagerCategoryService
    {
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        private IUnitOfWork _IUoW = null;
        public ManagerCategoryService()
        {
            _IUoW = new UnitOfWork();
        }
        public ManagerCategoryService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region index
        public IEnumerable<ManCategory> GetAllManagerCategory()
        {
            try
            {
                var _ListManCategory = _IUoW.Repository<ManCategory>().Get(x => x.AuthStatusId == "A" &&
                                                                        x.LastAction != "DEL").OrderByDescending(x => x.ManagerCategoryId);
                return _ListManCategory;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllManagerCategory()", string.Empty);
                return null;
                //throw ex;
            }
        }

        public ManCategory GetManagerCategoryBy(ManCategory ManCategory)
        {
            try
            {
                if (ManCategory == null)
                {
                    return ManCategory;
                }
                return _IUoW.Repository<ManCategory>().GetBy(x => x.ManagerCategoryId == ManCategory.ManagerCategoryId &&
                                                                   x.AuthStatusId != "D" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ManCategory GetManagerCategoryById(string ManCategoryId)
        {
            try
            {
                return _IUoW.Repository<ManCategory>().GetById(ManCategoryId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region add
        public int AddManagerCategory(ManCategory _ManCategory)
        {
            try
            {
                var _max = _IUoW.Repository<ManCategory>().GetMaxValue(x => x.ManagerCategoryId) + 1;
                _ManCategory.ManagerCategoryId = _max.ToString().PadLeft(3, '0');
                _ManCategory.AuthStatusId = "U";
                _ManCategory.LastAction = "ADD";
                _ManCategory.MakeDT = System.DateTime.Now;
                _ManCategory.MakeBy = "mtaka";
                var result = _IUoW.Repository<ManCategory>().Add(_ManCategory);

                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    _IAuthLogService.AddAuthLog(_IUoW, null, _ManCategory, "ADD", "0001", _ManCategory.FunctionId, 1, "ManCategory", "MTK_SP_MAN_CATEGORY", "ManCategoryId", _ManCategory.ManagerCategoryId, _ManCategory.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                    //_IAuthLogService.AddAuthLog(_IUoW, null, ListTest, "ADD", "0001", "010101002", 0, "TEST", "ID", null, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddManagerCategory(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region edit
        public int UpdateManagerCategory(ManCategory _ManCategory)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_ManCategory.ManagerCategoryId))
                {
                    IsRecordExist = _IUoW.Repository<ManCategory>().IsRecordExist(x => x.ManagerCategoryId == _ManCategory.ManagerCategoryId);
                    if (IsRecordExist)
                    {
                        var _oldManCategory = _IUoW.Repository<ManCategory>().GetBy(x => x.ManagerCategoryId == _ManCategory.ManagerCategoryId);
                        var _oldManCategoryForLog = ObjectCopier.DeepCopy(_oldManCategory);

                        _oldManCategory.AuthStatusId = _ManCategory.AuthStatusId = "U";
                        _oldManCategory.LastAction = _ManCategory.LastAction = "EDT";
                        _oldManCategory.LastUpdateDT = _ManCategory.LastUpdateDT = System.DateTime.Now;
                        _ManCategory.MakeBy = "mtaka";
                        result = _IUoW.Repository<ManCategory>().Update(_oldManCategory);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldManCategoryForLog, _ManCategory, "EDT", "0001", _ManCategory.FunctionId, 1, "ManCategory", "MTK_SP_MAN_CATEGORY", "ManagerCategoryId", _ManCategory.ManagerCategoryId, _ManCategory.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                            //_IAuthLogService.AddAuthLog(_IUoW, ListTest1, ListTest, "EDT", "0001", "010101002", 0, "TEST", "Id", null, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateManagerCategory(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region delete
        public int DeleteManagerCategory(ManCategory _ManCategory)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_ManCategory.ManagerCategoryId))
                {
                    IsRecordExist = _IUoW.Repository<ManCategory>().IsRecordExist(x => x.ManagerCategoryId == _ManCategory.ManagerCategoryId);
                    if (IsRecordExist)
                    {
                        var _oldManCategory = _IUoW.Repository<ManCategory>().GetBy(x => x.ManagerCategoryId == _ManCategory.ManagerCategoryId);
                        var _oldManCategoryForLog = ObjectCopier.DeepCopy(_oldManCategory);

                        _oldManCategory.AuthStatusId = _ManCategory.AuthStatusId = "U";
                        _oldManCategory.LastAction = _ManCategory.LastAction = "DEL";
                        _oldManCategory.LastUpdateDT = _ManCategory.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<ManCategory>().Update(_oldManCategory);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldManCategoryForLog, _ManCategory, "DEL", "0001", _ManCategory.FunctionId, 1, "ManCategory", "MTK_SP_MAN_CATEGORY", "ManagerCategoryId", _ManCategory.ManagerCategoryId, _ManCategory.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                    //result = _IUoW.Repository<ManCategory>().Delete(_ManCategory);
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteManagerCategory(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Dropdown
        public IEnumerable<SelectListItem> GetManagerCategoryForDD()
        {
            try
            {
                var List_Man_Group = _IUoW.Repository<ManCategory>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.ManagerCategoryId, n.ManagerCategoryNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Man_Group)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.ManagerCategoryId,
                        Text = element.ManagerCategoryNm
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
