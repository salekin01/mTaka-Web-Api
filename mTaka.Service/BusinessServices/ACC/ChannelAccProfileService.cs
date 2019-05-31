using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.BusinessEntities.LEDGER;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.BusinessServices.SP;
using mTaka.Service.Common;
using mTaka.Service.OtherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;
using mTaka.Service.BusinessServices.CP;

namespace mTaka.Service.BusinessServices.ACC
{
    public interface IChannelAccProfileService
    {
        List<ChannelAccProfile> GetAllChannelAccProfile();
        ChannelAccProfile GetChannelAccProfileById(string _AccountProfileId);
        ChannelAccProfile GetChannelAccProfileBy(ChannelAccProfile _ChannelAccProfile);
        string AddChannelAccProfile(ChannelAccProfile _ChannelAccProfile);
        int UpdateChannelAccProfile(ChannelAccProfile _ChannelAccProfile);
        int DeleteChannelAccProfile(ChannelAccProfile _ChannelAccProfile);
        IEnumerable<SelectListItem> GetChannelAccProfileForDD();
        string IsChannelAccNumberExist(ChannelAccProfile _ChannelAccProfile);

        ChannelAccProfile GetChannelInfobyWalletAccNo(string WalletAccNo);
    }
    public class ChannelAccProfileService : IChannelAccProfileService
    {
        private AccMaster _AccInfo = null;
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        ErrorLogService _ObjErrorLogService = null;
        public ChannelAccProfileService()
        {
            _IUoW = new UnitOfWork();
        }
        public ChannelAccProfileService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }

