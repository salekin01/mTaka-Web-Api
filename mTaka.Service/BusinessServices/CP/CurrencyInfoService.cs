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
    public interface ICurrencyInfoService
    {
        List<CurrencyInfo> GetAllCurrencyInfo();
        CurrencyInfo GetCurrencyInfoById(string _CurrencyId);
        CurrencyInfo GetCurrencyInfoBy(CurrencyInfo _CurrencyInfo);
        int AddCurrencyInfo(CurrencyInfo _CurrencyInfo);
        int UpdateCurrencyInfo(CurrencyInfo _CurrencyInfo);
        int DeleteCurrencyInfo(CurrencyInfo _CurrencyInfo);
        IEnumerable<SelectListItem> GetCurrencyInfoForDD();
    }
    public class CurrencyInfoService : ICurrencyInfoService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public CurrencyInfoService()
        {
            _IUoW = new UnitOfWork();
        }
        public CurrencyInfoService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public List<CurrencyInfo> GetAllCurrencyInfo()
        {
            try
            {
                List<CurrencyInfo> OBJ_LIST_CurrencyInfo = new List<CurrencyInfo>();
                var _ListCurrencyInfo = _IUoW.Repository<CurrencyInfo>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.CurrencyId);
                foreach (var item in _ListCurrencyInfo)
                {
                    CurrencyInfo OBJ_CurrencyInfo = new CurrencyInfo();
                    DivisionInfoService OBJ_DivisionInfoService = new DivisionInfoService();

                    OBJ_CurrencyInfo.CurrencyId = item.CurrencyId;
                    OBJ_CurrencyInfo.CurrencyNm = item.CurrencyNm;
                    OBJ_CurrencyInfo.CurrencyShortNm = item.CurrencyShortNm;
                    OBJ_CurrencyInfo.CurrencyReportNm = item.CurrencyReportNm;
                    OBJ_CurrencyInfo.CurrencyDecimalNm = item.CurrencyDecimalNm;
                    OBJ_CurrencyInfo.CBCode = item.CBCode;
                    OBJ_CurrencyInfo.InternationalName = item.InternationalName;
                    OBJ_CurrencyInfo.BaseCurrencyConvertFlag = item.BaseCurrencyConvertFlag;
                    OBJ_CurrencyInfo.LocalVariable = item.LocalVariable;
                    OBJ_CurrencyInfo.AuthStatusId = item.AuthStatusId;
                    OBJ_CurrencyInfo.LastAction = item.LastAction;
                    OBJ_CurrencyInfo.LastUpdateDT = item.LastUpdateDT;
                    OBJ_CurrencyInfo.MakeBy = item.MakeBy;
                    OBJ_CurrencyInfo.MakeDT = item.MakeDT;
                    OBJ_CurrencyInfo.TransDT = item.TransDT;
                    OBJ_LIST_CurrencyInfo.Add(OBJ_CurrencyInfo);
                }
                return OBJ_LIST_CurrencyInfo;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllCurrencyInfo()", string.Empty);
                return null;
            }
        }

        public CurrencyInfo GetCurrencyInfoById(string _CurrencyId)
        {
            try
            {
                return _IUoW.Repository<CurrencyInfo>().GetById(_CurrencyId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCurrencyInfoById(string)", string.Empty);
                return null;
            }
        }
        public CurrencyInfo GetCurrencyInfoBy(CurrencyInfo _CurrencyInfo)
        {
            try
            {
                if (_CurrencyInfo == null)
                {
                    return _CurrencyInfo;
                }
                return _IUoW.Repository<CurrencyInfo>().GetBy(x => x.CurrencyId == _CurrencyInfo.CurrencyId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCurrencyInfoBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddCurrencyInfo(CurrencyInfo _CurrencyInfo)
        {
            try
            {
                var _max = _IUoW.Repository<CurrencyInfo>().GetMaxValue(x => x.CurrencyId) + 1;
                _CurrencyInfo.CurrencyId = _max.ToString().PadLeft(3, '0');
                _CurrencyInfo.AuthStatusId = "A";
                _CurrencyInfo.LastAction = "ADD";
                _CurrencyInfo.MakeDT = System.DateTime.Now;
                _CurrencyInfo.MakeBy = "mtaka";
                var result = _IUoW.Repository<CurrencyInfo>().Add(_CurrencyInfo);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _CurrencyInfo, "ADD", "0001", "090101001", 1, "CurrencyInfo", "MTK_CP_CURRENCY_INFO", "CurrencyId", _CurrencyInfo.CurrencyId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddCurrencyInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateCurrencyInfo(CurrencyInfo _CurrencyInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_CurrencyInfo.CurrencyId))
                {
                    IsRecordExist = _IUoW.Repository<CurrencyInfo>().IsRecordExist(x => x.CurrencyId == _CurrencyInfo.CurrencyId);
                    if (IsRecordExist)
                    {
                        var _oldCurrencyInfo = _IUoW.Repository<CurrencyInfo>().GetBy(x => x.CurrencyId == _CurrencyInfo.CurrencyId);
                        var _oldCurrencyInfoForLog = ObjectCopier.DeepCopy(_oldCurrencyInfo);

                        _oldCurrencyInfo.AuthStatusId = _CurrencyInfo.AuthStatusId = "U";
                        _oldCurrencyInfo.LastAction = _CurrencyInfo.LastAction = "EDT";
                        _oldCurrencyInfo.LastUpdateDT = _CurrencyInfo.LastUpdateDT = System.DateTime.Now;
                        _CurrencyInfo.MakeBy = "mtaka";
                        result = _IUoW.Repository<CurrencyInfo>().Update(_oldCurrencyInfo);

                        #region Testing Purpose
                        #endregion

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldCurrencyInfoForLog, _CurrencyInfo, "EDT", "0001", "090101001", 1, "CurrencyInfo", "MTK_CP_CURRENCY_INFO", "CurrencyId", _CurrencyInfo.CurrencyId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateCurrencyInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteCurrencyInfo(CurrencyInfo _CurrencyInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_CurrencyInfo.CurrencyId))
                {
                    IsRecordExist = _IUoW.Repository<CurrencyInfo>().IsRecordExist(x => x.CurrencyId == _CurrencyInfo.CurrencyId);
                    if (IsRecordExist)
                    {
                        var _oldCurrencyInfo = _IUoW.Repository<CurrencyInfo>().GetBy(x => x.CurrencyId == _CurrencyInfo.CurrencyId);
                        var _oldCurrencyInfoForLog = ObjectCopier.DeepCopy(_oldCurrencyInfo);

                        _oldCurrencyInfo.AuthStatusId = _CurrencyInfo.AuthStatusId = "U";
                        _oldCurrencyInfo.LastAction = _CurrencyInfo.LastAction = "DEL";
                        _oldCurrencyInfo.LastUpdateDT = _CurrencyInfo.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<CurrencyInfo>().Update(_oldCurrencyInfo);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldCurrencyInfoForLog, _CurrencyInfo, "DEL", "0001", "090101001", 1, "CurrencyInfo", "MTK_CP_CURRENCY_INFO", "CurrencyId", _CurrencyInfo.CurrencyId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteCurrencyInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region For Dropdown
        public IEnumerable<SelectListItem> GetCurrencyInfoForDD()
        {
            try
            {
                var List_Currency_Info = _IUoW.Repository<CurrencyInfo>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.CurrencyId, n.CurrencyNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Currency_Info)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.CurrencyId,
                        Text = element.CurrencyNm
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCurrencyInfoForDD()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}