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
    public class DefineServiceController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IDefineServiceService _IDefineServiceService;
        private IDataManipulation _IDataManipulation;
        DefineService _DefineService = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public DefineServiceController()
        {
            _IDefineServiceService = new DefineServiceService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllDefineService(HttpRequestMessage reqObject)
        {
            _businessData = _IDataManipulation.GetBusinessData(reqObject);
            var result = _IDefineServiceService.GetAllDefineService();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Define Services Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetDefineServiceById(HttpRequestMessage reqObject)
        {
            string DefineServiceId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _DefineService = JsonConvert.DeserializeObject<DefineService>(_requestedDataObject.BusinessData);
                DefineServiceId = _DefineService.DefineServiceId;
            }

            if (!string.IsNullOrWhiteSpace(DefineServiceId))
            {
                _DefineService = new DefineService();
                _DefineService = _IDefineServiceService.GetDefineServiceById(DefineServiceId);
            }
            if (_DefineService != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_DefineService, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_DefineService, "Define Service Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetDefineServiceBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _DefineService = JsonConvert.DeserializeObject<DefineService>(_requestedDataObject.BusinessData);
                _DefineService = _IDefineServiceService.GetDefineServiceBy(_DefineService);
            }

            if (_DefineService != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_DefineService, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_DefineService, "Define Service Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddDefineService(HttpRequestMessage reqObject)
        {
            int result = 0;
            string msg = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _DefineService = new DefineService();
                _DefineService = JsonConvert.DeserializeObject<DefineService>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_DefineService, out _modelErrorMsg);
                if (IsValid)
                {
                    string MainResult = _IDefineServiceService.AddDefineService(_DefineService);
                    var split = MainResult.ToString().Split(':');
                    result = Convert.ToInt32(split[0]);
                    msg = split[1];
                }
            }
            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, _modelErrorMsg);
            }
            else if (result == 1 && msg == "Successfull")
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been added successfully");
            }
            else if (result == 1 && msg == "Define service already exists..")
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "define service already exists..");
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
        public HttpResponseMessage UpdateDefineService(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _DefineService = JsonConvert.DeserializeObject<DefineService>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_DefineService, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IDefineServiceService.UpdateDefineService(_DefineService);
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
        public HttpResponseMessage DeleteDefineService(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _DefineService = JsonConvert.DeserializeObject<DefineService>(_requestedDataObject.BusinessData);
            }

            if (_DefineService == null || string.IsNullOrWhiteSpace(_DefineService.DefineServiceId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Define Service Id Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IDefineServiceService.DeleteDefineService(_DefineService);
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

        #region For Dropdown
        [HttpPost]
        public HttpResponseMessage GetDefineServiceForDD(HttpRequestMessage reqObject)
        {
            var List_DefineService = _IDefineServiceService.GetDefineServiceForDD();
            if (List_DefineService != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(List_DefineService, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(List_DefineService, "Define Service Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region For Dropdown
        [HttpPost]
        public HttpResponseMessage GetDefineServiceUSBForDD(HttpRequestMessage reqObject)
        {
            var List_DefineService = _IDefineServiceService.GetDefineServiceUSBForDD();
            if (List_DefineService != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(List_DefineService, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(List_DefineService, "Define Service Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}