using mTaka.API.Common;
using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Service.BusinessServices;
using mTaka.Service.BusinessServices.ACC;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.ACC.Controllers
{
    [Authorize]
    public class ChannelAccProfileController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IChannelAccProfileService _IChannelAccProfileService;
        private IDataManipulation _IDataManipulation;
        ChannelAccProfile _ChannelAccProfile = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public ChannelAccProfileController()
        {
            _IChannelAccProfileService = new ChannelAccProfileService();
            _IDataManipulation = new DataManipulation();
        }

        #region Fetch
        [HttpPost]
        public HttpResponseMessage GetAllChannelAccProfile(HttpRequestMessage reqObject)
        {
            var result = _IChannelAccProfileService.GetAllChannelAccProfile();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Channel Account Profile Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetChannelAccProfileById(HttpRequestMessage reqObject)
        {
            string AccountProfileId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ChannelAccProfile = JsonConvert.DeserializeObject<ChannelAccProfile>(_requestedDataObject.BusinessData);
                AccountProfileId = _ChannelAccProfile.AccountProfileId;
            }

            if (!string.IsNullOrWhiteSpace(AccountProfileId))
            {
                _ChannelAccProfile = new ChannelAccProfile();
                _ChannelAccProfile = _IChannelAccProfileService.GetChannelAccProfileById(AccountProfileId);
            }
            if (_ChannelAccProfile != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ChannelAccProfile, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ChannelAccProfile, "Channel Account Profile Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetChannelAccProfileBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ChannelAccProfile = JsonConvert.DeserializeObject<ChannelAccProfile>(_requestedDataObject.BusinessData);
                _ChannelAccProfile = _IChannelAccProfileService.GetChannelAccProfileBy(_ChannelAccProfile);
            }
            if (_ChannelAccProfile != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ChannelAccProfile, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ChannelAccProfile, "Channel Account Profile Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddChannelAccProfile(HttpRequestMessage reqObject)
        {
            int result = 0;
            string msg = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ChannelAccProfile = new ChannelAccProfile();
                _ChannelAccProfile = JsonConvert.DeserializeObject<ChannelAccProfile>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_ChannelAccProfile, out _modelErrorMsg);
                if (IsValid)
                {
                    string MainResult = _IChannelAccProfileService.AddChannelAccProfile(_ChannelAccProfile);
                    var split = MainResult.ToString().Split(':');
                    result = Convert.ToInt32(split[0]);
                    msg = split[1];
                }
            }
            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, _modelErrorMsg);
            }
            else if (result == 1 && msg == "Successfull")
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been added successfully");
            }
            else if (result == 1 && msg == "Account number already exists..")
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "account number already exists..");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information hasn't been added");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Edit
        [HttpPost]
        public HttpResponseMessage UpdateChannelAccProfile(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ChannelAccProfile = JsonConvert.DeserializeObject<ChannelAccProfile>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_ChannelAccProfile, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IChannelAccProfileService.UpdateChannelAccProfile(_ChannelAccProfile);
                }
            }

            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, _modelErrorMsg);
            }
            else if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been updated successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information hasn't been updated");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Delete
        [HttpPost]
        public HttpResponseMessage DeleteChannelAccProfile(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ChannelAccProfile = JsonConvert.DeserializeObject<ChannelAccProfile>(_requestedDataObject.BusinessData);
            }

            if (_ChannelAccProfile == null || string.IsNullOrWhiteSpace(_ChannelAccProfile.AccountProfileId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Channel Account Profile Id not found.");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IChannelAccProfileService.DeleteChannelAccProfile(_ChannelAccProfile);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Information has been deleted successfully.");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Information hasn't been deleted.");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Dropdown
        [HttpPost]
        public HttpResponseMessage GetChannelAccProfileForDD(HttpRequestMessage reqObject)
        {
            var List_ChannelAccProfile = _IChannelAccProfileService.GetChannelAccProfileForDD();
            if (List_ChannelAccProfile != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(List_ChannelAccProfile, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(List_ChannelAccProfile, "Channel Account Profile Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region GetChannelInfobyWalletAccNo
        [HttpPost]
        public HttpResponseMessage GetChannelInfobyWalletAccNo(HttpRequestMessage reqObject)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            string WalletAccNo = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ChannelAccProfile = JsonConvert.DeserializeObject<ChannelAccProfile>(_requestedDataObject.BusinessData, settings);
                WalletAccNo = _ChannelAccProfile.ParentAccountProfileId;
            }

            if (!string.IsNullOrWhiteSpace(WalletAccNo))
            {
                _ChannelAccProfile = new ChannelAccProfile();
                _ChannelAccProfile = _IChannelAccProfileService.GetChannelInfobyWalletAccNo(WalletAccNo);
            }
            if (_ChannelAccProfile != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ChannelAccProfile, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ChannelAccProfile, "Account Not found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}