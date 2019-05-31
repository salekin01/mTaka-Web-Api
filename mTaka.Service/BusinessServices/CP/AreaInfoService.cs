using mTaka.Data.BusinessEntities.CP;
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

namespace mTaka.Service.BusinessServices.CP
{
    public interface IAreaInfoService
    {
        List<AreaInfo> GetAllAreaInfo();
        AreaInfo GetAreaInfoById(string _AreaId);
        AreaInfo GetAreaInfoBy(AreaInfo _AreaInfo);
        int AddAreaInfo(AreaInfo _AreaInfo);
        int UpdateAreaInfo(AreaInfo _AreaInfo);
        int DeleteAreaInfo(AreaInfo _AreaInfo);
        IEnumerable<SelectListItem> GetAreaInfoForDD();
    }
    public class AreaInfoService : IAreaInfoService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public AreaInfoService()
        {
            _IUoW = new UnitOfWork();
        }
        public AreaInfoService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public List<AreaInfo> GetAllAreaInfo()
        {
            try
            {
                List<AreaInfo> OBJ_LIST_AreaInfo = new List<AreaInfo>();
                var _ListAreaInfo = _IUoW.Repository<AreaInfo>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.AreaId);
                foreach (var item in _ListAreaInfo)
                {
                    AreaInfo OBJ_AreaInfo = new AreaInfo();
                    UpazilaInfoService OBJ_UpazilaInfoService = new UpazilaInfoService();
                    CityInfoService OBJ_CityInfoService = new CityInfoService();

                    OBJ_AreaInfo.AreaId = item.AreaId;
                    OBJ_AreaInfo.AreaNm = item.AreaNm;
                    OBJ_AreaInfo.AreaShortNm = item.AreaShortNm;
                    OBJ_AreaInfo.UpazilaId = item.UpazilaId;
                    foreach (var item1 in OBJ_UpazilaInfoService.GetUpazilaInfoForDD())
                    {
                        if (item1.Value == OBJ_AreaInfo.UpazilaId)
                        {
                            OBJ_AreaInfo.UpazilaNm = item1.Text;
                        }
                    }
                    OBJ_AreaInfo.CityId = item.CityId;
                    foreach (var item1 in OBJ_CityInfoService.GetCityInfoForDD())
                    {
                        if (item1.Value == OBJ_AreaInfo.CityId)
                        {
                            OBJ_AreaInfo.CityNm = item1.Text;
                        }
                    }
                    OBJ_AreaInfo.AuthStatusId = item.AuthStatusId;
                    OBJ_AreaInfo.LastAction = item.LastAction;
                    OBJ_AreaInfo.LastUpdateDT = item.LastUpdateDT;
                    OBJ_AreaInfo.MakeBy = item.MakeBy;
                    OBJ_AreaInfo.MakeDT = item.MakeDT;
                    OBJ_AreaInfo.TransDT = item.TransDT;
                    OBJ_LIST_AreaInfo.Add(OBJ_AreaInfo);
                }
                return OBJ_LIST_AreaInfo;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllAreaInfo()", string.Empty);
                return null;
            }
        }

        public AreaInfo GetAreaInfoById(string _AreaId)
        {
            try
            {
                return _IUoW.Repository<AreaInfo>().GetById(_AreaId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAreaInfoById(string)", string.Empty);
                return null;
            }
        }
        public AreaInfo GetAreaInfoBy(AreaInfo _AreaInfo)
        {
            try
            {
                if (_AreaInfo == null)
                {
                    return _AreaInfo;
                }
                return _IUoW.Repository<AreaInfo>().GetBy(x => x.AreaId == _AreaInfo.AreaId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAreaInfoBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddAreaInfo(AreaInfo _AreaInfo)
        {
            try
            {
                var _max = _IUoW.Repository<AreaInfo>().GetMaxValue(x => x.AreaId) + 1;
                _AreaInfo.AreaId = _max.ToString().PadLeft(3, '0');
                _AreaInfo.AuthStatusId = "A";
                _AreaInfo.LastAction = "ADD";
                _AreaInfo.MakeDT = System.DateTime.Now;
                _AreaInfo.MakeBy = "mtaka";
                var result = _IUoW.Repository<AreaInfo>().Add(_AreaInfo);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _AreaInfo, "ADD", "0001", "090101008", 1, "AreaInfo", "MTK_CP_AREA_INFO", "AreaId", _AreaInfo.AreaId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddAreaInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateAreaInfo(AreaInfo _AreaInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_AreaInfo.AreaId))
                {
                    IsRecordExist = _IUoW.Repository<AreaInfo>().IsRecordExist(x => x.AreaId == _AreaInfo.AreaId);
                    if (IsRecordExist)
                    {
                        var _oldAreaInfo = _IUoW.Repository<AreaInfo>().GetBy(x => x.AreaId == _AreaInfo.AreaId);
                        var _oldAreaInfoForLog = ObjectCopier.DeepCopy(_oldAreaInfo);

                        _oldAreaInfo.AuthStatusId = _AreaInfo.AuthStatusId = "U";
                        _oldAreaInfo.LastAction = _AreaInfo.LastAction = "EDT";
                        _oldAreaInfo.LastUpdateDT = _AreaInfo.LastUpdateDT = System.DateTime.Now;
                        _AreaInfo.MakeBy = "mtaka";
                        result = _IUoW.Repository<AreaInfo>().Update(_oldAreaInfo);

                        #region Testing Purpose
                        #endregion

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldAreaInfoForLog, _AreaInfo, "EDT", "0001", "090101008", 1, "AreaInfo", "MTK_CP_AREA_INFO", "AreaId", _AreaInfo.AreaId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateAreaInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteAreaInfo(AreaInfo _AreaInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_AreaInfo.AreaId))
                {
                    IsRecordExist = _IUoW.Repository<AreaInfo>().IsRecordExist(x => x.AreaId == _AreaInfo.AreaId);
                    if (IsRecordExist)
                    {
                        var _oldAreaInfo = _IUoW.Repository<AreaInfo>().GetBy(x => x.AreaId == _AreaInfo.AreaId);
                        var _oldAreaInfoForLog = ObjectCopier.DeepCopy(_oldAreaInfo);

                        _oldAreaInfo.AuthStatusId = _AreaInfo.AuthStatusId = "U";
                        _oldAreaInfo.LastAction = _AreaInfo.LastAction = "DEL";
                        _oldAreaInfo.LastUpdateDT = _AreaInfo.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<AreaInfo>().Update(_oldAreaInfo);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldAreaInfoForLog, _AreaInfo, "DEL", "0001", "090101008", 1, "AreaInfo", "MTK_CP_AREA_INFO", "AreaId", _AreaInfo.AreaId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteAreaInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region For Dropdown
        public IEnumerable<SelectListItem> GetAreaInfoForDD()
        {
            try
            {
                var List_Area_Info = _IUoW.Repository<AreaInfo>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.AreaId, n.AreaNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Area_Info)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.AreaId,
                        Text = element.AreaNm
                    });
                }
                if (selectList != null)
                    return selectList;
                else
                    throw new Exception("Invalid");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAreaInfoForDD()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}