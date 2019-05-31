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
    public class BranchInfoController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IBranchInfoService _IBranchInfoService;
        private IDataManipulation _IDataManipulation;
        BranchInfo _BranchInfo = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public BranchInfoController()
        {
            _IBranchInfoService = new BranchInfoService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllBranchInfo(HttpRequestMessage reqObject)
        {
            var result = _IBranchInfoService.GetAllBranchInfo();
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
        public HttpResponseMessage GetBranchInfoById(HttpRequestMessage reqObject)
        {
            string AccountStatusId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _BranchInfo = JsonConvert.DeserializeObject<BranchInfo>(_requestedDataObject.BusinessData);
                AccountStatusId = _BranchInfo.BranchId;
            }

            if (!string.IsNullOrWhiteSpace(AccountStatusId))
            {
                _BranchInfo = new BranchInfo();
                _BranchInfo = _IBranchInfoService.GetBranchInfoById(AccountStatusId);
            }
            if (_BranchInfo != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_BranchInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_BranchInfo, "Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetBranchInfoBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _BranchInfo = JsonConvert.DeserializeObject<BranchInfo>(_requestedDataObject.BusinessData);
                _BranchInfo = _IBranchInfoService.GetBranchInfoBy(_BranchInfo);
            }
            if (_BranchInfo != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_BranchInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_BranchInfo, "Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddBranchInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _BranchInfo = new BranchInfo();
                _BranchInfo = JsonConvert.DeserializeObject<BranchInfo>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_BranchInfo, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IBranchInfoService.AddBranchInfo(_BranchInfo);
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
        public HttpResponseMessage UpdateBranchInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _BranchInfo = JsonConvert.DeserializeObject<BranchInfo>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_BranchInfo, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IBranchInfoService.UpdateBranchInfo(_BranchInfo);
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
        public HttpResponseMessage DeleteBranchInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _BranchInfo = JsonConvert.DeserializeObject<BranchInfo>(_requestedDataObject.BusinessData);
            }

            if (_BranchInfo == null || string.IsNullOrWhiteSpace(_BranchInfo.BranchId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account Status Setup Id Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IBranchInfoService.DeleteBranchInfo(_BranchInfo);
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
        public HttpResponseMessage GetBranchInfoForDD(HttpRequestMessage reqObject)
        {
            var List_BranchInfo = _IBranchInfoService.GetBranchInfoForDD();
            if (List_BranchInfo != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_BranchInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}