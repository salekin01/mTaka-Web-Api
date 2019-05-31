using mTaka.API.Common;
using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Service.BusinessServices;
using mTaka.Service.BusinessServices.ACC;
using mTaka.Service.BusinessServices.SP;
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

namespace mTaka.API.Areas.SP.Controllers
{
    [Authorize]
    public class CusTypeController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private ICusTypeService _ICusTypeService;
        private IDataManipulation _IDataManipulation;
        CusType _CusType = null;
        string _modelErrorMsg = string.Empty;
        public CusTypeController()
        {
            _ICusTypeService = new CusTypeService();
            _IDataManipulation = new DataManipulation();
        }

        #region Fetch
        [HttpPost]
        public HttpResponseMessage GetAllCusType(HttpRequestMessage reqObject)
        {
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            var result = _ICusTypeService.GetAllCusType();

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
        public HttpResponseMessage GetCusTypeById(HttpRequestMessage reqObject)
        {
            string CusGroupId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusType = JsonConvert.DeserializeObject<CusType>(_requestedDataObject.BusinessData);
                CusGroupId = _CusType.CusCategoryId;
            }

            if (!string.IsNullOrWhiteSpace(CusGroupId))
            {
                _CusType = new CusType();
                _CusType = _ICusTypeService.GetCusTypeById(CusGroupId);
            }
            if (_CusType != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CusType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CusType, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetCusTypeBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusType = JsonConvert.DeserializeObject<CusType>(_requestedDataObject.BusinessData);
                _CusType = _ICusTypeService.GetCusTypeBy(_CusType);
            }
            if (_CusType != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CusType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CusType, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetCreateInfoForCusType(HttpRequestMessage reqObject)
        {
            var result = _ICusTypeService.GetCreateInfoForCusType();

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
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddCusType(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusType = new CusType();
                _CusType = JsonConvert.DeserializeObject<CusType>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_CusType, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICusTypeService.AddCusType(_CusType);
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
        public HttpResponseMessage UpdateCusType(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusType = JsonConvert.DeserializeObject<CusType>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_CusType, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICusTypeService.UpdateCusType(_CusType);
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
        public HttpResponseMessage DeleteCusType(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusType = JsonConvert.DeserializeObject<CusType>(_requestedDataObject.BusinessData);
            }

            if (_CusType == null || string.IsNullOrWhiteSpace(_CusType.CusTypeId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Customer TypeId Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _ICusTypeService.DeleteCusType(_CusType);
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

        #region Dropdown
        [HttpPost]
        public HttpResponseMessage GetCusTypeForDD(HttpRequestMessage reqObject)
        {
            var List_CusType = _ICusTypeService.GetCusTypeForDD();
            if (List_CusType != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_CusType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Parent Account Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}