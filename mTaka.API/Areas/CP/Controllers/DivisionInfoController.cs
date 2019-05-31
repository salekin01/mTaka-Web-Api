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
    public class DivisionInfoController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IDivisionInfoService _IDivisionInfoService;
        private IDataManipulation _IDataManipulation;
        DivisionInfo _DivisionInfo = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public DivisionInfoController()
        {
            _IDivisionInfoService = new DivisionInfoService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllDivisionInfo(HttpRequestMessage reqObject)
        {
            var result = _IDivisionInfoService.GetAllDivisionInfo();
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
        public HttpResponseMessage GetDivisionInfoById(HttpRequestMessage reqObject)
        {
            string AccountStatusId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _DivisionInfo = JsonConvert.DeserializeObject<DivisionInfo>(_requestedDataObject.BusinessData);
                AccountStatusId = _DivisionInfo.DivisionId;
            }

            if (!string.IsNullOrWhiteSpace(AccountStatusId))
            {
                _DivisionInfo = new DivisionInfo();
                _DivisionInfo = _IDivisionInfoService.GetDivisionInfoById(AccountStatusId);
            }
            if (_DivisionInfo != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_DivisionInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_DivisionInfo, "Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetDivisionInfoBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _DivisionInfo = JsonConvert.DeserializeObject<DivisionInfo>(_requestedDataObject.BusinessData);
                _DivisionInfo = _IDivisionInfoService.GetDivisionInfoBy(_DivisionInfo);
            }
            if (_DivisionInfo != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_DivisionInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_DivisionInfo, "Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddDivisionInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _DivisionInfo = new DivisionInfo();
                _DivisionInfo = JsonConvert.DeserializeObject<DivisionInfo>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_DivisionInfo, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IDivisionInfoService.AddDivisionInfo(_DivisionInfo);
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
        public HttpResponseMessage UpdateDivisionInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _DivisionInfo = JsonConvert.DeserializeObject<DivisionInfo>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_DivisionInfo, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IDivisionInfoService.UpdateDivisionInfo(_DivisionInfo);
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
        public HttpResponseMessage DeleteDivisionInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _DivisionInfo = JsonConvert.DeserializeObject<DivisionInfo>(_requestedDataObject.BusinessData);
            }

            if (_DivisionInfo == null || string.IsNullOrWhiteSpace(_DivisionInfo.DivisionId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account Status Setup Id Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IDivisionInfoService.DeleteDivisionInfo(_DivisionInfo);
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
        public HttpResponseMessage GetDivisionInfoForDD(HttpRequestMessage reqObject)
        {
            var List_DivisionInfo = _IDivisionInfoService.GetDivisionInfoForDD();
            if (List_DivisionInfo != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_DivisionInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Division Info Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}