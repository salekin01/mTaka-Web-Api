using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.AUTH;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Service.Common;
using mTaka.Service.OtherServices;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.WebPages.Html;

namespace mTaka.Service.BusinessServices.ACC
{
    public interface ICustomerAccProfileService
    {
        IEnumerable<CustomerAccProfile> GetAllCustomer();
        IEnumerable<CustomerAccProfile> GetCustomerById(CustomerAccProfile _CustomerProfile);
        IEnumerable<CustomerAccProfile> GetCustomerBy(CustomerAccProfile _Customer);
        int AddCustomer(CustomerAccProfile _Customer, APIServiceRequest _requestedDataObject);
        int UpdateCustomer(CustomerAccProfile _Customer);
        int DeleteCustomer(CustomerAccProfile _Customer);
        IEnumerable<SelectListItem> GetGender();
        IEnumerable<SelectListItem> GetAddress();
        CustomerAccProfile GetCustomerAccProfileInfo(string AccountNo);
        //IEnumerable<CustomerAccProfile> UserInfo(CustomerAccProfile _Customer);

        IEnumerable<SelectListItem> AccTypeWiseCustomer(string AccTypeId);

    }

    public class CustomerAccProfileService : ICustomerAccProfileService
    {
        private IUnitOfWork _IUoW = null;
        private IAuthLogService _IAuthLogService = null;
        private AccMaster _AccInfo = null;
        ErrorLogService _ObjErrorLogService = null;
        public CustomerAccProfileService()
        {
            _IUoW = new UnitOfWork();
        }
        public CustomerAccProfileService(IUnitOfWork _IUnitOfWork)
        {
            this._IUoW = _IUnitOfWork;
        }



        #region Index
        public IEnumerable<CustomerAccProfile> GetAllCustomer()
        {
            try
            {
                var _ListCustomerProfile = _IUoW.Repository<CustomerAccProfile>().Get(x => x.AuthStatusId == "A" &&
                                                                        x.LastAction != "DEL").OrderByDescending(x => x.AccountProfileId);
                return _ListCustomerProfile;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAllCustomer()", string.Empty);
                return null;
                //throw ex;
            }
        }

        public IEnumerable<CustomerAccProfile> GetCustomerById(CustomerAccProfile _CustomerProfile)
        {
            try
            {
                return _IUoW.mTakaDbQuery().IndCustomerInfo_LQ(_CustomerProfile);
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCustomerById(string)", string.Empty);
                return null;
            }
        }

        public IEnumerable<CustomerAccProfile> GetCustomerBy(CustomerAccProfile _Customer)
        {
            try
            {
                var _UserInfo = _IUoW.Repository<CustomerAccProfile>().Get(x => x.WalletAccountNo == _Customer.WalletAccountNo &&
                                                                            x.AuthStatusId == "A" &&
                                                                            x.LastAction != "DEL");

                return _UserInfo;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetCustomerBy(obj)", string.Empty);
                return null;
            }
        }
        #endregion
        
