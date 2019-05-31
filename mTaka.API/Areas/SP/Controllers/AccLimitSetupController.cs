using mTaka.API.Common;
using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Service.BusinessServices;
using mTaka.Service.BusinessServices.ACC;
using mTaka.Service.BusinessServices.SP;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace mTaka.API.Areas.SP.Controllers
{
    [Authorize]
    public class AccLimitSetupController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IAccLimitSetupService _IAccLimitSetupService;
        private IDataManipulation _IDataManipulation;
        AccLimitSetup _AccLimitSetup = null;
        string _modelErrorMsg = string.Empty;
        public AccLimitSetupController()
        {
            _IAccLimitSetupService = new AccLimitSetupService();
            _IDataManipulation = new DataManipulation();
        }


        #region Fetch
        [HttpPost]
        public HttpResponseMessage GetAllAccLimit(HttpRequestMessage reqObject)
        {
            var result = _IAccLimitSetupService.GetAllAccLimit();

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
        public HttpResponseMessage GetAccLimitById(HttpRequestMessage reqObject)
        {
            string AccLimitId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccLimitSetup = JsonConvert.DeserializeObject<AccLimitSetup>(_requestedDataObject.BusinessData);
                AccLimitId = _AccLimitSetup.AccLimitId;
            }

            if (!string.IsNullOrWhiteSpace(AccLimitId))
            {
                _AccLimitSetup = new AccLimitSetup();
                _AccLimitSetup = _IAccLimitSetupService.GetAccLimitById(AccLimitId);
            }
            if (_AccLimitSetup != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccLimitSetup, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccLimitSetup, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetAccLimitBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccLimitSetup = JsonConvert.DeserializeObject<AccLimitSetup>(_requestedDataObject.BusinessData);
                _AccLimitSetup = _IAccLimitSetupService.GetAccLimitBy(_AccLimitSetup);
            }
            if (_AccLimitSetup != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccLimitSetup, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccLimitSetup, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddAccLimit(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccLimitSetup = new AccLimitSetup();
                _AccLimitSetup = JsonConvert.DeserializeObject<AccLimitSetup>(_requestedDataObject.BusinessData);

                //bool IsValid = ModelValidation.TryValidateModel(_AccLimitSetup, out _modelErrorMsg);
                //if (IsValid)
                //{
                if (_AccLimitSetup != null)
                {
                    result = _IAccLimitSetupService.AddAccLimit(_AccLimitSetup);
                }
                //}
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
        public HttpResponseMessage UpdateAccLimit(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccLimitSetup = JsonConvert.DeserializeObject<AccLimitSetup>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_AccLimitSetup, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IAccLimitSetupService.UpdateAccLimit(_AccLimitSetup);
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
        public HttpResponseMessage DeleteAccLimit(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccLimitSetup = JsonConvert.DeserializeObject<AccLimitSetup>(_requestedDataObject.BusinessData);
            }

            if (_AccLimitSetup == null || string.IsNullOrWhiteSpace(_AccLimitSetup.AccLimitId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account Limit Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IAccLimitSetupService.DeleteAccLimit(_AccLimitSetup);
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
    }
}