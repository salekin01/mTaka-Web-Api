using mTaka.API.Common;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Service.BusinessServices.CP;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.CP.Controllers
{
    [Authorize]
    public class CountryInfoController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private ICountryInfoService _ICountryInfoService;
        private IDataManipulation _IDataManipulation;
        CountryInfo _CountryInfo = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public CountryInfoController()
        {
            _ICountryInfoService = new CountryInfoService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllCountryInfo(HttpRequestMessage reqObject)
        {
            var result = _ICountryInfoService.GetAllCountryInfo();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetCountryInfoById(HttpRequestMessage reqObject)
        {
            string AccountStatusId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CountryInfo = JsonConvert.DeserializeObject<CountryInfo>(_requestedDataObject.BusinessData);
                AccountStatusId = _CountryInfo.CountryId;
            }

            if (!string.IsNullOrWhiteSpace(AccountStatusId))
            {
                _CountryInfo = new CountryInfo();
                _CountryInfo = _ICountryInfoService.GetCountryInfoById(AccountStatusId);
            }
            if (_CountryInfo != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CountryInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CountryInfo, "Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetCountryInfoBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CountryInfo = JsonConvert.DeserializeObject<CountryInfo>(_requestedDataObject.BusinessData);
                _CountryInfo = _ICountryInfoService.GetCountryInfoBy(_CountryInfo);
            }
            if (_CountryInfo != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CountryInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CountryInfo, "Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddCountryInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CountryInfo = new CountryInfo();
                _CountryInfo = JsonConvert.DeserializeObject<CountryInfo>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_CountryInfo, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICountryInfoService.AddCountryInfo(_CountryInfo);
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
        public HttpResponseMessage UpdateCountryInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CountryInfo = JsonConvert.DeserializeObject<CountryInfo>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_CountryInfo, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICountryInfoService.UpdateCountryInfo(_CountryInfo);
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
        public HttpResponseMessage DeleteCountryInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CountryInfo = JsonConvert.DeserializeObject<CountryInfo>(_requestedDataObject.BusinessData);
            }

            if (_CountryInfo == null || string.IsNullOrWhiteSpace(_CountryInfo.CountryId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account Status Setup Id Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _ICountryInfoService.DeleteCountryInfo(_CountryInfo);
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
        public HttpResponseMessage GetCountryInfoForDD(HttpRequestMessage reqObject)
        {
            var List_CountryInfo = _ICountryInfoService.GetCountryInfoForDD();
            if (List_CountryInfo != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_CountryInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Country Info Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}