        #region Add
        public int AddCustomer(CustomerAccProfile _Customer, APIServiceRequest _requestedDataObject)
        {
            try
            {
                string FunctionId = "090103003";
                string FunctionName = "CustomerAccProfile";
                string MainAuthFlag = string.Empty;
                string MonitoringId = "3";

                var _max = _IUoW.Repository<CustomerAccProfile>().GetMaxValue(x => x.AccountProfileId);
                if (_max > 0)
                    _Customer.AccountProfileId = (_max + 1).ToString();
                else
                    _Customer.AccountProfileId = MonitoringId + (_max + 1).ToString().PadLeft(8, '0');

                if (_Customer.sameAsPeranent == "True")
                {
                    _Customer.PermanentAddress1 = _Customer.PresentAddress1;
                    _Customer.PermanentAddress2 = _Customer.PresentAddress2;
                    _Customer.PermanentCountry = _Customer.CountryId;
                    _Customer.PermanentDistrict = _Customer.PresentDistrict;
                    _Customer.PermanentArea = _Customer.PresentArea;
                    _Customer.PermanentCity = _Customer.PresentCity;
                    _Customer.PermanentThana = _Customer.PresentThana;
                    //_Customer.PermanentPhone = _Customer.PresentPhone;
                }
                //else { 
                //_Customer.AuthStatusId = "U";
                //_Customer.LastAction = "ADD";
                //_Customer.AccountStatusId = "R";
                //_Customer.MakeDT = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                //_Customer.MakeBy = "mtaka";
                //}
                _Customer.SystemAccountNo = Guid.NewGuid().ToString();
                _Customer.AuthStatusId = "U";
                _Customer.LastAction = "ADD";
                _Customer.AccountStatusId = "001";
                _Customer.MakeDT = System.DateTime.Now;
                _Customer.MakeBy = "mtaka";
                var result = _IUoW.Repository<CustomerAccProfile>().Add(_Customer);
                
                #region Auth Log
                if (result == 1)
                {
                    string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetAuthPermissionByFunctionId/" + FunctionId + "/" + FunctionName + "?format=json";
                    using (WebClient wc = new WebClient())
                    {
                        TransactionRules OBJ_TransactionRules = new TransactionRules();
                        var json = wc.DownloadString(url);
                        OBJ_TransactionRules = JsonConvert.DeserializeObject<TransactionRules>(json);
                        MainAuthFlag = OBJ_TransactionRules.GetAuthPermissionByFunctionIdResult;
                    }
                    if (MainAuthFlag == "1")
                    {
                        #region Data Store in Account Info
                        if (result == 1)
                        {
                            _AccInfo = new AccMaster();
                            var _maxAccInfoId = _IUoW.Repository<AccMaster>().GetMaxValue(x => x.AccountId) + 1;
                            _AccInfo.AccountId = _maxAccInfoId.ToString().PadLeft(3, '0');
                            //_AccInfo.AccProfileId = _Customer.AccountProfileId;
                            _AccInfo.WalletAccountNo = _Customer.WalletAccountNo;
                            _AccInfo.SystemAccountNo = _Customer.SystemAccountNo;
                            //_AccInfo.AccNm = _Customer.CustomerNm;
                            _AccInfo.AccTypeId = _Customer.AccTypeId;
                            _AccInfo.BankAccountNo = _Customer.BankAccountNo;
                            _AccInfo.TransDT = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
                            _AccInfo.AccountStatusId = "001";
                            _AccInfo.AuthStatusId = "U";
                            _AccInfo.LastAction = "ADD";
                            _AccInfo.MakeDT = System.DateTime.Now;
                            _AccInfo.MakeBy = "mTaka";

                            _IUoW.Repository<AccMaster>().Add(_AccInfo);
                        }
                        #endregion

                        _IAuthLogService = new AuthLogService();
                        long _outMaxSlAuthLogDtl = 0;
                        result = _IAuthLogService.AddAuthLog(_IUoW, null, _Customer, "ADD", "0001", _Customer.FunctionId, 1, "CustomerAccProfile", "MTK_ACC_CUSTOMER_ACC_PROFILE", "AccountProfileId", _Customer.AccountProfileId, _Customer.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                    }
                    if (MainAuthFlag == "0")
                    {
                        _IAuthLogService = new AuthLogService();
                        AuthLog _ObjAuthLog = new AuthLog();
                        _ObjAuthLog.TableNm = "MTK_ACC_CUSTOMER_ACC_PROFILE";
                        _ObjAuthLog.AuthStatusId = "A";
                        _ObjAuthLog.LastAction = "ADD";
                        _ObjAuthLog.FunctionId = FunctionId;
                        _ObjAuthLog.TablePkColVal = _Customer.AccountProfileId;
                        _ObjAuthLog.MainAuthFlag = MainAuthFlag;

                        //_Customer.AccIdofAccInfo = _AccInfo.AccountId;

                        result = _IAuthLogService.SetTableObject<CustomerAccProfile>(_IUoW, _ObjAuthLog, _Customer);

                        if(result == 1) //For Creating User in Lguarda
                        {
                            string _UserId = _Customer.WalletAccountNo;
                            string _MakeBy = _requestedDataObject.UserId;
                            string _UserClassificationId = "2";
                            string _UserAreaId = "5";
                            string _UserAreaIdValue = _Customer.SystemAccountNo;
                            string _UserDescription = "null";
                            string _BranchId = "null";
                            string _CustomerFatherNm = string.IsNullOrWhiteSpace(_Customer.FatherName) ? "null" : _Customer.FatherName;
                            string _CustomerMotherNm = string.IsNullOrWhiteSpace(_Customer.MotherName) ? "null" : _Customer.MotherName;
                            //string _CustomerDOB = (_Customer.CustomerDOB == null) ? "null" : DateTime.ParseExact(_Customer.CustomerDOB.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString();
                            string _CustomerDOB = "null";
                            string _AccNo = _Customer.WalletAccountNo;
                            string _MailAddress = string.IsNullOrWhiteSpace(_Customer.Email) ? "null" : _Customer.Email;
                            string _MobNo = string.IsNullOrWhiteSpace(_Customer.AlternativeMblNo) ? _Customer.WalletAccountNo : _Customer.AlternativeMblNo;
                            string _AuthenticationId = "5";
                            string _WorkCriteria = "2";
                            string _RoleId = "29";
                            string _RequestClientIP = string.IsNullOrWhiteSpace(_requestedDataObject.RequestClientIP) ? "null" : _requestedDataObject.RequestClientIP;
                            string _RequestAppId = string.IsNullOrWhiteSpace(_requestedDataObject.RequestAppId) ? "09" : _requestedDataObject.RequestAppId;
                            string url1 = ConfigurationManager.AppSettings["LgurdaService_server"] + "/Add_UserProfile/" + _UserId + "/" + _MakeBy + "/" +
                                                                                                                           _UserClassificationId + "/" + _UserAreaId + "/" +
                                                                                                                           _UserAreaIdValue + "/" + _Customer.UserName + "/" +
                                                                                                                           _UserDescription + "/" + _BranchId + "/" +
                                                                                                                           _AccNo + "/" + _CustomerFatherNm + "/" +
                                                                                                                           _CustomerMotherNm + "/" + _CustomerDOB + "/" +
                                                                                                                           _MailAddress + "/" + _MobNo + "/" +
                                                                                                                           _AuthenticationId + "/" + _RequestClientIP + "/" +
                                                                                                                           "null" + "/" + "null" + "/" +
                                                                                                                           _WorkCriteria + "/" + _RequestAppId + "/" + "A" +"/" + _RoleId + "?format=json";
                            string lg_result = PostParameter(url1);
                            result = (!string.IsNullOrWhiteSpace(lg_result) && lg_result.ToLower() == "true") ? 1 : 0;
                        }
                    }
                }
                #endregion
                //#region Auth Log
                //if (result == 1)
                //{
                //    _IAuthLogService = new AuthLogService();
                //    long _outMaxSlAuthLogDtl = 0;
                //    result = _IAuthLogService.AddAuthLog(_IUoW, null, _Customer, "ADD", "0001", "090103003", 1, "MTK_ACC_CUSTOMER_ACC_PROFILE", "AccountProfileId", _Customer.AccountProfileId, "mtaka", _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                //}
                //#endregion
                if (result == 1)
                {
                    _IUoW.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "AddCustomer(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Edit
        public int UpdateCustomer(CustomerAccProfile _Customer)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_Customer.AccountProfileId))
                {
                    IsRecordExist = _IUoW.Repository<CustomerAccProfile>().IsRecordExist(x => x.AccountProfileId == _Customer.AccountProfileId);
                    if (IsRecordExist)
                    {
                        var _oldCustomerProfile = _IUoW.Repository<CustomerAccProfile>().GetBy(x => x.AccountProfileId == _Customer.AccountProfileId);
                        var _oldCustomerProfileForLog = ObjectCopier.DeepCopy(_oldCustomerProfile);

                        _oldCustomerProfile.AuthStatusId = _Customer.AuthStatusId = "U";
                        _oldCustomerProfile.LastAction = _Customer.LastAction = "EDT";
                        _oldCustomerProfile.LastUpdateDT = _Customer.LastUpdateDT = System.DateTime.Now;
                        _Customer.MakeBy = "mtaka";
                        result = _IUoW.Repository<CustomerAccProfile>().Update(_oldCustomerProfile);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldCustomerProfile, _Customer, "EDT", "0001", _Customer.FunctionId, 1, "CustomerAccProfile", "MTK_ACC_CUSTOMER_ACC_PROFILE", "CusTypeId", _Customer.AccountProfileId, _Customer.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
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
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "UpdateCustomerProfile(obj)", string.Empty);
                return 0;
            }
        }
        #endregion

        #region Delete
        public int DeleteCustomer(CustomerAccProfile _Customer)
        {
            try
            {
                int result = 0;
                bool IsRecordExist;
                if (!string.IsNullOrWhiteSpace(_Customer.AccountProfileId))
                {
                    IsRecordExist = _IUoW.Repository<CustomerAccProfile>().IsRecordExist(x => x.AccountProfileId == _Customer.AccountProfileId);
                    if (IsRecordExist)
                    {
                        var _oldCustomerProfile = _IUoW.Repository<CustomerAccProfile>().GetBy(x => x.AccountProfileId == _Customer.AccountProfileId);
                        var _oldCustomerProfileForLog = ObjectCopier.DeepCopy(_oldCustomerProfile);

                        _oldCustomerProfile.AuthStatusId = _Customer.AuthStatusId = "U";
                        _oldCustomerProfile.LastAction = _Customer.LastAction = "DEL";
                        _oldCustomerProfile.LastUpdateDT = _Customer.LastUpdateDT = System.DateTime.Now;
                        result = _IUoW.Repository<CustomerAccProfile>().Update(_oldCustomerProfile);

                        #region Auth Log
                        if (result == 1)
                        {
                            _IAuthLogService = new AuthLogService();
                            long _outMaxSlAuthLogDtl = 0;
                            result = _IAuthLogService.AddAuthLog(_IUoW, _oldCustomerProfileForLog, _Customer, "DEL", "0001", _Customer.FunctionId, 1, "CustomerAccProfile", "MTK_ACC_CUSTOMER_PROFILE", "AccountProfileId", _Customer.AccountProfileId, _Customer.UserName, _outMaxSlAuthLogDtl, out _outMaxSlAuthLogDtl);
                        }
                        #endregion

                        if (result == 1)
                        {
                            _IUoW.Commit();
                        }
                        return result;
                    }
                    //result = _IUoW.Repository<CustomerProfile>().Delete(_Customer);
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "DeleteCustomerProfile(obj)", string.Empty);
                return 0;
            }
        }
        #endregion  

        #region GetGender
        public IEnumerable<SelectListItem> GetGender()
        {
            try
            {
                var List_Gender = _IUoW.Repository<Gender>().GetBy(x => x.AuthStatusId == "A"
                                                                             , n => new { n.GenderId, n.GenderNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Gender)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.GenderId,
                        Text = element.GenderNm
                    });
                }
                if (selectList != null)
                    return selectList;
                else
                    return null;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetGender()", string.Empty);
                return null;
            }
        }
        #endregion

