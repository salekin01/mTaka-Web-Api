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
    public class CurrencyInfoController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;
        
        private ICurrencyInfoService _ICurrencyInfoService;
        private IDataManipulation _IDataManipulation;
        CurrencyInfo _CurrencyInfo = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public CurrencyInfoController()
        {
            _ICurrencyInfoService = new CurrencyInfoService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllCurrencyInfo(HttpRequestMessage reqObject)
        {
            var result = _ICurrencyInfoService.GetAllCurrencyInfo();
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
        public HttpResponseMessage GetCurrencyInfoById(HttpRequestMessage reqObject)
        {
            string AccountStatusId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CurrencyInfo = JsonConvert.DeserializeObject<CurrencyInfo>(_requestedDataObject.BusinessData);
                AccountStatusId = _CurrencyInfo.CurrencyId;
            }

            if (!string.IsNullOrWhiteSpace(AccountStatusId))
            {
                _CurrencyInfo = new CurrencyInfo();
                _CurrencyInfo = _ICurrencyInfoService.GetCurrencyInfoById(AccountStatusId);
            }
            if (_CurrencyInfo != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CurrencyInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CurrencyInfo, "Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetCurrencyInfoBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CurrencyInfo = JsonConvert.DeserializeObject<CurrencyInfo>(_requestedDataObject.BusinessData);
                _CurrencyInfo = _ICurrencyInfoService.GetCurrencyInfoBy(_CurrencyInfo);
            }
            if (_CurrencyInfo != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CurrencyInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CurrencyInfo, "Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddCurrencyInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CurrencyInfo = new CurrencyInfo();
                _CurrencyInfo = JsonConvert.DeserializeObject<CurrencyInfo>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_CurrencyInfo, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICurrencyInfoService.AddCurrencyInfo(_CurrencyInfo);
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
        public HttpResponseMessage UpdateCurrencyInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CurrencyInfo = JsonConvert.DeserializeObject<CurrencyInfo>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_CurrencyInfo, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICurrencyInfoService.UpdateCurrencyInfo(_CurrencyInfo);
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
        public HttpResponseMessage DeleteCurrencyInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CurrencyInfo = JsonConvert.DeserializeObject<CurrencyInfo>(_requestedDataObject.BusinessData);
            }

            if (_CurrencyInfo == null || string.IsNullOrWhiteSpace(_CurrencyInfo.CurrencyId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account Status Setup Id Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _ICurrencyInfoService.DeleteCurrencyInfo(_CurrencyInfo);
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
        public HttpResponseMessage GetCurrencyInfoForDD(HttpRequestMessage reqObject)
        {
            var List_CurrencyInfo = _ICurrencyInfoService.GetCurrencyInfoForDD();
            if (List_CurrencyInfo != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_CurrencyInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Currency Info Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}