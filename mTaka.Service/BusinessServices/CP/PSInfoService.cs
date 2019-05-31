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
    public interface IPSInfoService
    {
        List<PSInfo> GetAllPSInfo();
        PSInfo GetPSInfoById(string _PoliceStationId);
        PSInfo GetPSInfoBy(PSInfo _PSInfo);
        int AddPSInfo(PSInfo _PSInfo);
        int UpdatePSInfo(PSInfo _PSInfo);
        int DeletePSInfo(PSInfo _PSInfo);
        IEnumerable<SelectListItem> GetPSInfoForDD();
    }
    public class PSInfoService : IPSInfoService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public PSInfoService()
        {
            _IUoW = new UnitOfWork();
        }
        public PSInfoService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public List<PSInfo> GetAllPSInfo()
        {
            try
            {
                List<PSInfo> OBJ_LIST_PSInfo = new List<PSInfo>();
                var _ListPSInfo = _IUoW.Repository<PSInfo>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.PoliceStationId);
                foreach (var item in _ListPSInfo)
                {
                    PSInfo OBJ_PSInfo = new PSInfo();
                    UpazilaInfoService OBJ_UpazilaInfoService = new UpazilaInfoService();

                    OBJ_PSInfo.PoliceStationId = item.PoliceStationId;
                    OBJ_PSInfo.PoliceStationNm = item.PoliceStationNm;
                    OBJ_PSInfo.PoliceStationShortNm = item.PoliceStationShortNm;
                    OBJ_PSInfo.UpazilaId = item.UpazilaId;
                    foreach (var item1 in OBJ_UpazilaInfoService.GetUpazilaInfoForDD())
                    {
                        if (item1.Value == OBJ_PSInfo.UpazilaId)
                        {
                            OBJ_PSInfo.UpazilaNm = item1.Text;
                        }
                    }
                    OBJ_PSInfo.AuthStatusId = item.AuthStatusId;
                    OBJ_PSInfo.LastAction = item.LastAction;
                    OBJ_PSInfo.LastUpdateDT = item.LastUpdateDT;
                    OBJ_PSInfo.MakeBy = item.MakeBy;
                    OBJ_PSInfo.MakeDT = item.MakeDT;
                    OBJ_PSInfo.TransDT = item.TransDT;
                    OBJ_LIST_PSInfo.Add(OBJ_PSInfo);
                }
                return OBJ_LIST_PSInfo;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllPSInfo()", string.Empty);
                return null;
            }
        }

        public PSInfo GetPSInfoById(string _PoliceStationId)
        {
            try
            {
                return _IUoW.Repository<PSInfo>().GetById(_PoliceStationId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetPSInfoById(string)", string.Empty);
                return null;
            }
        }
        public PSInfo GetPSInfoBy(PSInfo _PSInfo)
        {
            try
            {
                if (_PSInfo == null)
                {
                    return _PSInfo;
                }
                return _IUoW.Repository<PSInfo>().GetBy(x => x.PoliceStationId == _PSInfo.PoliceStationId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetPSInfoBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddPSInfo(PSInfo _PSInfo)
        {
            try
            {
                var _max = _IUoW.Repository<PSInfo>().GetMaxValue(x => x.PoliceStationId) + 1;
                _PSInfo.PoliceStationId = _max.ToString().PadLeft(3, '0');
                _PSInfo.AuthStatusId = "A";
                _PSInfo.LastAction = "ADD";
                _PSInfo.MakeDT = System.DateTime.Now;
                _PSInfo.MakeBy = "mtaka";
                var result = _IUoW.Repository<PSInfo>().Add(_PSInfo);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _PSInfo, "ADD", "0001", "090101007", 1, "PSInfo", "MTK_CP_PS_INFO", "PoliceStationId", _PSInfo.PoliceStationId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddPSInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdatePSInfo(PSInfo _PSInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_PSInfo.PoliceStationId))
                {
                    IsRecordExist = _IUoW.Repository<PSInfo>().IsRecordExist(x => x.PoliceStationId == _PSInfo.PoliceStationId);
                    if (IsRecordExist)
                    {
                        var _oldPSInfo = _IUoW.Repository<PSInfo>().GetBy(x => x.PoliceStationId == _PSInfo.PoliceStationId);
                        var _oldPSInfoForLog = ObjectCopier.DeepCopy(_oldPSInfo);

                        _oldPSInfo.AuthStatusId = _PSInfo.AuthStatusId = "U";
                        _oldPSInfo.LastAction = _PSInfo.LastAction = "EDT";
                        _oldPSInfo.LastUpdateDT = _PSInfo.LastUpdateDT = System.DateTime.Now;
                        _PSInfo.MakeBy = "mtaka";
                        result = _IUoW.Repository<PSInfo>().Update(_oldPSInfo);

                        #region Testing Purpose
                        #endregion

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldPSInfoForLog, _PSInfo, "EDT", "0001", "090101007", 1, "PSInfo", "MTK_CP_PS_INFO", "PoliceStationId", _PSInfo.PoliceStationId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdatePSInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeletePSInfo(PSInfo _PSInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_PSInfo.PoliceStationId))
                {
                    IsRecordExist = _IUoW.Repository<PSInfo>().IsRecordExist(x => x.PoliceStationId == _PSInfo.PoliceStationId);
                    if (IsRecordExist)
                    {
                        var _oldPSInfo = _IUoW.Repository<PSInfo>().GetBy(x => x.PoliceStationId == _PSInfo.PoliceStationId);
                        var _oldPSInfoForLog = ObjectCopier.DeepCopy(_oldPSInfo);

                        _oldPSInfo.AuthStatusId = _PSInfo.AuthStatusId = "U";
                        _oldPSInfo.LastAction = _PSInfo.LastAction = "DEL";
                        _oldPSInfo.LastUpdateDT = _PSInfo.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<PSInfo>().Update(_oldPSInfo);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldPSInfoForLog, _PSInfo, "DEL", "0001", "090101007", 1, "PSInfo", "MTK_CP_PS_INFO", "PoliceStationId", _PSInfo.PoliceStationId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeletePSInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region For Dropdown
        public IEnumerable<SelectListItem> GetPSInfoForDD()
        {
            try
            {
                var List_PS_Info = _IUoW.Repository<PSInfo>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.PoliceStationId, n.PoliceStationNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_PS_Info)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.PoliceStationId,
                        Text = element.PoliceStationNm
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetPSInfoForDD()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}