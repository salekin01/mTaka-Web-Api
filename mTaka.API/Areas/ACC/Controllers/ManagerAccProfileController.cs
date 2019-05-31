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
using System.Web;
using System.Web.Http;
using System.Web.ModelBinding;

namespace mTaka.API.Areas.ACC.Controllers
{
    [Authorize]
    public class ManagerAccProfileController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IManagerProfileService _IManagerProfileService;
        private IDataManipulation _IDataManipulation;
        ManagerAccProfile _ManagerProfile = null;
        string _modelErrorMsg = string.Empty;

        public ManagerAccProfileController()
        {
            _IManagerProfileService = new ManagerAccProfileService();
            _IDataManipulation = new DataManipulation();
        }

        #region Fetch
        [HttpPost]
        public HttpResponseMessage GetAllManagerAccProfile(HttpRequestMessage reqObject)
        {
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            var result = _IManagerProfileService.GetAllManagerAccProfile();

            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetManagerById(HttpRequestMessage reqObject)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                string ManagerById = string.Empty;
                _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
                if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
                {
                    _ManagerProfile = JsonConvert.DeserializeObject<ManagerAccProfile>(_requestedDataObject.BusinessData, settings);
                    ManagerById = _ManagerProfile.ManId;
                }

                if (!string.IsNullOrWhiteSpace(ManagerById))
                {
                    _ManagerProfile = new ManagerAccProfile();
                    _ManagerProfile = _IManagerProfileService.GetManagerById(ManagerById);
                }
                if (_ManagerProfile != null)
                {
                    _serviceResponse = _IDataManipulation.SetResponseObject(_ManagerProfile, "information has been fetched successfully");
                }
                else
                {
                    _serviceResponse = _IDataManipulation.SetResponseObject(_ManagerProfile, "Data Not Found...");
                }
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            }
            catch(Exception ex)
            {

            }
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetManagerBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ManagerProfile = JsonConvert.DeserializeObject<ManagerAccProfile>(_requestedDataObject.BusinessData);
                _ManagerProfile = _IManagerProfileService.GetManagerBy(_ManagerProfile);
            }
            if (_ManagerProfile != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ManagerProfile, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ManagerProfile, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddManager(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ManagerProfile = new ManagerAccProfile();
                _ManagerProfile = JsonConvert.DeserializeObject<ManagerAccProfile>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_ManagerProfile, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IManagerProfileService.AddManager(_ManagerProfile);
                }
            }
            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, _modelErrorMsg);
            }
            else if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been added successfully");
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
        public HttpResponseMessage UpdateManager(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ManagerProfile = JsonConvert.DeserializeObject<ManagerAccProfile>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_ManagerProfile, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IManagerProfileService.UpdateManager(_ManagerProfile);
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
        public HttpResponseMessage DeleteManager(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ManagerProfile = JsonConvert.DeserializeObject<ManagerAccProfile>(_requestedDataObject.BusinessData);
            }

            if (_ManagerProfile == null || string.IsNullOrWhiteSpace(_ManagerProfile.ManId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Manager Profile Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IManagerProfileService.DeleteManager(_ManagerProfile);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been deleted successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information hasn't been deleted");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region DropDown
        [HttpPost]
        public HttpResponseMessage GetManagerForDD(HttpRequestMessage reqObject)
        {
            var List_Manager = _IManagerProfileService.GetManagerForDD();
            if (List_Manager != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(List_Manager, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(List_Manager, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

    }
}