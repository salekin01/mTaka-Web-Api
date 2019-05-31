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
    public class AccTypeController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IAccTypeService _IAccTypeService;
        private IDataManipulation _IDataManipulation;
        AccType _AccType = null;
        string ResopnsErrMsg = string.Empty;
        public AccTypeController()
        {
            _IAccTypeService = new AccTypeService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index

        [HttpPost]
        public HttpResponseMessage GetAllAccType(HttpRequestMessage reqObject)
        {
            var result = _IAccTypeService.GetAllAccType();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result,"Account Types Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse  , reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetAccTypeById(HttpRequestMessage reqObject)
        {
            string AccTypeId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccType = JsonConvert.DeserializeObject<AccType>(_requestedDataObject.BusinessData);
                AccTypeId = _AccType.AccTypeId;
            }

            if (!string.IsNullOrWhiteSpace(AccTypeId))
            {
                _AccType = new AccType();
                _AccType = _IAccTypeService.GetAccTypeById(AccTypeId);
            }
            if (_AccType != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccType, "Account Type Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetAccTypeBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccType = JsonConvert.DeserializeObject<AccType>(_requestedDataObject.BusinessData);
                _AccType = _IAccTypeService.GetAccTypeBy(_AccType);
            }
            if (_AccType != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccType,"Account Type Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region Add

        [HttpPost]
        public HttpResponseMessage AddAccType(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccType = JsonConvert.DeserializeObject<AccType>(_requestedDataObject.BusinessData);
                result = _IAccTypeService.AddAccType(_AccType);
            }

            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been added successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account Type Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region Edit

        [HttpPost]
        public HttpResponseMessage UpdateAccType(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccType = JsonConvert.DeserializeObject<AccType>(_requestedDataObject.BusinessData);
            }

            if (_AccType == null || string.IsNullOrWhiteSpace(_AccType.AccTypeId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account Type Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IAccTypeService.UpdateAccType(_AccType);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been updated successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account Types Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region Delete

        [HttpPost]
        public HttpResponseMessage DeleteAccType(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccType = JsonConvert.DeserializeObject<AccType>(_requestedDataObject.BusinessData);
            }

            if (_AccType == null || string.IsNullOrWhiteSpace(_AccType.AccTypeId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result,"Account TypeId Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IAccTypeService.DeleteAccType(_AccType);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been deleted successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result,"Account Types Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region Dropdown
        [HttpPost]
        public HttpResponseMessage GetAccTypeForDD(HttpRequestMessage reqObject)
        {
            var List_AccType = _IAccTypeService.GetAccTypeForDD();
            if (List_AccType != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(List_AccType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(List_AccType, "Parent Account Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}