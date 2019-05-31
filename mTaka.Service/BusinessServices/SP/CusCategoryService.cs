using mTaka.Data;
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
    public interface ICusCategoryService
    {
        IEnumerable<CusCategory> GetAllCusCategory();
        CusCategory GetCusCategoryById(string _CusCategoryId);
        CusCategory GetCusCategoryBy(string _CusCategoryId);
        int AddCusCategory(CusCategory _CusCategory);
        int UpdateCusCategory(CusCategory _CusCategory);
        int DeleteCusCategory(CusCategory _CusCategory);
        IEnumerable<SelectListItem> GetCusCategoryForDD();
    }

    public class CusCategoryService : ICusCategoryService
    {
        private IUnitOfWork _IUoW = null;
        ErrorLogService _ObjErrorLogService = null;
        private AuthLogService _IAuthLogService;

        public CusCategoryService()
        {
            _IUoW = new UnitOfWork();
        }
        public CusCategoryService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Fetch
        public IEnumerable<CusCategory> GetAllCusCategory()
        {
            try
            {
                return _IUoW.Repository<CusCategory>().Get(x => x.AuthStatusId == "A" &&
                                                                x.LastAction != "DEL").OrderByDescending(x => x.CusCategoryId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllCusCategory()", string.Empty);
                return null;
            }
        }
        public CusCategory GetCusCategoryById(string _CusCategoryId)
        {
            try
            {
                return _IUoW.Repository<CusCategory>().GetById(_CusCategoryId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCusCusCategoryById(string)", string.Empty);
                return null;
            }
        }
        public CusCategory GetCusCategoryBy(string _CusCategoryId)
        {
            try
            {
                return _IUoW.Repository<CusCategory>().GetBy(x => x.CusCategoryId == _CusCategoryId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCusCategoryBy(string)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddCusCategory(CusCategory _CusCategory)
        {
            try
            {
                var _max = _IUoW.Repository<CusCategory>().GetMaxValue(x => x.CusCategoryId) + 1;
                _CusCategory.CusCategoryId = _max.ToString().PadLeft(2, '0');
                _CusCategory.AuthStatusId = "U";
                _CusCategory.LastAction = "ADD";
                _CusCategory.MakeDT = System.DateTime.Now;
                _CusCategory.MakeBy = "mtaka";
                var result = _IUoW.Repository<CusCategory>().Add(_CusCategory);

                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _CusCategory, "ADD", "0001", _CusCategory.FunctionId, 1, "CusCategory", "MTK_SP_CUS_CATEGORY", "CusCategoryId", _CusCategory.CusCategoryId, _CusCategory.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                }
                #endregion

                if (result == 1)
                {
                    _IUoW.Commit();
                }

                _IUoW.Commit();
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddCusCategory(obj)", string.Empty);
                return 0; ;
            }
        }
        #endregion

        #region Edit
        public int UpdateCusCategory(CusCategory _CusCategory)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_CusCategory.CusCategoryId))
                {
                    IsRecordExist = _IUoW.Repository<CusCategory>().IsRecordExist(x => x.CusCategoryId == _CusCategory.CusCategoryId);
                    if (IsRecordExist)
                    {
                        var _oldCusCategory = _IUoW.Repository<CusCategory>().GetBy(x => x.CusCategoryId == _CusCategory.CusCategoryId);
                        var _oldCusCategoryForLog = ObjectCopier.DeepCopy(_oldCusCategory);

                        _oldCusCategory.AuthStatusId = _CusCategory.AuthStatusId = "U";
                        _oldCusCategory.LastAction = _CusCategory.LastAction = "EDT";
                        _oldCusCategory.LastUpdateDT = _CusCategory.LastUpdateDT = System.DateTime.Now;
                        _oldCusCategory.MakeBy = "mtaka";
                        result = _IUoW.Repository<CusCategory>().Update(_oldCusCategory);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldCusCategoryForLog, _CusCategory, "EDT", "0001", _CusCategory.FunctionId, 1, "CusCategory", "MTK_SP_CUS_CATEGORY", "CusCategoryId", _CusCategory.CusCategoryId, _CusCategory.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateCusCategory(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteCusCategory(CusCategory _CusCategory)
        {
            try
            {
                int result = 0;
                if (!string.IsNullOrWhiteSpace(_CusCategory.CusCategoryId))
                {
                    var _oldCusCategory = _IUoW.Repository<CusCategory>().GetBy(x => x.CusCategoryId == _CusCategory.CusCategoryId);
                    var _oldCusCategoryForLog = ObjectCopier.DeepCopy(_oldCusCategory);

                    _oldCusCategory.AuthStatusId = _CusCategory.AuthStatusId = "U";
                    _oldCusCategory.LastAction = _CusCategory.LastAction = "DEL";
                    _oldCusCategory.LastUpdateDT = _CusCategory.LastUpdateDT = System.DateTime.Now;
                    result = _IUoW.Repository<CusCategory>().Update(_oldCusCategory);

                    #region Auth Log
                    if (result == 1)
                    {
                        _IAuthLogService = new AuthLogService();
                        long _outMaxSlAuthLogDtl = 0;
                        result = _IAuthLogService.AddAuthLog(_IUoW, _oldCusCategoryForLog, _CusCategory, "DEL", "0001", _CusCategory.FunctionId, 1, "CusCategory", "MTK_SP_CUS_CATEGORY", "CusCategoryId", _CusCategory.CusCategoryId, _CusCategory.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteCusCategory(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region DropDown
        public IEnumerable<SelectListItem> GetCusCategoryForDD()
        {
            try
            {
                var List_Cus_Group = _IUoW.Repository<CusCategory>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.CusCategoryId, n.CusCategoryNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Cus_Group)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.CusCategoryId,
                        Text = element.CusCategoryNm
                    });
                }
                if (selectList != null)
                    return selectList;
                else
                    return null;
                //throw new Exception("Invalid");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCusCategoryForDD()", string.Empty);
                return null;
            }
        }
        #endregion

        //public long GetMaxValue()
        //{
        //    try
        //    { 
        //        //var _max = _IUoW.Repository<CusCategory>().GetMaxValue1<string>(x => x.CusGroupId);
        //        //System.Reflection.PropertyInfo p = typeof(CusCategory).GetProperty("CusGroupId");
        //        //Type Ttype = p.PropertyType;
        //        var _max = _IUoW.Repository<CusCategory>().GetMaxValue(x => x.CusGroupId);
        //        return _max;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}