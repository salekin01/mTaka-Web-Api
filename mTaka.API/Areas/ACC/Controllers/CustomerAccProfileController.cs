using mTaka.API.Common;
using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Service.BusinessServices;
using mTaka.Service.BusinessServices.ACC;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.ACC.Controllers
{
    //[Authorize]
    public class CustomerAccProfileController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private ICustomerAccProfileService _ICustomerAccProfileService;
        private IDataManipulation _IDataManipulation;
        CustomerAccProfile _CustomerProfile = null;
        string _modelErrorMsg = string.Empty;
        public CustomerAccProfileController()
        {
            _ICustomerAccProfileService = new CustomerAccProfileService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllCustomer(HttpRequestMessage reqObject)
        {
            var result = _ICustomerAccProfileService.GetAllCustomer();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Customer Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetCustomerById(HttpRequestMessage reqObject)
        {
            dynamic WalletAccountNo = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CustomerProfile = JsonConvert.DeserializeObject<CustomerAccProfile>(_requestedDataObject.BusinessData);
                WalletAccountNo = _CustomerProfile.WalletAccountNo;
            }

            dynamic result = null;
            if (!string.IsNullOrWhiteSpace(WalletAccountNo))
            {
                //_CustomerProfile = new CustomerAccProfile();
                result = _ICustomerAccProfileService.GetCustomerById(_CustomerProfile);
            }
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result,"Customer Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetCustomerBy(HttpRequestMessage reqObject)
        {
            dynamic result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CustomerProfile = JsonConvert.DeserializeObject<CustomerAccProfile>(_requestedDataObject.BusinessData);

                result = _ICustomerAccProfileService.GetCustomerBy(_CustomerProfile);
            }

            if (result != null)
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

        #region Add
        [HttpPost]
        public HttpResponseMessage AddCustomer(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CustomerProfile = new CustomerAccProfile();
                _CustomerProfile = JsonConvert.DeserializeObject<CustomerAccProfile>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_CustomerProfile, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICustomerAccProfileService.AddCustomer(_CustomerProfile, _requestedDataObject);
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
        public HttpResponseMessage UpdateCustomer(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CustomerProfile = JsonConvert.DeserializeObject<CustomerAccProfile>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_CustomerProfile, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICustomerAccProfileService.UpdateCustomer(_CustomerProfile);
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
        public HttpResponseMessage DeleteCustomer(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CustomerProfile = JsonConvert.DeserializeObject<CustomerAccProfile>(_requestedDataObject.BusinessData);
            }

            if (_CustomerProfile == null || string.IsNullOrWhiteSpace(_CustomerProfile.AccountProfileId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Customer TypeId Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _ICustomerAccProfileService.DeleteCustomer(_CustomerProfile);
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
        
        #region GetGender
        [HttpPost]
        public HttpResponseMessage GetGender(HttpRequestMessage reqObject)
        {
            var List_Gender = _ICustomerAccProfileService.GetGender();
            if (List_Gender != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_Gender, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Gender Type Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region GetAddress
        [HttpPost]
        public HttpResponseMessage GetAddress(HttpRequestMessage reqObject)
        {
            var List_Address = _ICustomerAccProfileService.GetAddress();
            if (List_Address != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_Address, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Address Type Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region AccTypeWiseCustomer
        [HttpPost]
        public HttpResponseMessage AccTypeWiseCustomer(HttpRequestMessage reqObject)
        {
            string AccTypeId = null;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CustomerProfile = JsonConvert.DeserializeObject<CustomerAccProfile>(_requestedDataObject.BusinessData);
                AccTypeId = _CustomerProfile.AccTypeId;
            }

            var List_Customer = _ICustomerAccProfileService.AccTypeWiseCustomer(AccTypeId);
            if (List_Customer != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_Customer, "information has been fetched successfully");
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