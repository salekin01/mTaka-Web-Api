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
    public interface IDistrictInfoService
    {
        List<DistrictInfo> GetAllDistrictInfo();
        DistrictInfo GetDistrictInfoById(string _DistrictId);
        DistrictInfo GetDistrictInfoBy(DistrictInfo _DistrictInfo);
        int AddDistrictInfo(DistrictInfo _DistrictInfo);
        int UpdateDistrictInfo(DistrictInfo _DistrictInfo);
        int DeleteDistrictInfo(DistrictInfo _DistrictInfo);
        IEnumerable<SelectListItem> GetDistrictInfoForDD();
    }
    public class DistrictInfoService : IDistrictInfoService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public DistrictInfoService()
        {
            _IUoW = new UnitOfWork();
        }
        public DistrictInfoService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public List<DistrictInfo> GetAllDistrictInfo()
        {
            try
            {
                List<DistrictInfo> OBJ_LIST_DistrictInfo = new List<DistrictInfo>();
                var _ListDistrictInfo = _IUoW.Repository<DistrictInfo>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.DistrictId);
                foreach (var item in _ListDistrictInfo)
                {
                    DistrictInfo OBJ_DistrictInfo = new DistrictInfo();
                    DivisionInfoService OBJ_DivisionInfoService = new DivisionInfoService();

                    OBJ_DistrictInfo.DistrictId = item.DistrictId;
                    OBJ_DistrictInfo.DistrictNm = item.DistrictNm;
                    OBJ_DistrictInfo.DistrictShortNm = item.DistrictShortNm;
                    OBJ_DistrictInfo.DivisionId = item.DivisionId;
                    foreach (var item1 in OBJ_DivisionInfoService.GetDivisionInfoForDD())
                    {
                        if (item1.Value == OBJ_DistrictInfo.DivisionId)
                        {
                            OBJ_DistrictInfo.DivisionNm = item1.Text;
                        }
                    }
                    OBJ_DistrictInfo.AuthStatusId = item.AuthStatusId;
                    OBJ_DistrictInfo.LastAction = item.LastAction;
                    OBJ_DistrictInfo.LastUpdateDT = item.LastUpdateDT;
                    OBJ_DistrictInfo.MakeBy = item.MakeBy;
                    OBJ_DistrictInfo.MakeDT = item.MakeDT;
                    OBJ_DistrictInfo.TransDT = item.TransDT;
                    OBJ_LIST_DistrictInfo.Add(OBJ_DistrictInfo);
                }
                return OBJ_LIST_DistrictInfo;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllDistrictInfo()", string.Empty);
                return null;
            }
        }

        public DistrictInfo GetDistrictInfoById(string _DistrictId)
        {
            try
            {
                return _IUoW.Repository<DistrictInfo>().GetById(_DistrictId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetDistrictInfoById(string)", string.Empty);
                return null;
            }
        }
        public DistrictInfo GetDistrictInfoBy(DistrictInfo _DistrictInfo)
        {
            try
            {
                if (_DistrictInfo == null)
                {
                    return _DistrictInfo;
                }
                return _IUoW.Repository<DistrictInfo>().GetBy(x => x.DistrictId == _DistrictInfo.DistrictId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetDistrictInfoBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddDistrictInfo(DistrictInfo _DistrictInfo)
        {
            try
            {
                var _max = _IUoW.Repository<DistrictInfo>().GetMaxValue(x => x.DistrictId) + 1;
                _DistrictInfo.DistrictId = _max.ToString().PadLeft(3, '0');
                _DistrictInfo.AuthStatusId = "A";
                _DistrictInfo.LastAction = "ADD";
                _DistrictInfo.MakeDT = System.DateTime.Now;
                _DistrictInfo.MakeBy = "mtaka";
                var result = _IUoW.Repository<DistrictInfo>().Add(_DistrictInfo);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _DistrictInfo, "ADD", "0001", "090101005", 1, "DistrictInfo", "MTK_CP_DISTRICT_INFO", "DistrictId", _DistrictInfo.DistrictId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddDistrictInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateDistrictInfo(DistrictInfo _DistrictInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_DistrictInfo.DistrictId))
                {
                    IsRecordExist = _IUoW.Repository<DistrictInfo>().IsRecordExist(x => x.DistrictId == _DistrictInfo.DistrictId);
                    if (IsRecordExist)
                    {
                        var _oldDistrictInfo = _IUoW.Repository<DistrictInfo>().GetBy(x => x.DistrictId == _DistrictInfo.DistrictId);
                        var _oldDistrictInfoForLog = ObjectCopier.DeepCopy(_oldDistrictInfo);

                        _oldDistrictInfo.AuthStatusId = _DistrictInfo.AuthStatusId = "U";
                        _oldDistrictInfo.LastAction = _DistrictInfo.LastAction = "EDT";
                        _oldDistrictInfo.LastUpdateDT = _DistrictInfo.LastUpdateDT = System.DateTime.Now;
                        _DistrictInfo.MakeBy = "mtaka";
                        result = _IUoW.Repository<DistrictInfo>().Update(_oldDistrictInfo);
                        
                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldDistrictInfoForLog, _DistrictInfo, "EDT", "0001", "090101005", 1, "DistrictInfo", "MTK_CP_DISTRICT_INFO", "DistrictId", _DistrictInfo.DistrictId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateDistrictInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteDistrictInfo(DistrictInfo _DistrictInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_DistrictInfo.DistrictId))
                {
                    IsRecordExist = _IUoW.Repository<DistrictInfo>().IsRecordExist(x => x.DistrictId == _DistrictInfo.DistrictId);
                    if (IsRecordExist)
                    {
                        var _oldDistrictInfo = _IUoW.Repository<DistrictInfo>().GetBy(x => x.DistrictId == _DistrictInfo.DistrictId);
                        var _oldDistrictInfoForLog = ObjectCopier.DeepCopy(_oldDistrictInfo);

                        _oldDistrictInfo.AuthStatusId = _DistrictInfo.AuthStatusId = "U";
                        _oldDistrictInfo.LastAction = _DistrictInfo.LastAction = "DEL";
                        _oldDistrictInfo.LastUpdateDT = _DistrictInfo.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<DistrictInfo>().Update(_oldDistrictInfo);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldDistrictInfoForLog, _DistrictInfo, "DEL", "0001", "090101005", 1, "DistrictInfo", "MTK_CP_DISTRICT_INFO", "DistrictId", _DistrictInfo.DistrictId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteDistrictInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region For Dropdown
        public IEnumerable<SelectListItem> GetDistrictInfoForDD()
        {
            try
            {
                var List_District_Info = _IUoW.Repository<DistrictInfo>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.DistrictId, n.DistrictNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_District_Info)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.DistrictId,
                        Text = element.DistrictNm
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetDistrictInfoForDD()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}