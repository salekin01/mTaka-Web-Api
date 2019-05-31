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
    public interface ICityInfoService
    {
        List<CityInfo> GetAllCityInfo();
        CityInfo GetCityInfoById(string _CityId);
        CityInfo GetCityInfoBy(CityInfo _CityInfo);
        int AddCityInfo(CityInfo _CityInfo);
        int UpdateCityInfo(CityInfo _CityInfo);
        int DeleteCityInfo(CityInfo _CityInfo);
        IEnumerable<SelectListItem> GetCityInfoForDD();
    }
    public class CityInfoService : ICityInfoService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public CityInfoService()
        {
            _IUoW = new UnitOfWork();
        }
        public CityInfoService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public List<CityInfo> GetAllCityInfo()
        {
            try
            {
                List<CityInfo> OBJ_LIST_CityInfo = new List<CityInfo>();
                var _ListCityInfo = _IUoW.Repository<CityInfo>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.CityId);
                foreach (var item in _ListCityInfo)
                {
                    CityInfo OBJ_CityInfo = new CityInfo();
                    DivisionInfoService OBJ_DivisionInfoService = new DivisionInfoService();

                    OBJ_CityInfo.CityId = item.CityId;
                    OBJ_CityInfo.CityNm = item.CityNm;
                    OBJ_CityInfo.CityShortNm = item.CityShortNm;
                    OBJ_CityInfo.DivisionId = item.DivisionId;
                    foreach (var item1 in OBJ_DivisionInfoService.GetDivisionInfoForDD())
                    {
                        if (item1.Value == OBJ_CityInfo.DivisionId)
                        {
                            OBJ_CityInfo.DivisionNm = item1.Text;
                        }
                    }
                    OBJ_CityInfo.AuthStatusId = item.AuthStatusId;
                    OBJ_CityInfo.LastAction = item.LastAction;
                    OBJ_CityInfo.LastUpdateDT = item.LastUpdateDT;
                    OBJ_CityInfo.MakeBy = item.MakeBy;
                    OBJ_CityInfo.MakeDT = item.MakeDT;
                    OBJ_CityInfo.TransDT = item.TransDT;
                    OBJ_LIST_CityInfo.Add(OBJ_CityInfo);
                }
                return OBJ_LIST_CityInfo;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllCityInfo()", string.Empty);
                return null;
            }
        }

        public CityInfo GetCityInfoById(string _CityId)
        {
            try
            {
                return _IUoW.Repository<CityInfo>().GetById(_CityId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCityInfoById(string)", string.Empty);
                return null;
            }
        }
        public CityInfo GetCityInfoBy(CityInfo _CityInfo)
        {
            try
            {
                if (_CityInfo == null)
                {
                    return _CityInfo;
                }
                return _IUoW.Repository<CityInfo>().GetBy(x => x.CityId == _CityInfo.CityId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCityInfoBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddCityInfo(CityInfo _CityInfo)
        {
            try
            {
                var _max = _IUoW.Repository<CityInfo>().GetMaxValue(x => x.CityId) + 1;
                _CityInfo.CityId = _max.ToString().PadLeft(3, '0');
                _CityInfo.AuthStatusId = "A";
                _CityInfo.LastAction = "ADD";
                _CityInfo.MakeDT = System.DateTime.Now;
                _CityInfo.MakeBy = "mtaka";
                var result = _IUoW.Repository<CityInfo>().Add(_CityInfo);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _CityInfo, "ADD", "0001", "090101004", 1, "CityInfo", "MTK_CP_CITY_INFO", "CityId", _CityInfo.CityId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddCityInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateCityInfo(CityInfo _CityInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_CityInfo.CityId))
                {
                    IsRecordExist = _IUoW.Repository<CityInfo>().IsRecordExist(x => x.CityId == _CityInfo.CityId);
                    if (IsRecordExist)
                    {
                        var _oldCityInfo = _IUoW.Repository<CityInfo>().GetBy(x => x.CityId == _CityInfo.CityId);
                        var _oldCityInfoForLog = ObjectCopier.DeepCopy(_oldCityInfo);

                        _oldCityInfo.AuthStatusId = _CityInfo.AuthStatusId = "U";
                        _oldCityInfo.LastAction = _CityInfo.LastAction = "EDT";
                        _oldCityInfo.LastUpdateDT = _CityInfo.LastUpdateDT = System.DateTime.Now;
                        _CityInfo.MakeBy = "mtaka";
                        result = _IUoW.Repository<CityInfo>().Update(_oldCityInfo);

                        #region Testing Purpose
                        #endregion

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldCityInfoForLog, _CityInfo, "EDT", "0001", "090101004", 1, "CityInfo", "MTK_CP_CITY_INFO", "CityId", _CityInfo.CityId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateCityInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteCityInfo(CityInfo _CityInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_CityInfo.CityId))
                {
                    IsRecordExist = _IUoW.Repository<CityInfo>().IsRecordExist(x => x.CityId == _CityInfo.CityId);
                    if (IsRecordExist)
                    {
                        var _oldCityInfo = _IUoW.Repository<CityInfo>().GetBy(x => x.CityId == _CityInfo.CityId);
                        var _oldCityInfoForLog = ObjectCopier.DeepCopy(_oldCityInfo);

                        _oldCityInfo.AuthStatusId = _CityInfo.AuthStatusId = "U";
                        _oldCityInfo.LastAction = _CityInfo.LastAction = "DEL";
                        _oldCityInfo.LastUpdateDT = _CityInfo.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<CityInfo>().Update(_oldCityInfo);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldCityInfoForLog, _CityInfo, "DEL", "0001", "090101004", 1, "CityInfo", "MTK_CP_CITY_INFO", "CityId", _CityInfo.CityId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteCityInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion
        
        #region For Dropdown
        public IEnumerable<SelectListItem> GetCityInfoForDD()
        {
            try
            {
                var List_City_Info = _IUoW.Repository<CityInfo>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.CityId, n.CityNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_City_Info)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.CityId,
                        Text = element.CityNm
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCityInfoForDD()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}
