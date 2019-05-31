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
    public interface IDivisionInfoService
    {
        List<DivisionInfo> GetAllDivisionInfo();
        DivisionInfo GetDivisionInfoById(string _DivisionId);
        DivisionInfo GetDivisionInfoBy(DivisionInfo _DivisionInfo);
        int AddDivisionInfo(DivisionInfo _DivisionInfo);
        int UpdateDivisionInfo(DivisionInfo _DivisionInfo);
        int DeleteDivisionInfo(DivisionInfo _DivisionInfo);
        IEnumerable<SelectListItem> GetDivisionInfoForDD();
    }
    public class DivisionInfoService : IDivisionInfoService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public DivisionInfoService()
        {
            _IUoW = new UnitOfWork();
        }
        public DivisionInfoService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public List<DivisionInfo> GetAllDivisionInfo()
        {
            try
            {
                List<DivisionInfo> OBJ_LIST_DivisionInfo = new List<DivisionInfo>();
                var _ListDivisionInfo = _IUoW.Repository<DivisionInfo>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.DivisionId);
                foreach (var item in _ListDivisionInfo)
                {
                    DivisionInfo OBJ_DivisionInfo = new DivisionInfo();
                    CountryInfoService OBJ_CountryInfoService = new CountryInfoService();

                    OBJ_DivisionInfo.DivisionId = item.DivisionId;
                    OBJ_DivisionInfo.DivisionNm = item.DivisionNm;
                    OBJ_DivisionInfo.DivisionShortNm = item.DivisionShortNm;
                    OBJ_DivisionInfo.CountryId = item.CountryId;
                    foreach (var item1 in OBJ_CountryInfoService.GetCountryInfoForDD())
                    {
                        if (item1.Value == OBJ_DivisionInfo.CountryId)
                        {
                            OBJ_DivisionInfo.CountryNm = item1.Text;
                        }
                    }
                    OBJ_DivisionInfo.AuthStatusId = item.AuthStatusId;
                    OBJ_DivisionInfo.LastAction = item.LastAction;
                    OBJ_DivisionInfo.LastUpdateDT = item.LastUpdateDT;
                    OBJ_DivisionInfo.MakeBy = item.MakeBy;
                    OBJ_DivisionInfo.MakeDT = item.MakeDT;
                    OBJ_DivisionInfo.TransDT = item.TransDT;
                    OBJ_LIST_DivisionInfo.Add(OBJ_DivisionInfo);
                }
                return OBJ_LIST_DivisionInfo;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllDivisionInfo()", string.Empty);
                return null;
            }
        }

        public DivisionInfo GetDivisionInfoById(string _DivisionId)
        {
            try
            {
                return _IUoW.Repository<DivisionInfo>().GetById(_DivisionId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetDivisionInfoById(string)", string.Empty);
                return null;
            }
        }
        public DivisionInfo GetDivisionInfoBy(DivisionInfo _DivisionInfo)
        {
            try
            {
                if (_DivisionInfo == null)
                {
                    return _DivisionInfo;
                }
                return _IUoW.Repository<DivisionInfo>().GetBy(x => x.DivisionId == _DivisionInfo.DivisionId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetDivisionInfoBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddDivisionInfo(DivisionInfo _DivisionInfo)
        {
            try
            {
                var _max = _IUoW.Repository<DivisionInfo>().GetMaxValue(x => x.DivisionId) + 1;
                _DivisionInfo.DivisionId = _max.ToString().PadLeft(3, '0');
                _DivisionInfo.AuthStatusId = "A";
                _DivisionInfo.LastAction = "ADD";
                _DivisionInfo.MakeDT = System.DateTime.Now;
                _DivisionInfo.MakeBy = "mtaka";
                var result = _IUoW.Repository<DivisionInfo>().Add(_DivisionInfo);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _DivisionInfo, "ADD", "0001", "090101003", 1, "DivisionInfo", "MTK_CP_DIVISION_INFO", "DivisionId", _DivisionInfo.DivisionId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddDivisionInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateDivisionInfo(DivisionInfo _DivisionInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_DivisionInfo.DivisionId))
                {
                    IsRecordExist = _IUoW.Repository<DivisionInfo>().IsRecordExist(x => x.DivisionId == _DivisionInfo.DivisionId);
                    if (IsRecordExist)
                    {
                        var _oldDivisionInfo = _IUoW.Repository<DivisionInfo>().GetBy(x => x.DivisionId == _DivisionInfo.DivisionId);
                        var _oldDivisionInfoForLog = ObjectCopier.DeepCopy(_oldDivisionInfo);

                        _oldDivisionInfo.AuthStatusId = _DivisionInfo.AuthStatusId = "U";
                        _oldDivisionInfo.LastAction = _DivisionInfo.LastAction = "EDT";
                        _oldDivisionInfo.LastUpdateDT = _DivisionInfo.LastUpdateDT = System.DateTime.Now;
                        _DivisionInfo.MakeBy = "mtaka";
                        result = _IUoW.Repository<DivisionInfo>().Update(_oldDivisionInfo);

                        #region Testing Purpose
                        #endregion

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldDivisionInfoForLog, _DivisionInfo, "EDT", "0001", "090101003", 1, "DivisionInfo", "MTK_CP_DIVISION_INFO", "DivisionId", _DivisionInfo.DivisionId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateDivisionInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteDivisionInfo(DivisionInfo _DivisionInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_DivisionInfo.DivisionId))
                {
                    IsRecordExist = _IUoW.Repository<DivisionInfo>().IsRecordExist(x => x.DivisionId == _DivisionInfo.DivisionId);
                    if (IsRecordExist)
                    {
                        var _oldDivisionInfo = _IUoW.Repository<DivisionInfo>().GetBy(x => x.DivisionId == _DivisionInfo.DivisionId);
                        var _oldDivisionInfoForLog = ObjectCopier.DeepCopy(_oldDivisionInfo);

                        _oldDivisionInfo.AuthStatusId = _DivisionInfo.AuthStatusId = "U";
                        _oldDivisionInfo.LastAction = _DivisionInfo.LastAction = "DEL";
                        _oldDivisionInfo.LastUpdateDT = _DivisionInfo.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<DivisionInfo>().Update(_oldDivisionInfo);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldDivisionInfoForLog, _DivisionInfo, "DEL", "0001", "090101003", 1, "DivisionInfo", "MTK_CP_DIVISION_INFO", "DivisionId", _DivisionInfo.DivisionId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteDivisionInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region For Dropdown
        public IEnumerable<SelectListItem> GetDivisionInfoForDD()
        {
            try
            {
                var List_Division_Info = _IUoW.Repository<DivisionInfo>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.DivisionId, n.DivisionNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Division_Info)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.DivisionId,
                        Text = element.DivisionNm
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetDivisionInfoForDD()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}