        #region Index
        //public IEnumerable<ChannelAccProfile> GetAllChannelAccProfile()
        //{
        //    try
        //    {
        //        var _ListChannelAccProfile = _IUoW.mTakaDbQuery().GetAllChannelAccProfile_LQ();
        //        return _ListChannelAccProfile;
        //    }
        //    catch (Exception ex)
        //    {
        //        _ObjErrorLogService = new ErrorLogService();
        //        _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllChannelAccProfile()", string.Empty);
        //        return null;
        //    }
        //}
        public List<ChannelAccProfile> GetAllChannelAccProfile()
        {
            try
            {
                List<ChannelAccProfile> OBJ_LIST_ChannelAccProfile = new List<ChannelAccProfile>();
                var _ListChannelAccProfile = _IUoW.Repository<ChannelAccProfile>().Get(x => x.AuthStatusId == "A" && x.LastAction != "DEL").OrderByDescending(x => x.AccountProfileId);
                foreach (var item in _ListChannelAccProfile)
                {
                    ChannelAccProfile OBJ_ChannelAccProfile = new ChannelAccProfile();
                    ChannelAccProfileService OBJ_ChannelAccProfileService = new ChannelAccProfileService();
                    AccCategoryService OBJ_AccCategoryService = new AccCategoryService();
                    AccTypeService OBJ_AccTypeService = new AccTypeService();
                    CustomerAccProfileService OBJ_CustomerAccProfileService = new CustomerAccProfileService();
                    CountryInfoService OBJ_CountryInfoService = new CountryInfoService();
                    CityInfoService OBJ_CityInfoService = new CityInfoService();
                    DistrictInfoService OBJ_DistrictInfoService = new DistrictInfoService();
                    PSInfoService OBJ_PSInfoService = new PSInfoService();
                    AreaInfoService OBJ_AreaInfoService = new AreaInfoService();
                    BankInfoService OBJ_BankInfoService = new BankInfoService();
                    BranchInfoService OBJ_BranchInfoService = new BranchInfoService();
                    AccStatusSetupService OBJ_AccStatusSetupService = new AccStatusSetupService();
                    ManagerTypeService OBJ_ManagerTypeService = new ManagerTypeService();
                    ManagerAccProfileService OBJ_ManagerProfileService = new ManagerAccProfileService();

                    OBJ_ChannelAccProfile.AccountProfileId = item.AccountProfileId;
                    ////OBJ_ChannelAccProfile.AccountCategoryId = item.AccountCategoryId;
                    ////foreach (var item1 in OBJ_AccCategoryService.GetAccCategoryForDD())
                    ////{
                    ////    if (item1.Value == OBJ_ChannelAccProfile.AccountCategoryId)
                    ////    {
                    ////        OBJ_ChannelAccProfile.AccountCategoryNm = item1.Text;
                    ////    }
                    ////}
                    OBJ_ChannelAccProfile.AccountTypeId = item.AccountTypeId;
                    foreach (var item1 in OBJ_AccTypeService.GetAccTypeForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.AccountTypeId)
                        {
                            OBJ_ChannelAccProfile.AccountTypeNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.WalletAccountNo = item.WalletAccountNo;
                    OBJ_ChannelAccProfile.UserName = item.UserName;
                    OBJ_ChannelAccProfile.FatherNm = item.FatherNm;
                    OBJ_ChannelAccProfile.MotherNm = item.MotherNm;
                    OBJ_ChannelAccProfile.DateofBirth = item.DateofBirth;
                    OBJ_ChannelAccProfile.NationalityId = item.NationalityId;
                    OBJ_ChannelAccProfile.Gender = item.Gender;
                    foreach (var item1 in OBJ_CustomerAccProfileService.GetGender())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.Gender)
                        {
                            OBJ_ChannelAccProfile.GenderNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.TAXIdNo = item.TAXIdNo;
                    OBJ_ChannelAccProfile.PassportNo = item.PassportNo;
                    OBJ_ChannelAccProfile.PresentAddress1 = item.PresentAddress1;
                    OBJ_ChannelAccProfile.PresentAddress2 = item.PresentAddress2;
                    OBJ_ChannelAccProfile.PresentCountryId = item.PresentCountryId;
                    foreach (var item1 in OBJ_CountryInfoService.GetCountryInfoForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.PresentCountryId)
                        {
                            OBJ_ChannelAccProfile.PresentCountryNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.PresentCityId = item.PresentCityId;
                    foreach (var item1 in OBJ_CityInfoService.GetCityInfoForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.PresentCityId)
                        {
                            OBJ_ChannelAccProfile.PresentCityNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.PresentDistrictId = item.PresentDistrictId;
                    foreach (var item1 in OBJ_DistrictInfoService.GetDistrictInfoForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.PresentDistrictId)
                        {
                            OBJ_ChannelAccProfile.PresentDistrictNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.PresentPoliceStationId = item.PresentPoliceStationId;
                    foreach (var item1 in OBJ_PSInfoService.GetPSInfoForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.PresentPoliceStationId)
                        {
                            OBJ_ChannelAccProfile.PresentPoliceStationNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.PresentAreaId = item.PresentAreaId;
                    foreach (var item1 in OBJ_AreaInfoService.GetAreaInfoForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.PresentAreaId)
                        {
                            OBJ_ChannelAccProfile.PresentAreaNm = item1.Text;
                        }
                    }
                    //OBJ_ChannelAccProfile.PresentPhoneNo = item.PresentPhoneNo;
                    OBJ_ChannelAccProfile.PermanentAddress1 = item.PermanentAddress1;
                    OBJ_ChannelAccProfile.PermanentAddress2 = item.PermanentAddress2;
                    OBJ_ChannelAccProfile.PermanentCountryId = item.PermanentCountryId;
                    foreach (var item1 in OBJ_CountryInfoService.GetCountryInfoForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.PermanentCountryId)
                        {
                            OBJ_ChannelAccProfile.PermanentCountryNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.PermanentCityId = item.PermanentCityId;
                    foreach (var item1 in OBJ_CityInfoService.GetCityInfoForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.PermanentCityId)
                        {
                            OBJ_ChannelAccProfile.PermanentCityNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.PermanentDistrictId = item.PermanentDistrictId;
                    foreach (var item1 in OBJ_DistrictInfoService.GetDistrictInfoForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.PermanentDistrictId)
                        {
                            OBJ_ChannelAccProfile.PermanentDistrictNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.PermanentPoliceStationId = item.PermanentPoliceStationId;
                    foreach (var item1 in OBJ_PSInfoService.GetPSInfoForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.PermanentPoliceStationId)
                        {
                            OBJ_ChannelAccProfile.PermanentPoliceStationNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.PermanentAreaId = item.PermanentAreaId;
                    foreach (var item1 in OBJ_AreaInfoService.GetAreaInfoForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.PermanentAreaId)
                        {
                            OBJ_ChannelAccProfile.PermanentAreaNm = item1.Text;
                        }
                    }
                    //OBJ_ChannelAccProfile.PermanentPhoneNo = item.PermanentPhoneNo;
                    OBJ_ChannelAccProfile.BankId = item.BankId;
                    foreach (var item1 in OBJ_BankInfoService.GetBankInfoForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.BankId)
                        {
                            OBJ_ChannelAccProfile.BankNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.BranchId = item.BranchId;
                    foreach (var item1 in OBJ_BranchInfoService.GetBranchInfoForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.BranchId)
                        {
                            OBJ_ChannelAccProfile.BranchNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.BankAccountNo = item.BankAccountNo;
                    OBJ_ChannelAccProfile.ParentAccountTypeId = item.ParentAccountTypeId;
                    foreach (var item1 in OBJ_AccTypeService.GetAccTypeForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.ParentAccountTypeId)
                        {
                            OBJ_ChannelAccProfile.ParentAccountTypeNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.ParentAccountProfileId = item.ParentAccountProfileId;
                    foreach (var item1 in OBJ_ChannelAccProfileService.GetChannelAccProfileForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.ParentAccountProfileId)
                        {
                            OBJ_ChannelAccProfile.ParentChannelAccProfileNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.CompanyNm = item.CompanyNm;
                    OBJ_ChannelAccProfile.Occupation = item.Occupation;
                    OBJ_ChannelAccProfile.NationalIdNo = item.NationalIdNo;
                    OBJ_ChannelAccProfile.VatRegistrationNo = item.VatRegistrationNo;
                    OBJ_ChannelAccProfile.AccountStatusId = item.AccountStatusId;
                    foreach (var item1 in OBJ_AccStatusSetupService.GetAccStatusSetupForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.AccountStatusId)
                        {
                            OBJ_ChannelAccProfile.AccountStatusName = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.TradeLicenseNo = item.TradeLicenseNo;
                    ////OBJ_ChannelAccProfile.ManagerTypeId = item.ManagerTypeId;
                    ////foreach (var item1 in OBJ_ManagerTypeService.GetManagerTypeForDD())
                    ////{
                    ////    if (item1.Value == OBJ_ChannelAccProfile.ManagerTypeId)
                    ////    {
                    ////        OBJ_ChannelAccProfile.ManagerTypeNm = item1.Text;
                    ////    }
                    ////}
                    OBJ_ChannelAccProfile.ManagerAccountProfileId = item.ManagerAccountProfileId;
                    foreach (var item1 in OBJ_ManagerProfileService.GetManagerForDD())
                    {
                        if (item1.Value == OBJ_ChannelAccProfile.ManagerAccountProfileId)
                        {
                            OBJ_ChannelAccProfile.ManagerProfileNm = item1.Text;
                        }
                    }
                    OBJ_ChannelAccProfile.AuthStatusId = item.AuthStatusId;
                    OBJ_ChannelAccProfile.LastAction = item.LastAction;
                    OBJ_ChannelAccProfile.LastUpdateDT = item.LastUpdateDT;
                    OBJ_ChannelAccProfile.MakeBy = item.MakeBy;
                    OBJ_ChannelAccProfile.MakeDT = item.MakeDT;
                    OBJ_ChannelAccProfile.TransDT = item.TransDT;
                    OBJ_LIST_ChannelAccProfile.Add(OBJ_ChannelAccProfile);
                }
                return OBJ_LIST_ChannelAccProfile;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllChannelAccProfile()", string.Empty);
                throw ex;
            }
        }
        public ChannelAccProfile GetChannelAccProfileById(string _AccountProfileId)
        {
            try
            {
                return _IUoW.Repository<ChannelAccProfile>().GetById(_AccountProfileId);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetChannelAccProfileById(string)", string.Empty);
                throw ex;
            }
        }
        public ChannelAccProfile GetChannelAccProfileBy(ChannelAccProfile _ChannelAccProfile)
        {
            try
            {
                if (_ChannelAccProfile == null)
                {
                    return _ChannelAccProfile;
                }
                return _IUoW.Repository<ChannelAccProfile>().GetBy(x => x.AccountProfileId == _ChannelAccProfile.AccountProfileId &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetChannelAccProfileBy(obj)", string.Empty);
                throw ex;
            }
        }
        #endregion

        #region Add
        public string AddChannelAccProfile(ChannelAccProfile _ChannelAccProfile)
        {
            int result = 0;
            string MonitoringId = "2";
            string MainResult = string.Empty;
            Random random = new Random();
            ChannelAccProfileService OBJ_ChannelAccProfileService = new ChannelAccProfileService();
            try
            {
                var duplicateCheck = OBJ_ChannelAccProfileService.IsChannelAccNumberExist(_ChannelAccProfile);
                if (duplicateCheck == "NotExist")
                {
                    var _max = _IUoW.Repository<ChannelAccProfile>().GetMaxValue(x => x.AccountProfileId);
                    if (_max > 0)
                        _ChannelAccProfile.AccountProfileId = (_max + 1).ToString();
                    else
                        _ChannelAccProfile.AccountProfileId = MonitoringId + (_max + 1).ToString().PadLeft(8, '0');
                   
                    _ChannelAccProfile.SystemAccountNo = Guid.NewGuid().ToString();
                    _ChannelAccProfile.AuthStatusId = "U";
                    _ChannelAccProfile.LastAction = "ADD";
                    _ChannelAccProfile.AccountStatusId = "001";
                    _ChannelAccProfile.MakeDT = System.DateTime.Now;
                    _ChannelAccProfile.MakeBy = "prova";
                    result = _IUoW.Repository<ChannelAccProfile>().Add(_ChannelAccProfile);
                    #region Add Account Info
                    if (result == 1)
                    {
                        _AccInfo = new AccMaster();
                        var _maxAccInfoId = _IUoW.Repository<AccMaster>().GetMaxValue(x => x.AccountId) + 1;
                        _AccInfo.AccountId = _maxAccInfoId.ToString().PadLeft(3, '0');
                        //_AccInfo.AccProfileId = _ChannelAccProfile.AccountProfileId;
                        _AccInfo.WalletAccountNo = _ChannelAccProfile.WalletAccountNo;
                        _AccInfo.SystemAccountNo = _ChannelAccProfile.SystemAccountNo;
                        _AccInfo.AccNm = _ChannelAccProfile.UserName;
                        _AccInfo.AccTypeId = _ChannelAccProfile.AccountTypeId;
                        _AccInfo.BankAccountNo = _ChannelAccProfile.BankAccountNo;
                        _AccInfo.TransDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
                        _AccInfo.AccountStatusId = "001";
                        _AccInfo.AuthStatusId = "U";
                        _AccInfo.LastAction = "ADD";
                        _AccInfo.MakeDT = System.DateTime.Now;
                        _AccInfo.MakeBy = "prova";
                        result = _IUoW.Repository<AccMaster>().Add(_AccInfo);
                        //if (result == 1)
                        //{
                        //    _IAuthLogService = new AuthLogService();
                        //    long _outMaxSlAuthLogDtl = 0;
                        //    result = _IAuthLogService.AddAuthLog(_IUoW, null, _ChannelAccProfile, "ADD", "0001", "090103002", 1, "MTK_ACC_CHANNEL_PROFILE", "AccountProfileId", _ChannelAccProfile.AccountProfileId, "prova", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        //}
                    }
                    #endregion
                    #region Auth Log
                    if (result == 1)
                    {
                        _IAuthLogService = new AuthLogService();
                        long _outMaxSlAuthLogDtl = 0;
                        result = _IAuthLogService.AddAuthLog(_IUoW, null, _ChannelAccProfile, "ADD", "0001", _ChannelAccProfile.FunctionId, 1, "ChannelAccProfile", "MTK_ACC_CHANNEL_PROFILE", "AccountProfileId", _ChannelAccProfile.AccountProfileId, _ChannelAccProfile.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                    }
                    #endregion                    
                    if (result == 1)
                    {
                        _IUoW.Commit();
                    }
                    MainResult = result + ":" + "Successfull";
                    return MainResult;
                }
                else
                {
                    MainResult = result + ":" + "Account number already exists..";
                    return MainResult;
                }                  
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddChannelAccProfile(obj)", string.Empty);
                MainResult = result + ":" + "NotSuccessfull";
                return MainResult;
            }
        }
        #endregion

        #region Edit
        public int UpdateChannelAccProfile(ChannelAccProfile _ChannelAccProfile)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_ChannelAccProfile.AccountProfileId))
                {
                    IsRecordExist = _IUoW.Repository<ChannelAccProfile>().IsRecordExist(x => x.AccountProfileId == _ChannelAccProfile.AccountProfileId);
                    if (IsRecordExist)
                    {
                        var _oldChannelAccProfile = _IUoW.Repository<ChannelAccProfile>().GetBy(x => x.AccountProfileId == _ChannelAccProfile.AccountProfileId);
                        var _oldChannelAccProfileForLog = ObjectCopier.DeepCopy(_oldChannelAccProfile);

                        _oldChannelAccProfile.AuthStatusId = _ChannelAccProfile.AuthStatusId = "U";
                        _oldChannelAccProfile.LastAction = _ChannelAccProfile.LastAction = "EDT";
                        _oldChannelAccProfile.LastUpdateDT = _ChannelAccProfile.LastUpdateDT = System.DateTime.Now;
                        _ChannelAccProfile.MakeBy = "prova";
                        result = _IUoW.Repository<ChannelAccProfile>().Update(_oldChannelAccProfile);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldChannelAccProfileForLog, _ChannelAccProfile, "EDT", "0001", _ChannelAccProfile.FunctionId, 1, "ChannelAccProfile", "MTK_ACC_CHANNEL_PROFILE", "AccountProfileId", _ChannelAccProfile.AccountProfileId, _ChannelAccProfile.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateChannelAccProfile(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteChannelAccProfile(ChannelAccProfile _ChannelAccProfile)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_ChannelAccProfile.AccountProfileId))
                {
                    IsRecordExist = _IUoW.Repository<ChannelAccProfile>().IsRecordExist(x => x.AccountProfileId == _ChannelAccProfile.AccountProfileId);
                    if (IsRecordExist)
                    {
                        var _oldChannelAccProfile = _IUoW.Repository<ChannelAccProfile>().GetBy(x => x.AccountProfileId == _ChannelAccProfile.AccountProfileId);
                        var _oldChannelAccProfileForLog = ObjectCopier.DeepCopy(_oldChannelAccProfile);

                        _oldChannelAccProfile.AuthStatusId = _ChannelAccProfile.AuthStatusId = "U";
                        _oldChannelAccProfile.LastAction = _ChannelAccProfile.LastAction = "DEL";
                        _oldChannelAccProfile.LastUpdateDT = _ChannelAccProfile.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<ChannelAccProfile>().Update(_oldChannelAccProfile);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldChannelAccProfileForLog, _ChannelAccProfile, "DEL", "0001", _ChannelAccProfile.FunctionId, 1, "ChannelAccProfile", "MTK_ACC_CHANNEL_PROFILE", "AccountProfileId", _ChannelAccProfile.AccountProfileId, _ChannelAccProfile.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteChannelAccProfile(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Dropdown
        public IEnumerable<SelectListItem> GetChannelAccProfileForDD()
        {
            try
            {
                var List_Channel_Profile = _IUoW.Repository<ChannelAccProfile>().GetBy(x => x.AuthStatusId == "A" &&
                                                                             x.LastAction != "DEL", n => new { n.AccountProfileId, n.UserName });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Channel_Profile)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.AccountProfileId,
                        Text = element.UserName
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetChannelAccProfileForDD()", string.Empty);
                return null;
            }
        }
        #endregion

        #region IsChannelAccNumber
        public string IsChannelAccNumberExist(ChannelAccProfile _ChannelAccProfile)
        {
            try
            {
                var  ChannelAcc_Profile = _IUoW.Repository<ChannelAccProfile>().GetBy(x => (x.WalletAccountNo == _ChannelAccProfile.WalletAccountNo) ||
                                                                                       (x.SystemAccountNo == _ChannelAccProfile.SystemAccountNo) &&
                                                                                        x.AuthStatusId == "A" && x.LastAction != "DEL");
                if(ChannelAcc_Profile == null)
                {
                    return "NotExist";
                }
                return "Exist";
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "IsChannelAccNumberExist(obj)", string.Empty);
                throw ex;
            }
        }
        #endregion

        #region GetChannelInfobyWalletAccNo
        public ChannelAccProfile GetChannelInfobyWalletAccNo(string WalletAccNo)
        {
            try
            {
                return _IUoW.Repository<ChannelAccProfile>().GetBy(x=>x.WalletAccountNo==WalletAccNo);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetChannelInfobyWalletAccNo(string)", string.Empty);
                return null;
            }
        }
        #endregion
    }
}