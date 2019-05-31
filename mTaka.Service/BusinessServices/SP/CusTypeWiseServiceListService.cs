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
    public interface ICusTypeWiseServiceListService
    {
        IEnumerable<CusTypeWiseServiceList> GetAllCusTypeWiseServiceList();
        CusTypeWiseServiceList GetCusTypeWiseServiceListById(string _CusTypeWiseServiceId);
        CusTypeWiseServiceList GetCusTypeWiseServiceListBy(CusTypeWiseServiceList _CusTypeWiseServiceListBy);
        int AddCusTypeWiseServiceList(CusTypeWiseServiceList _CusTypeWiseServiceList);
        int UpdateCusTypeWiseServiceList(CusTypeWiseServiceList _CusTypeWiseServiceList);
        int DeleteCusTypeWiseServiceList(CusTypeWiseServiceList _CusTypeWiseServiceList);


        IEnumerable<SelectListItem> AccTypeForCusCategory(string AccCategoryId);
    }
    public class CusTypeWiseServiceListService : ICusTypeWiseServiceListService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public CusTypeWiseServiceListService()
        {
            _IUoW = new UnitOfWork();
        }

        public CusTypeWiseServiceListService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }



        #region Index
        public IEnumerable<CusTypeWiseServiceList> GetAllCusTypeWiseServiceList()
        {

            try
            {
                var CusTypeWiseServiceList = _IUoW.mTakaDbQuery().CusTypeWise_LQ();
                return CusTypeWiseServiceList;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllCusTypeWiseServiceList()", string.Empty);
                return null;
            }
        }

        public CusTypeWiseServiceList GetCusTypeWiseServiceListById(string _CusTypeWiseServiceId)
        {
            try
            {
                return _IUoW.Repository<CusTypeWiseServiceList>().GetById(_CusTypeWiseServiceId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CusTypeWiseServiceList GetCusTypeWiseServiceListBy(CusTypeWiseServiceList _CusTypeWiseServiceListBy)
        {
            try
            {
                if (_CusTypeWiseServiceListBy == null)
                {
                    return _CusTypeWiseServiceListBy;
                }
                return _IUoW.Repository<CusTypeWiseServiceList>().GetBy(x => x.CusTypeWiseServiceId == _CusTypeWiseServiceListBy.CusTypeWiseServiceId &&
                                                                   x.AuthStatusId != "D" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add
        public int AddCusTypeWiseServiceList(CusTypeWiseServiceList _CusTypeWiseServiceList)
        {
            try
            {
                CusTypeWiseServiceList ObjCusTypeWiseServiceList = null;
                List<CusTypeWiseServiceList> AllCusTypeWiseServiceList = new List<CusTypeWiseServiceList>();
                long _max = _IUoW.Repository<CusTypeWiseServiceList>().GetMaxValue(x => x.CusTypeWiseServiceId);
                foreach (var item in _CusTypeWiseServiceList.DefineServiceArray)
                {
                    ObjCusTypeWiseServiceList = new CusTypeWiseServiceList();
                    ObjCusTypeWiseServiceList.CusTypeWiseServiceId = (++_max).ToString().PadLeft(3, '0');
                    ObjCusTypeWiseServiceList.AccTypeId = _CusTypeWiseServiceList.AccTypeId;
                    ObjCusTypeWiseServiceList.AccCategoryId = _CusTypeWiseServiceList.AccCategoryId;
                    ObjCusTypeWiseServiceList.DefineServiceId = item.Value;
                    ObjCusTypeWiseServiceList.AuthStatusId = "U";
                    ObjCusTypeWiseServiceList.LastAction = "ADD";
                    ObjCusTypeWiseServiceList.MakeBy = "mTaka";
                    ObjCusTypeWiseServiceList.MakeDT = DateTime.Now;
                    AllCusTypeWiseServiceList.Add(ObjCusTypeWiseServiceList);
                }
                //var result = _IUoW.Repository<CusTypeWiseServiceList>().Add(_CusTypeWiseServiceList);
                var result = _IUoW.Repository<CusTypeWiseServiceList>().AddRange(AllCusTypeWiseServiceList);

                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    _IAuthLogService.AddAuthLog(_IUoW, null, AllCusTypeWiseServiceList, "ADD", "0001", _CusTypeWiseServiceList.FunctionId, 1, "CusTypeWiseServiceList", "MTK_SP_CUS_TYPE_WISE_SERVICE", "CusTypeWiseServiceId", null, _CusTypeWiseServiceList.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddCusTypeWiseServiceList(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateCusTypeWiseServiceList(CusTypeWiseServiceList _CusTypeWiseServiceList)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_CusTypeWiseServiceList.CusTypeWiseServiceId))
                {
                    IsRecordExist = _IUoW.Repository<CusTypeWiseServiceList>().IsRecordExist(x => x.CusTypeWiseServiceId == _CusTypeWiseServiceList.CusTypeWiseServiceId);
                    if (IsRecordExist)
                    {
                        var _oldCusTypeWiseServiceList = _IUoW.Repository<CusTypeWiseServiceList>().GetBy(x => x.CusTypeWiseServiceId == _CusTypeWiseServiceList.CusTypeWiseServiceId);
                        var _oldCusTypeWiseServiceListForLog = ObjectCopier.DeepCopy(_oldCusTypeWiseServiceList);

                        _oldCusTypeWiseServiceList.AuthStatusId = _CusTypeWiseServiceList.AuthStatusId = "U";
                        _oldCusTypeWiseServiceList.LastAction = _CusTypeWiseServiceList.LastAction = "EDT";
                        _oldCusTypeWiseServiceList.LastUpdateDT = _CusTypeWiseServiceList.LastUpdateDT = System.DateTime.Now;
                        _CusTypeWiseServiceList.MakeBy = "mtaka";
                        _CusTypeWiseServiceList.LastUpdateDT = DateTime.Now;
                        result = _IUoW.Repository<CusTypeWiseServiceList>().Update(_oldCusTypeWiseServiceList);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldCusTypeWiseServiceListForLog, _CusTypeWiseServiceList, "EDT", "0001", _CusTypeWiseServiceList.FunctionId, 1, "CusTypeWiseServiceList", "MTK_SP_CUS_TYPE_WISE_SERVICE", "CusTypeWiseServiceId", _CusTypeWiseServiceList.CusTypeWiseServiceId, _CusTypeWiseServiceList.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateCusTypeWiseServiceList(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteCusTypeWiseServiceList(CusTypeWiseServiceList _CusTypeWiseServiceList)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_CusTypeWiseServiceList.CusTypeWiseServiceId))
                {
                    IsRecordExist = _IUoW.Repository<CusTypeWiseServiceList>().IsRecordExist(x => x.CusTypeWiseServiceId == _CusTypeWiseServiceList.CusTypeWiseServiceId);
                    if (IsRecordExist)
                    {
                        var _oldCusTypeWiseServiceList = _IUoW.Repository<CusTypeWiseServiceList>().GetBy(x => x.CusTypeWiseServiceId == _CusTypeWiseServiceList.CusTypeWiseServiceId);
                        var _oldCusTypeWiseServiceListForLog = ObjectCopier.DeepCopy(_oldCusTypeWiseServiceList);

                        _oldCusTypeWiseServiceList.AuthStatusId = _CusTypeWiseServiceList.AuthStatusId = "U";
                        _oldCusTypeWiseServiceList.LastAction = _CusTypeWiseServiceList.LastAction = "DEL";
                        _oldCusTypeWiseServiceList.LastUpdateDT = _CusTypeWiseServiceList.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<CusTypeWiseServiceList>().Update(_oldCusTypeWiseServiceList);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            _IAuthLogService.AddAuthLog(_IUoW, _oldCusTypeWiseServiceListForLog, _CusTypeWiseServiceList, "DEL", "0001", _CusTypeWiseServiceList.FunctionId, 1, "CusTypeWiseServiceList", "MTK_SP_CUS_TYPE_WISE_SERVICE", "CusTypeWiseServiceId", _CusTypeWiseServiceList.CusTypeWiseServiceId, _CusTypeWiseServiceList.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                    //result = _IUoW.Repository<CusTypeWiseServiceList>().Delete(_CusTypeWiseServiceList);
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteCusTypeWiseServiceList(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        public IEnumerable<SelectListItem> AccTypeForCusCategory(string AccCategoryId)
        {
            try
            {
                var List_AccType = _IUoW.Repository<AccType>().GetBy(x => x.AuthStatusId != "D" &&
                                                                             x.LastAction != "DEL" && x.AccCategoryId == AccCategoryId, n => new { n.AccTypeId, n.AccTypeNm }).ToList();
                var selectList = new List<SelectListItem>();
                foreach (var element in List_AccType)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.AccTypeId,
                        Text = element.AccTypeNm
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
    }
}
