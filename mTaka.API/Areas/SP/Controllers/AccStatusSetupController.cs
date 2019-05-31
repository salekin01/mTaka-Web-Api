using mTaka.API.Common;
using mTaka.Data.BusinessEntities.SP;
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
    public class AccStatusSetupController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IAccStatusSetupService _IAccStatusSetupService;
        private IDataManipulation _IDataManipulation;
        AccStatusSetup _AccStatusSetup = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public AccStatusSetupController()
        {
            _IAccStatusSetupService = new AccStatusSetupService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllAccStatusSetup(HttpRequestMessage reqObject)
        {
            var result = _IAccStatusSetupService.GetAllAccStatusSetup();
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
        public HttpResponseMessage GetAccStatusSetupById(HttpRequestMessage reqObject)
        {
            string AccountStatusId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccStatusSetup = JsonConvert.DeserializeObject<AccStatusSetup>(_requestedDataObject.BusinessData);
                AccountStatusId = _AccStatusSetup.AccountStatusId;
            }

            if (!string.IsNullOrWhiteSpace(AccountStatusId))
            {
                _AccStatusSetup = new AccStatusSetup();
                _AccStatusSetup = _IAccStatusSetupService.GetAccStatusSetupById(AccountStatusId);
            }
            if (_AccStatusSetup != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccStatusSetup, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccStatusSetup, "Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetAccStatusSetupBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccStatusSetup = JsonConvert.DeserializeObject<AccStatusSetup>(_requestedDataObject.BusinessData);
                _AccStatusSetup = _IAccStatusSetupService.GetAccStatusSetupBy(_AccStatusSetup);
            }
            if (_AccStatusSetup != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccStatusSetup, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccStatusSetup, "Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddAccStatusSetup(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccStatusSetup = new AccStatusSetup();
                _AccStatusSetup = JsonConvert.DeserializeObject<AccStatusSetup>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_AccStatusSetup, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IAccStatusSetupService.AddAccStatusSetup(_AccStatusSetup);
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

            //int result = 0;
            //_requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            //if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            //{
            //    _AccStatusSetup = new AccStatusSetup();
            //    _AccStatusSetup = JsonConvert.DeserializeObject<AccStatusSetup>(_requestedDataObject.BusinessData);

            //    bool IsValid = ModelValidation.TryValidateModel(_AccStatusSetup, out _modelErrorMsg);
            //    if (IsValid)
            //    {
            //        result = _IAccStatusSetupService.AddAccStatusSetup(_AccStatusSetup);
            //    }
            //}
            //if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            //{
            //    _serviceResponse = _IDataManipulation.SetResponseObject(result, _modelErrorMsg);
            //}
            //else if (result == 1)
            //{
            //    _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been added successfully");
            //}
            //else
            //{
            //    _serviceResponse = _IDataManipulation.SetResponseObject(result, "information hasn't been added");
            //}
            //_response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            //return _response;
        }
        #endregion

        #region Edit
        [HttpPost]
        public HttpResponseMessage UpdateAccStatusSetup(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccStatusSetup = JsonConvert.DeserializeObject<AccStatusSetup>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_AccStatusSetup, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IAccStatusSetupService.UpdateAccStatusSetup(_AccStatusSetup);
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
        public HttpResponseMessage DeleteAccStatusSetup(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccStatusSetup = JsonConvert.DeserializeObject<AccStatusSetup>(_requestedDataObject.BusinessData);
            }

            if (_AccStatusSetup == null || string.IsNullOrWhiteSpace(_AccStatusSetup.AccountStatusId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account Status Setup Id Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IAccStatusSetupService.DeleteAccStatusSetup(_AccStatusSetup);
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
        public HttpResponseMessage GetAccStatusSetupForDD(HttpRequestMessage reqObject)
        {
            var List_AccStatusSetup = _IAccStatusSetupService.GetAccStatusSetupForDD();
            if (List_AccStatusSetup != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_AccStatusSetup, "information has been fetched successfully");
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