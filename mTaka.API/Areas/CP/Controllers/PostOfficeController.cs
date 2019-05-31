using mTaka.API.Common;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Service.BusinessServices.CP;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace mTaka.API.Areas.CP.Controllers
{
    [Authorize]
    public class PostOfficeController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IPostOfficeInfoService _IPostOfficeInfoService;
        private IDataManipulation _IDataManipulation;
        PostOfficeInfo _PostOfficeInfo = null;
        string _modelErrorMsg = string.Empty;
        public PostOfficeController()
        {
            _IPostOfficeInfoService = new PostOfficeInfoService();
            _IDataManipulation = new DataManipulation();
        }
        // GET: CP/PostOffice

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllPO(HttpRequestMessage reqObject)
        {
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            var result = _IPostOfficeInfoService.GetAllPO();

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
        public HttpResponseMessage GetPOInfoById(HttpRequestMessage reqObject)
        {
            string POInfoId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _PostOfficeInfo = JsonConvert.DeserializeObject<PostOfficeInfo>(_requestedDataObject.BusinessData);
                POInfoId = _PostOfficeInfo.PostOfficeId;
            }

            if (!string.IsNullOrWhiteSpace(POInfoId))
            {
                _PostOfficeInfo = new PostOfficeInfo();
                _PostOfficeInfo = _IPostOfficeInfoService.GetPOInfoById(POInfoId);
            }
            if (_PostOfficeInfo != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_PostOfficeInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_PostOfficeInfo, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetPOInfoeBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _PostOfficeInfo = JsonConvert.DeserializeObject<PostOfficeInfo>(_requestedDataObject.BusinessData);
                _PostOfficeInfo = _IPostOfficeInfoService.GetPOInfoeBy(_PostOfficeInfo);
            }
            if (_PostOfficeInfo != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_PostOfficeInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_PostOfficeInfo, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddPOInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _PostOfficeInfo = new PostOfficeInfo();
                _PostOfficeInfo = JsonConvert.DeserializeObject<PostOfficeInfo>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_PostOfficeInfo, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IPostOfficeInfoService.AddPOInfo(_PostOfficeInfo);
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
        public HttpResponseMessage UpdatePOInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _PostOfficeInfo = JsonConvert.DeserializeObject<PostOfficeInfo>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_PostOfficeInfo, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IPostOfficeInfoService.UpdatePOInfo(_PostOfficeInfo);
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
        public HttpResponseMessage DeletePOInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _PostOfficeInfo = JsonConvert.DeserializeObject<PostOfficeInfo>(_requestedDataObject.BusinessData);
            }

            if (_PostOfficeInfo == null || string.IsNullOrWhiteSpace(_PostOfficeInfo.PostOfficeId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Post Office Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IPostOfficeInfoService.DeletePOInfo(_PostOfficeInfo);
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
        public HttpResponseMessage GetPostOfficeInfoForDD(HttpRequestMessage reqObject)
        {
            var List_PostOfficeInfo = _IPostOfficeInfoService.GetPostOfficeInfoForDD();
            if (List_PostOfficeInfo != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_PostOfficeInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Post Office Info Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}