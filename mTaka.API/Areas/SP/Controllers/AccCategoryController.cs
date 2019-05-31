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
    public class AccCategoryController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IAccCategoryService _IAccCategoryService;
        private IDataManipulation _IDataManipulation;
        AccCategory _AccCategory = null;
        string ResopnsErrMsg = string.Empty;
        public AccCategoryController()
        {
            _IAccCategoryService = new AccCategoryService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllAccCategory(HttpRequestMessage reqObject)
        {
            _businessData = _IDataManipulation.GetBusinessData(reqObject);
            var result = _IAccCategoryService.GetAllAccCategory();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result,"Account Groups Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetAccCategoryById(HttpRequestMessage reqObject)
        {
            string AccCategoryId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccCategory = JsonConvert.DeserializeObject<AccCategory>(_requestedDataObject.BusinessData);
                AccCategoryId = _AccCategory.AccCategoryId;
            }

            if (!string.IsNullOrWhiteSpace(AccCategoryId))
            {
                _AccCategory = new AccCategory();
                _AccCategory = _IAccCategoryService.GetAccCategoryById(AccCategoryId);
            }
            if (_AccCategory != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccCategory, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccCategory, "Account Group Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetAccCategoryBy(HttpRequestMessage reqObject)
        {
            //string AccCategoryId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccCategory = JsonConvert.DeserializeObject<AccCategory>(_requestedDataObject.BusinessData);
                //AccCategoryId = _AccCategory.AccCategoryId;
                _AccCategory = _IAccCategoryService.GetAccCategoryBy(_AccCategory);
            }

            //if (!string.IsNullOrWhiteSpace(AccCategoryId))
            //{
            //    _AccCategory = new AccCategory();
            //    _AccCategory = _IAccCategoryService.GetAccCategoryBy(AccCategoryId);
            //}
            if (_AccCategory != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccCategory, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccCategory,"Account Group Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddAccCategory(HttpRequestMessage reqObject)
        {
            int result = 0;

            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccCategory = JsonConvert.DeserializeObject<AccCategory>(_requestedDataObject.BusinessData);
                result = _IAccCategoryService.AddAccCategory(_AccCategory);
            }

            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been added successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result,"Account Group Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Edit
        [HttpPost]
        public HttpResponseMessage UpdateAccCategory(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccCategory = JsonConvert.DeserializeObject<AccCategory>(_requestedDataObject.BusinessData);
            }

            if (_AccCategory == null || string.IsNullOrWhiteSpace(_AccCategory.AccCategoryId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account GroupId Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IAccCategoryService.UpdateAccCategory(_AccCategory);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been updated successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result,"Account Groups Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Delete
        [HttpPost]
        public HttpResponseMessage DeleteAccCategory(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccCategory = JsonConvert.DeserializeObject<AccCategory>(_requestedDataObject.BusinessData);
            }

            if (_AccCategory == null || string.IsNullOrWhiteSpace(_AccCategory.AccCategoryId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result,"Account GroupId Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IAccCategoryService.DeleteAccCategory(_AccCategory);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been deleted successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result,"Account Groups Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Dropdown
        [HttpPost]
        public HttpResponseMessage GetAccCategoryForDD(HttpRequestMessage reqObject)
        {
            var List_AccCategory = _IAccCategoryService.GetAccCategoryForDD();
            if (List_AccCategory != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(List_AccCategory, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(List_AccCategory,"Account Group Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}