using mTaka.API.Common;
using mTaka.Data.BusinessEntities.Commission;
using mTaka.Service.BusinessServices.Commission;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.Commission.Controllers
{
    public class CommissionSetupController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private ICommissionInfoService _ICommissionInfoService;
        private IDataManipulation _IDataManipulation;
        CommissionSetup _CommissionSetup = null;
        string _modelErrorMsg = string.Empty;
        public CommissionSetupController()
        {
            _ICommissionInfoService = new CommissionInfoService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllCommissionSetup(HttpRequestMessage reqObject)
        {
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            var result = _ICommissionInfoService.GetAllCommissionSetup();

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
        public HttpResponseMessage AddCommissionSetup(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CommissionSetup = JsonConvert.DeserializeObject<CommissionSetup>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_CommissionSetup, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICommissionInfoService.AddCommissionSetup(_CommissionSetup);
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
        public HttpResponseMessage UpdateCommissionSetup(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CommissionSetup = JsonConvert.DeserializeObject<CommissionSetup>(_requestedDataObject.BusinessData);
            }

            if (_CommissionSetup == null || string.IsNullOrWhiteSpace(_CommissionSetup.CommissionId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account Type Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _ICommissionInfoService.UpdateCommissionSetup(_CommissionSetup);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been updated successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Commision Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region Delete

        [HttpPost]
        public HttpResponseMessage DeleteCommissionSetup(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CommissionSetup = JsonConvert.DeserializeObject<CommissionSetup>(_requestedDataObject.BusinessData);
            }

            if (_CommissionSetup == null || string.IsNullOrWhiteSpace(_CommissionSetup.CommissionId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account TypeId Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _ICommissionInfoService.DeleteCommissionSetup(_CommissionSetup);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been deleted successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Commision Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

    }
}
