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
    public interface IUpazilaInfoService
    {
        List<UpazilaInfo> GetAllUpazilaInfo();
        UpazilaInfo GetUpazilaInfoById(string _UpazilaId);
        UpazilaInfo GetUpazilaInfoBy(UpazilaInfo _UpazilaInfo);
        int AddUpazilaInfo(UpazilaInfo _UpazilaInfo);
        int UpdateUpazilaInfo(UpazilaInfo _UpazilaInfo);
        int DeleteUpazilaInfo(UpazilaInfo _UpazilaInfo);
        IEnumerable<SelectListItem> GetUpazilaInfoForDD();
    }
    public class UpazilaInfoService : IUpazilaInfoService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public UpazilaInfoService()
        {
            _IUoW = new UnitOfWork();
        }
        public UpazilaInfoService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public List<UpazilaInfo> GetAllUpazilaInfo()
        {
            try
            {
                List<UpazilaInfo> OBJ_LIST_UpazilaInfo = new List<UpazilaInfo>();
                var _ListUpazilaInfo = _IUoW.Repository<UpazilaInfo>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.UpazilaId);
                foreach (var item in _ListUpazilaInfo)
                {
                    UpazilaInfo OBJ_UpazilaInfo = new UpazilaInfo();
                    DistrictInfoService OBJ_DistrictInfoService = new DistrictInfoService();

                    OBJ_UpazilaInfo.UpazilaId = item.UpazilaId;
                    OBJ_UpazilaInfo.UpazilaNm = item.UpazilaNm;
                    OBJ_UpazilaInfo.UpazilaShortNm = item.UpazilaShortNm;
                    OBJ_UpazilaInfo.DistrictId = item.DistrictId;
                    foreach (var item1 in OBJ_DistrictInfoService.GetDistrictInfoForDD())
                    {
                        if (item1.Value == OBJ_UpazilaInfo.DistrictId)
                        {
                            OBJ_UpazilaInfo.DistrictNm = item1.Text;
                        }
                    }
                    OBJ_UpazilaInfo.AuthStatusId = item.AuthStatusId;
                    OBJ_UpazilaInfo.LastAction = item.LastAction;
                    OBJ_UpazilaInfo.LastUpdateDT = item.LastUpdateDT;
                    OBJ_UpazilaInfo.MakeBy = item.MakeBy;
                    OBJ_UpazilaInfo.MakeDT = item.MakeDT;
                    OBJ_UpazilaInfo.TransDT = item.TransDT;
                    OBJ_LIST_UpazilaInfo.Add(OBJ_UpazilaInfo);
                }
                return OBJ_LIST_UpazilaInfo;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllUpazilaInfo()", string.Empty);
                return null;
            }
        }

        public UpazilaInfo GetUpazilaInfoById(string _UpazilaId)
        {
            try
            {
                return _IUoW.Repository<UpazilaInfo>().GetById(_UpazilaId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetUpazilaInfoById(string)", string.Empty);
                return null;
            }
        }
        public UpazilaInfo GetUpazilaInfoBy(UpazilaInfo _UpazilaInfo)
        {
            try
            {
                if (_UpazilaInfo == null)
                {
                    return _UpazilaInfo;
                }
                return _IUoW.Repository<UpazilaInfo>().GetBy(x => x.UpazilaId == _UpazilaInfo.UpazilaId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetUpazilaInfoBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddUpazilaInfo(UpazilaInfo _UpazilaInfo)
        {
            try
            {
                var _max = _IUoW.Repository<UpazilaInfo>().GetMaxValue(x => x.UpazilaId) + 1;
                _UpazilaInfo.UpazilaId = _max.ToString().PadLeft(3, '0');
                _UpazilaInfo.AuthStatusId = "A";
                _UpazilaInfo.LastAction = "ADD";
                _UpazilaInfo.MakeDT = System.DateTime.Now;
                _UpazilaInfo.MakeBy = "mtaka";
                var result = _IUoW.Repository<UpazilaInfo>().Add(_UpazilaInfo);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _UpazilaInfo, "ADD", "0001", "090101006", 1, "UpazilaInfo", "MTK_CP_UPAZILA_INFO", "UpazilaId", _UpazilaInfo.UpazilaId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddUpazilaInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateUpazilaInfo(UpazilaInfo _UpazilaInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_UpazilaInfo.UpazilaId))
                {
                    IsRecordExist = _IUoW.Repository<UpazilaInfo>().IsRecordExist(x => x.UpazilaId == _UpazilaInfo.UpazilaId);
                    if (IsRecordExist)
                    {
                        var _oldUpazilaInfo = _IUoW.Repository<UpazilaInfo>().GetBy(x => x.UpazilaId == _UpazilaInfo.UpazilaId);
                        var _oldUpazilaInfoForLog = ObjectCopier.DeepCopy(_oldUpazilaInfo);

                        _oldUpazilaInfo.AuthStatusId = _UpazilaInfo.AuthStatusId = "U";
                        _oldUpazilaInfo.LastAction = _UpazilaInfo.LastAction = "EDT";
                        _oldUpazilaInfo.LastUpdateDT = _UpazilaInfo.LastUpdateDT = System.DateTime.Now;
                        _UpazilaInfo.MakeBy = "mtaka";
                        result = _IUoW.Repository<UpazilaInfo>().Update(_oldUpazilaInfo);

                        #region Testing Purpose
                        #endregion

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldUpazilaInfoForLog, _UpazilaInfo, "EDT", "0001", "090101006", 1, "UpazilaInfo", "MTK_CP_UPAZILA_INFO", "UpazilaId", _UpazilaInfo.UpazilaId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateUpazilaInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteUpazilaInfo(UpazilaInfo _UpazilaInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_UpazilaInfo.UpazilaId))
                {
                    IsRecordExist = _IUoW.Repository<UpazilaInfo>().IsRecordExist(x => x.UpazilaId == _UpazilaInfo.UpazilaId);
                    if (IsRecordExist)
                    {
                        var _oldUpazilaInfo = _IUoW.Repository<UpazilaInfo>().GetBy(x => x.UpazilaId == _UpazilaInfo.UpazilaId);
                        var _oldUpazilaInfoForLog = ObjectCopier.DeepCopy(_oldUpazilaInfo);

                        _oldUpazilaInfo.AuthStatusId = _UpazilaInfo.AuthStatusId = "U";
                        _oldUpazilaInfo.LastAction = _UpazilaInfo.LastAction = "DEL";
                        _oldUpazilaInfo.LastUpdateDT = _UpazilaInfo.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<UpazilaInfo>().Update(_oldUpazilaInfo);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldUpazilaInfoForLog, _UpazilaInfo, "DEL", "0001", "090101006", 1, "UpazilaInfo", "MTK_CP_UPAZILA_INFO", "UpazilaId", _UpazilaInfo.UpazilaId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteUpazilaInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region For Dropdown
        public IEnumerable<SelectListItem> GetUpazilaInfoForDD()
        {
            try
            {
                var List_Upazila_Info = _IUoW.Repository<UpazilaInfo>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.UpazilaId, n.UpazilaNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Upazila_Info)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.UpazilaId,
                        Text = element.UpazilaNm
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetUpazilaInfoForDD()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}