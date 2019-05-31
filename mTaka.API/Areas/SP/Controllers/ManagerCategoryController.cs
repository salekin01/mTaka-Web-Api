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
using System.Web.Http;

namespace mTaka.API.Areas.SP.Controllers
{
    [Authorize]
    public class ManagerCategoryController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IManagerCategoryService _IManagerCategoryService;
        private IDataManipulation _IDataManipulation;
        ManCategory _ManagerCategory = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public ManagerCategoryController()
        {
            _IManagerCategoryService = new ManagerCategoryService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllManagerCategory(HttpRequestMessage reqObject)
        {
            _businessData = _IDataManipulation.GetBusinessData(reqObject);
            var result = _IManagerCategoryService.GetAllManagerCategory();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Manager Groups Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetManagerCategoryById(HttpRequestMessage reqObject)
        {
            string ManagerCategoryId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ManagerCategory = JsonConvert.DeserializeObject<ManCategory>(_requestedDataObject.BusinessData);
                ManagerCategoryId = _ManagerCategory.ManagerCategoryId;
            }

            if (!string.IsNullOrWhiteSpace(ManagerCategoryId))
            {
                _ManagerCategory = new ManCategory();
                _ManagerCategory = _IManagerCategoryService.GetManagerCategoryById(ManagerCategoryId);
            }
            if (_ManagerCategory != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(_ManagerCategory, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Manager Group Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetManagerCategoryBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ManagerCategory = JsonConvert.DeserializeObject<ManCategory>(_requestedDataObject.BusinessData);
                _ManagerCategory = _IManagerCategoryService.GetManagerCategoryBy(_ManagerCategory);
            }
            if (_ManagerCategory != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(_ManagerCategory, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Manager Group Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddManagerCategory(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ManagerCategory = new ManCategory();
                _ManagerCategory = JsonConvert.DeserializeObject<ManCategory>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_ManagerCategory, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IManagerCategoryService.AddManagerCategory(_ManagerCategory);
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
        public HttpResponseMessage UpdateManagerCategory(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ManagerCategory = JsonConvert.DeserializeObject<ManCategory>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_ManagerCategory, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IManagerCategoryService.UpdateManagerCategory(_ManagerCategory);
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
        public HttpResponseMessage DeleteManagerCategory(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ManagerCategory = JsonConvert.DeserializeObject<ManCategory>(_requestedDataObject.BusinessData);
            }

            if (_ManagerCategory == null || string.IsNullOrWhiteSpace(_ManagerCategory.ManagerCategoryId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Manager Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IManagerCategoryService.DeleteManagerCategory(_ManagerCategory);
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
        public HttpResponseMessage GetManagerCategoryForDD(HttpRequestMessage reqObject)
        {
            var List_Man_Group = _IManagerCategoryService.GetManagerCategoryForDD();
            if (List_Man_Group != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_Man_Group, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Manager Group Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}