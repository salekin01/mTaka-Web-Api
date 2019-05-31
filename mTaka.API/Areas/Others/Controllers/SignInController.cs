using mTaka.API.Common;
using mTaka.Data.OtherEntities;
using mTaka.Service.BusinessServices.ACC;
using mTaka.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Web.Http;

namespace mTaka.API.Areas.Others.Controllers
{
    public class SignInController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IAccInfoService _IAccInfoService;
        private IDataManipulation _IDataManipulation;
        string _modelErrorMsg = string.Empty;

        public SignInController()
        {
            _IDataManipulation = new DataManipulation();
            _IAccInfoService = new AccMasterService();
        }

        #region Add
        [HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage reqObject)
        {
            string result = "0";
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                var _userObj = JsonConvert.DeserializeObject<UserCredentials>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_userObj, out _modelErrorMsg);
                if (IsValid)
                {
                    string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/Verify_User_And_Password_For_login/" + _userObj.UserId + "/" + _userObj.Password + "/" + _requestedDataObject.SessionId + "/" + _requestedDataObject.RequestClientIP + "/" + _requestedDataObject.RequestAppId + "?format=json";
                    result = HttpWcfRequest.PostParameter(url);
                    string[] vResult = result.Split(',');
                    if (vResult[0] == "1")
                    {
                        //_AccInfo = new AccInfo();
                        string _userId = _userObj.UserId;
                        var _AccInfo = _IAccInfoService.GetAccInfoForDetails(_userId);
                        if (_AccInfo != null)
                        {
                            vResult[1] = _AccInfo.AccTypeId;
                            result = string.Join(",", vResult);
                        }
                        else
                            result = "0";
                    }
                    
                }
            }
            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, _modelErrorMsg);
            }
            else if (!string.IsNullOrWhiteSpace(result))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information hasn't been added");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage Logout(HttpRequestMessage reqObject)
        {
            string result = "0";
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                var _userObj = JsonConvert.DeserializeObject<UserCredentials>(_requestedDataObject.BusinessData);
                if(!string.IsNullOrWhiteSpace(_userObj.UserId))
                {
                    string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/Logout_user/" + _userObj.UserId + "/" + _requestedDataObject.SessionId + "/" + _requestedDataObject.RequestClientIP + "/" + _requestedDataObject.RequestAppId + "?format=json";
                    result = HttpWcfRequest.PostParameter(url);
                } 
            }
            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, _modelErrorMsg);
            }
            else if (!string.IsNullOrWhiteSpace(result))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information hasn't been added");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Password Change
        [HttpPost]
        public HttpResponseMessage PasswordChange(HttpRequestMessage reqObject)
        {
            string result = "0";
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                var _userObj = JsonConvert.DeserializeObject<PasswordChangeModel>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_userObj, out _modelErrorMsg);
                if (IsValid)
                {
                    string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/Change_Password/01/"+_userObj.UserName + "/" + _userObj.NewPassword + "/" + _userObj.CurrentPassword + "?format=json";
                    result = HttpWcfRequest.PostParameter(url);
                }
            }
            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, _modelErrorMsg);
            }
            else if (!string.IsNullOrWhiteSpace(result) && result == "True")
            {
                result = "1";
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been changed successfully");
            }
            else
            {
                result = "0";
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information hasn't been changed");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        [HttpPost]
        public HttpResponseMessage GetMenuWithPermittedFunctions(HttpRequestMessage reqObject)
        {
            string result = "0";
            UserCredentials _ObjUserCredentials = new UserCredentials();
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null)
            {
                if(string.IsNullOrWhiteSpace(_requestedDataObject.UserId) || string.IsNullOrWhiteSpace(_requestedDataObject.RequestAppId))
                {
                    _modelErrorMsg = "Both User Id & Application Id is required";
                }
                else
                {
                    using (WebClient wc = new WebClient())
                    {
                        string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetPermittedFunctionsByUser/" + _requestedDataObject.UserId + "/" + _requestedDataObject.RequestAppId + "/" + "0" + "?format=json";
                        var json = wc.DownloadString(url);

                        if (json != null)
                        {
                            JToken token = JToken.Parse(json);
                            _ObjUserCredentials = token.SelectToken("GetPermittedFunctionsByUserResult").ToObject<UserCredentials>();
                            //var _ListPermissions = token.SelectToken("GetPermittedFunctionsByUserResult.PERMISSIONS[0]").ToObject<Menu>();

                            if (_ObjUserCredentials != null)
                            {
                                var menuItems = CreateVM(0, _ObjUserCredentials.LIST_MENU_MAP);
                                _ObjUserCredentials.LIST_MENU_MAP = menuItems;
                            }
                        }
                    }
                }
                
            }
            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(0, _modelErrorMsg);
            }
            else if (_ObjUserCredentials != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ObjUserCredentials, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(0, "information hasn't been added");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        private List<Menu> CreateVM(int? _ParentId, List<Menu> _ListMenu)
        {
            var abc = (from men in _ListMenu
                       where men.PARENTID == _ParentId
                       select new Menu()
                       {
                           MENU_ID = men.MENU_ID,
                           NAME = men.NAME,
                           CONTROLLER = men.CONTROLLER,
                           title = men.NAME,
                           stateRef = men.CONTROLLER,
                           FUNCTION_ID = men.FUNCTION_ID,
                           //blank = "false",
                           icon = "ion-document",
                           subMenu = CreateVM(men.MENU_ID, _ListMenu)
                       }).ToList();

            foreach (var item in abc)
            {
                if (item.subMenu.Count() <= 0)
                {
                    item.subMenu = null;
                }
            }

            return abc;
        }
    }
}