        #region GetAddress
        public IEnumerable<SelectListItem> GetAddress()
        {
            try
            {
                var List_Address = _IUoW.Repository<Address>().GetBy(x => x.AuthStatusId == "A"
                                                                             , n => new { n.AddressId, n.AddressNm });
                var selectList = new List<SelectListItem>();
                foreach (var element in List_Address)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.AddressId,
                        Text = element.AddressNm
                    });
                }
                if (selectList != null)
                    return selectList;
                else
                    return null;
            }
            catch (Exception ex)
            {
                _ObjErrorLogService = new ErrorLogService();
                _ObjErrorLogService.AddErrorLog(ex, string.Empty, "GetAddress()", string.Empty);
                return null;
            }
        }
        #endregion

        #region GetCustomerAccProfileInfo
        public CustomerAccProfile GetCustomerAccProfileInfo(string AccountNo)
        {
            CustomerAccProfile Customer_Acc_Profile = new CustomerAccProfile();
            try
            {
                Customer_Acc_Profile = _IUoW.Repository<CustomerAccProfile>().GetBy(x => x.WalletAccountNo == AccountNo &&
                                                                   x.AuthStatusId == "A" &&
                                                                   x.LastAction != "DEL");
                return Customer_Acc_Profile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region
        public IEnumerable<SelectListItem> AccTypeWiseCustomer(string AccTypeId)
        {
            try
            {
                var List_AccType = _IUoW.Repository<CustomerAccProfile>().GetBy(x => x.AuthStatusId != "D" &&
                                                                             x.LastAction != "DEL" && x.AccTypeId == AccTypeId, n => new { n.AccountProfileId, n.UserName }).ToList();
                var selectList = new List<SelectListItem>();
                foreach (var element in List_AccType)
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
                throw ex;
            }
        }
        #endregion

        public static string PostParameter(string url)
        {
            string result = string.Empty;
            try
            {
                Uri uri = new Uri(url);
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentLength = 0;
                request.ContentType = "application/json; charset=utf-8";
                var response = (HttpWebResponse)request.GetResponse();

                using (var responseStream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(responseStream);
                    string jsonStringRaw = sr.ReadToEnd();
                    var serializer = new JavaScriptSerializer();
                    var dictionary = (IDictionary<string, object>)serializer.DeserializeObject(jsonStringRaw);   //Json string is deserialized to Dictionary
                    var nthValue = dictionary[dictionary.Keys.ToList()[0]];                                      //Only value (key is discarded from dictionary) is extracted from dictionary according to index
                    string jsonObject = serializer.Serialize((object)nthValue);                                  // that value is serializes to json string
                    result = serializer.Deserialize<string>(jsonObject);                                         //Finally json string is deserialized to required format
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
