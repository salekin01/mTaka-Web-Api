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
    public interface ICountryInfoService
    {
        List<CountryInfo> GetAllCountryInfo();
        CountryInfo GetCountryInfoById(string _CountryId);
        CountryInfo GetCountryInfoBy(CountryInfo _CountryInfo);
        int AddCountryInfo(CountryInfo _CountryInfo);
        int UpdateCountryInfo(CountryInfo _CountryInfo);
        int DeleteCountryInfo(CountryInfo _CountryInfo);
        IEnumerable<SelectListItem> GetCountryInfoForDD();
    }
    public class CountryInfoService : ICountryInfoService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public CountryInfoService()
        {
            _IUoW = new UnitOfWork();
        }
        public CountryInfoService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public List<CountryInfo> GetAllCountryInfo()
        {
            try
            {
                List<CountryInfo> OBJ_LIST_CountryInfo = new List<CountryInfo>();
                var _ListCountryInfo = _IUoW.Repository<CountryInfo>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.CountryId);
                foreach (var item in _ListCountryInfo)
                {
                    CountryInfo OBJ_CountryInfo = new CountryInfo();
                    CurrencyInfoService OBJ_CurrencyInfoService = new CurrencyInfoService();

                    OBJ_CountryInfo.CountryId = item.CountryId;
                    OBJ_CountryInfo.CountryNm = item.CountryNm;
                    OBJ_CountryInfo.CountryShortNm = item.CountryShortNm;
                    OBJ_CountryInfo.ISOCode = item.ISOCode;
                    OBJ_CountryInfo.CBCode = item.CBCode;
                    OBJ_CountryInfo.NationalityName = item.NationalityName;
                    OBJ_CountryInfo.CurrencyId = item.CurrencyId;
                    foreach (var item1 in OBJ_CurrencyInfoService.GetCurrencyInfoForDD())
                    {
                        if (item1.Value == OBJ_CountryInfo.CurrencyId)
                        {
                            OBJ_CountryInfo.CurrencyNm = item1.Text;
                        }
                    }
                    OBJ_CountryInfo.NativeCountryFlag = item.NativeCountryFlag;
                    OBJ_CountryInfo.AuthStatusId = item.AuthStatusId;
                    OBJ_CountryInfo.LastAction = item.LastAction;
                    OBJ_CountryInfo.LastUpdateDT = item.LastUpdateDT;
                    OBJ_CountryInfo.MakeBy = item.MakeBy;
                    OBJ_CountryInfo.MakeDT = item.MakeDT;
                    OBJ_CountryInfo.TransDT = item.TransDT;
                    OBJ_LIST_CountryInfo.Add(OBJ_CountryInfo);
                }
                return OBJ_LIST_CountryInfo;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllCountryInfo()", string.Empty);
                return null;
            }
        }

        public CountryInfo GetCountryInfoById(string _CountryId)
        {
            try
            {
                return _IUoW.Repository<CountryInfo>().GetById(_CountryId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCountryInfoById(string)", string.Empty);
                return null;
            }
        }
        public CountryInfo GetCountryInfoBy(CountryInfo _CountryInfo)
        {
            try
            {
                if (_CountryInfo == null)
                {
                    return _CountryInfo;
                }
                return _IUoW.Repository<CountryInfo>().GetBy(x => x.CountryId == _CountryInfo.CountryId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCountryInfoBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddCountryInfo(CountryInfo _CountryInfo)
        {
            try
            {
                var _max = _IUoW.Repository<CountryInfo>().GetMaxValue(x => x.CountryId) + 1;
                _CountryInfo.CountryId = _max.ToString().PadLeft(3, '0');
                _CountryInfo.AuthStatusId = "A";
                _CountryInfo.LastAction = "ADD";
                _CountryInfo.MakeDT = System.DateTime.Now;
                _CountryInfo.MakeBy = "mtaka";
                var result = _IUoW.Repository<CountryInfo>().Add(_CountryInfo);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _CountryInfo, "ADD", "0001", "090101002", 1, "CountryInfo", "MTK_CP_COUNTRY_INFO", "CountryId", _CountryInfo.CountryId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddCountryInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateCountryInfo(CountryInfo _CountryInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_CountryInfo.CountryId))
                {
                    IsRecordExist = _IUoW.Repository<CountryInfo>().IsRecordExist(x => x.CountryId == _CountryInfo.CountryId);
                    if (IsRecordExist)
                    {
                        var _oldCountryInfo = _IUoW.Repository<CountryInfo>().GetBy(x => x.CountryId == _CountryInfo.CountryId);
                        var _oldCountryInfoForLog = ObjectCopier.DeepCopy(_oldCountryInfo);

                        _oldCountryInfo.AuthStatusId = _CountryInfo.AuthStatusId = "U";
                        _oldCountryInfo.LastAction = _CountryInfo.LastAction = "EDT";
                        _oldCountryInfo.LastUpdateDT = _CountryInfo.LastUpdateDT = System.DateTime.Now;
                        _CountryInfo.MakeBy = "mtaka";
                        result = _IUoW.Repository<CountryInfo>().Update(_oldCountryInfo);

                        #region Testing Purpose
                        #endregion

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldCountryInfoForLog, _CountryInfo, "EDT", "0001", "090101002", 1, "CountryInfo", "MTK_CP_COUNTRY_INFO", "CountryId", _CountryInfo.CountryId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateCountryInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteCountryInfo(CountryInfo _CountryInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_CountryInfo.CountryId))
                {
                    IsRecordExist = _IUoW.Repository<CountryInfo>().IsRecordExist(x => x.CountryId == _CountryInfo.CountryId);
                    if (IsRecordExist)
                    {
                        var _oldCountryInfo = _IUoW.Repository<CountryInfo>().GetBy(x => x.CountryId == _CountryInfo.CountryId);
                        var _oldCountryInfoForLog = ObjectCopier.DeepCopy(_oldCountryInfo);

                        _oldCountryInfo.AuthStatusId = _CountryInfo.AuthStatusId = "U";
                        _oldCountryInfo.LastAction = _CountryInfo.LastAction = "DEL";
                        _oldCountryInfo.LastUpdateDT = _CountryInfo.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<CountryInfo>().Update(_oldCountryInfo);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldCountryInfoForLog, _CountryInfo, "DEL", "0001", "090101002", 1, "CountryInfo", "MTK_CP_COUNTRY_INFO", "CountryId", _CountryInfo.CountryId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteCountryInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion
        
        #region For Dropdown
        public IEnumerable<SelectListItem> GetCountryInfoForDD()
        {
            try
            {
                var List_Country_Info = _IUoW.Repository<CountryInfo>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.CountryId, n.CountryNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Country_Info)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.CountryId,
                        Text = element.CountryNm
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCountryInfoForDD()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}
