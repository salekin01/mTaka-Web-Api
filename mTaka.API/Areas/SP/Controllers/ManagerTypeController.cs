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
    public class ManagerTypeController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IManagerTypeService _IManagerTypeService;
        private IDataManipulation _IDataManipulation;
        ManagerType _ManagerType = null;
        string ResopnsErrMsg = string.Empty;
        string _modelErrorMsg = string.Empty;
        public ManagerTypeController()
        {
            _IManagerTypeService = new ManagerTypeService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllManagerType(HttpRequestMessage reqObject)
        {
            var result = _IManagerTypeService.GetAllManagerType();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Manager Types Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetManagerTypeById(HttpRequestMessage reqObject)
        {
            string ManagerTypeId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ManagerType = JsonConvert.DeserializeObject<ManagerType>(_requestedDataObject.BusinessData);
                ManagerTypeId = _ManagerType.ManTypeId;
            }

            if (!string.IsNullOrWhiteSpace(ManagerTypeId))
            {
                _ManagerType = new ManagerType();
                _ManagerType = _IManagerTypeService.GetManagerTypeById(ManagerTypeId);
            }
            if (_ManagerType != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(_ManagerType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Manager Type Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetManagerTypeBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ManagerType = JsonConvert.DeserializeObject<ManagerType>(_requestedDataObject.BusinessData);
                _ManagerType = _IManagerTypeService.GetManagerTypeBy(_ManagerType);
            }
            if (_ManagerType != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(_ManagerType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Manager Type Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region add
        [HttpPost]
        public HttpResponseMessage AddManagerType(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ManagerType = new ManagerType();
                _ManagerType = JsonConvert.DeserializeObject<ManagerType>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_ManagerType, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IManagerTypeService.AddManagerType(_ManagerType);
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

        #region edit

        [HttpPost]
        public HttpResponseMessage UpdateManagerType(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ManagerType = JsonConvert.DeserializeObject<ManagerType>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_ManagerType, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IManagerTypeService.UpdateManagerType(_ManagerType);
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

        #region delete
        [HttpPost]
        public HttpResponseMessage DeleteManagerType(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ManagerType = JsonConvert.DeserializeObject<ManagerType>(_requestedDataObject.BusinessData);
            }

            if (_ManagerType == null || string.IsNullOrWhiteSpace(_ManagerType.ManTypeId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Manager TypeId Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IManagerTypeService.DeleteManagerType(_ManagerType);
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
        public HttpResponseMessage GetManagerTypeForDD(HttpRequestMessage reqObject)
        {
            var List_Manager_Type = _IManagerTypeService.GetManagerTypeForDD();
            if (List_Manager_Type != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_Manager_Type, "information has been fetched successfully");
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