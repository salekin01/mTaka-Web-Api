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
    public interface IBranchInfoService
    {
        List<BranchInfo> GetAllBranchInfo();
        BranchInfo GetBranchInfoById(string _BrId);
        BranchInfo GetBranchInfoBy(BranchInfo _BranchInfo);
        int AddBranchInfo(BranchInfo _BranchInfo);
        int UpdateBranchInfo(BranchInfo _BranchInfo);
        int DeleteBranchInfo(BranchInfo _BranchInfo);
        IEnumerable<SelectListItem> GetBranchInfoForDD();
    }
    public class BranchInfoService : IBranchInfoService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public BranchInfoService()
        {
            _IUoW = new UnitOfWork();
        }
        public BranchInfoService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        public List<BranchInfo> GetAllBranchInfo()
        {
            try
            {
                List<BranchInfo> OBJ_LIST_BranchInfo = new List<BranchInfo>();
                var _ListBranchInfo = _IUoW.Repository<BranchInfo>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.BranchId);
                foreach (var item in _ListBranchInfo)
                {
                    BranchInfo OBJ_BranchInfo = new BranchInfo();
                    CurrencyInfoService OBJ_CurrencyInfoService = new CurrencyInfoService();
                    CityInfoService OBJ_CityInfoService = new CityInfoService();
                    DistrictInfoService OBJ_DistrictInfoService = new DistrictInfoService();
                    DivisionInfoService OBJ_DivisionInfoService = new DivisionInfoService();
                    CountryInfoService OBJ_CountryInfoService = new CountryInfoService();
                    PSInfoService OBJ_PSInfoService = new PSInfoService();

                    OBJ_BranchInfo.BranchId = item.BranchId;
                    OBJ_BranchInfo.BranchNm = item.BranchNm;
                    OBJ_BranchInfo.BranchShortNm = item.BranchShortNm;
                    OBJ_BranchInfo.CurrencyId = item.CurrencyId;
                    foreach (var item1 in OBJ_CurrencyInfoService.GetCurrencyInfoForDD())
                    {
                        if (item1.Value == OBJ_BranchInfo.CurrencyId)
                        {
                            OBJ_BranchInfo.CurrencyNm = item1.Text;
                        }
                    }
                    OBJ_BranchInfo.BranchClosedFlag = item.BranchClosedFlag;
                    OBJ_BranchInfo.BranchGrade = item.BranchGrade;
                    OBJ_BranchInfo.BranchClosedDate = item.BranchClosedDate;
                    OBJ_BranchInfo.BranchIdCBClearing = item.BranchIdCBClearing;
                    OBJ_BranchInfo.BranchIdCBCL = item.BranchIdCBCL;
                    OBJ_BranchInfo.BranchIdCBSBS = item.BranchIdCBSBS;
                    OBJ_BranchInfo.BranchIdCBCIB = item.BranchIdCBCIB;
                    OBJ_BranchInfo.BranchIdCBADFX = item.BranchIdCBADFX;
                    OBJ_BranchInfo.BranchIdCBCTR = item.BranchIdCBCTR;
                    OBJ_BranchInfo.ControllingBRCSHFlag = item.ControllingBRCSHFlag;
                    OBJ_BranchInfo.ControllingBRCLGFlag = item.ControllingBRCLGFlag;
                    OBJ_BranchInfo.RuralBranchFlag = item.RuralBranchFlag;
                    OBJ_BranchInfo.UrbanBranchFlag = item.UrbanBranchFlag;
                    OBJ_BranchInfo.InsuranceVaultCashFlag = item.InsuranceVaultCashFlag;
                    OBJ_BranchInfo.InsuranceTransitCashFlag = item.InsuranceTransitCashFlag;
                    OBJ_BranchInfo.Address1 = item.Address1;
                    OBJ_BranchInfo.Address2 = item.Address2;
                    OBJ_BranchInfo.CityId = item.CityId;
                    foreach (var item1 in OBJ_CityInfoService.GetCityInfoForDD())
                    {
                        if (item1.Value == OBJ_BranchInfo.CityId)
                        {
                            OBJ_BranchInfo.CityNm = item1.Text;
                        }
                    }
                    OBJ_BranchInfo.DistrictId = item.DistrictId;
                    foreach (var item1 in OBJ_DistrictInfoService.GetDistrictInfoForDD())
                    {
                        if (item1.Value == OBJ_BranchInfo.DistrictId)
                        {
                            OBJ_BranchInfo.DistrictNm = item1.Text;
                        }
                    }
                    OBJ_BranchInfo.DivisionId = item.DivisionId;
                    foreach (var item1 in OBJ_DivisionInfoService.GetDivisionInfoForDD())
                    {
                        if (item1.Value == OBJ_BranchInfo.DivisionId)
                        {
                            OBJ_BranchInfo.DivisionNm = item1.Text;
                        }
                    }
                    OBJ_BranchInfo.CountryId = item.CountryId;
                    foreach (var item1 in OBJ_CountryInfoService.GetCountryInfoForDD())
                    {
                        if (item1.Value == OBJ_BranchInfo.CountryId)
                        {
                            OBJ_BranchInfo.CountryNm = item1.Text;
                        }
                    }
                    OBJ_BranchInfo.PoliceStationId = item.PoliceStationId;
                    foreach (var item1 in OBJ_PSInfoService.GetPSInfoForDD())
                    {
                        if (item1.Value == OBJ_BranchInfo.PoliceStationId)
                        {
                            OBJ_BranchInfo.PoliceStationNm = item1.Text;
                        }
                    }
                    OBJ_BranchInfo.Phone = item.Phone;
                    OBJ_BranchInfo.FAX = item.FAX;
                    OBJ_BranchInfo.TELEX = item.TELEX;
                    OBJ_BranchInfo.SWIFT = item.SWIFT;
                    OBJ_BranchInfo.Email = item.Email;
                    OBJ_BranchInfo.ZipCode = item.ZipCode;
                    OBJ_BranchInfo.AuthStatusId = item.AuthStatusId;
                    OBJ_BranchInfo.LastAction = item.LastAction;
                    OBJ_BranchInfo.LastUpdateDT = item.LastUpdateDT;
                    OBJ_BranchInfo.MakeBy = item.MakeBy;
                    OBJ_BranchInfo.MakeDT = item.MakeDT;
                    OBJ_BranchInfo.TransDT = item.TransDT;
                    OBJ_LIST_BranchInfo.Add(OBJ_BranchInfo);
                }
                return OBJ_LIST_BranchInfo;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllBranchInfo()", string.Empty);
                return null;
            }
        }

        public BranchInfo GetBranchInfoById(string _BrId)
        {
            try
            {
                return _IUoW.Repository<BranchInfo>().GetById(_BrId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetBranchInfoById(string)", string.Empty);
                return null;
            }
        }
        public BranchInfo GetBranchInfoBy(BranchInfo _BranchInfo)
        {
            try
            {
                if (_BranchInfo == null)
                {
                    return _BranchInfo;
                }
                return _IUoW.Repository<BranchInfo>().GetBy(x => x.BranchId == _BranchInfo.BranchId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetBranchInfoBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion

        #region Add
        public int AddBranchInfo(BranchInfo _BranchInfo)
        {
            try
            {
                var _max = _IUoW.Repository<BranchInfo>().GetMaxValue(x => x.BranchId) + 1;
                _BranchInfo.BranchId = _max.ToString().PadLeft(3, '0');
                _BranchInfo.AuthStatusId = "A";
                _BranchInfo.LastAction = "ADD";
                _BranchInfo.MakeDT = System.DateTime.Now;
                _BranchInfo.MakeBy = "mtaka";
                var result = _IUoW.Repository<BranchInfo>().Add(_BranchInfo);
                #region Auth Log
                if (result == 1)
                {
                    _IAuthLogService = new AuthLogService();
                    long _outMaxSlAuthLogDtl = 0;
                    result = _IAuthLogService.AddAuthLog(_IUoW, null, _BranchInfo, "ADD", "0001", "090101012", 1, "BranchInfo", "MTK_CP_BRANCH_INFO", "BranchId", _BranchInfo.BranchId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddBranchInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateBranchInfo(BranchInfo _BranchInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_BranchInfo.BranchId))
                {
                    IsRecordExist = _IUoW.Repository<BranchInfo>().IsRecordExist(x => x.BranchId == _BranchInfo.BranchId);
                    if (IsRecordExist)
                    {
                        var _oldBranchInfo = _IUoW.Repository<BranchInfo>().GetBy(x => x.BranchId == _BranchInfo.BranchId);
                        var _oldBranchInfoForLog = ObjectCopier.DeepCopy(_oldBranchInfo);

                        _oldBranchInfo.AuthStatusId = _BranchInfo.AuthStatusId = "U";
                        _oldBranchInfo.LastAction = _BranchInfo.LastAction = "EDT";
                        _oldBranchInfo.LastUpdateDT = _BranchInfo.LastUpdateDT = System.DateTime.Now;
                        _BranchInfo.MakeBy = "mtaka";
                        result = _IUoW.Repository<BranchInfo>().Update(_oldBranchInfo);

                        #region Testing Purpose
                        #endregion

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldBranchInfoForLog, _BranchInfo, "EDT", "0001", "090101012", 1, "BranchInfo", "MTK_CP_BRANCH_INFO", "BranchId", _BranchInfo.BranchId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateBranchInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteBranchInfo(BranchInfo _BranchInfo)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_BranchInfo.BranchId))
                {
                    IsRecordExist = _IUoW.Repository<BranchInfo>().IsRecordExist(x => x.BranchId == _BranchInfo.BranchId);
                    if (IsRecordExist)
                    {
                        var _oldBranchInfo = _IUoW.Repository<BranchInfo>().GetBy(x => x.BranchId == _BranchInfo.BranchId);
                        var _oldBranchInfoForLog = ObjectCopier.DeepCopy(_oldBranchInfo);

                        _oldBranchInfo.AuthStatusId = _BranchInfo.AuthStatusId = "U";
                        _oldBranchInfo.LastAction = _BranchInfo.LastAction = "DEL";
                        _oldBranchInfo.LastUpdateDT = _BranchInfo.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<BranchInfo>().Update(_oldBranchInfo);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldBranchInfoForLog, _BranchInfo, "DEL", "0001", "090101012", 1, "BranchInfo", "MTK_CP_BRANCH_INFO", "BranchId", _BranchInfo.BranchId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteBranchInfo(obj)", string.Empty);
                return 0;
            }
        }
        #endregion
        
        #region For Dropdown
        public IEnumerable<SelectListItem> GetBranchInfoForDD()
        {
            try
            {
                var List_Branch_Info = _IUoW.Repository<BranchInfo>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.BranchId, n.BranchNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Branch_Info)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.BranchId,
                        Text = element.BranchNm
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetBranchInfoForDD()", string.Empty);
                return null;
            }
        }
        #endregion
    }
}
