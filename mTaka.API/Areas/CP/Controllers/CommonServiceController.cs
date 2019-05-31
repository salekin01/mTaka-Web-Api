using mTaka.API.Common;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Service.BusinessServices.CP;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace mTaka.API.Areas.CP.Controllers
{
    [Authorize]
    public class CommonServiceController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private ICommonServiceService _ICommonService;
        private IDataManipulation _IDataManipulation;
        CommonService _CommonService = null;
        string _modelErrorMsg = string.Empty;
        public CommonServiceController()
        {
            _ICommonService = new CommonServiceService();
            _IDataManipulation = new DataManipulation();
        }


        #region Add
        [HttpPost]
        public HttpResponseMessage AddCommonService(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CommonService = new CommonService();
                _CommonService = JsonConvert.DeserializeObject<CommonService>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_CommonService, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICommonService.AddCommonService(_CommonService);
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

        [HttpPost]
        public HttpResponseMessage GetAllAddress(HttpRequestMessage reqObject)
        {
            var List_Address = _ICommonService.GetAllAddress();
            if (List_Address != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_Address, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Address Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetAllGender(HttpRequestMessage reqObject)
        {
            var List_Gender = _ICommonService.GetAllGender();
            if (List_Gender != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_Gender, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Gender Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetAllNationality(HttpRequestMessage reqObject)
        {
            var List_Nationality = _ICommonService.GetAllNationality();
            if (List_Nationality != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_Nationality, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Nationality Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #region Source of Account Dropdown
        [HttpPost]
        public HttpResponseMessage GetSourceofAccForDD(HttpRequestMessage reqObject)
        {
            var List_SourceofAcc = _ICommonService.GetSourceofAccForDD();
            if (List_SourceofAcc != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_SourceofAcc, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Type of Account Dropdown
        [HttpPost]
        public HttpResponseMessage GetTypeofAccForDD(HttpRequestMessage reqObject)
        {
            var List_TypeofAcc = _ICommonService.GetTypeofAccForDD();
            if (List_TypeofAcc != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_TypeofAcc, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Account Balance Type Dropdown
        [HttpPost]
        public HttpResponseMessage GetAccBalanceTypeForDD(HttpRequestMessage reqObject)
        {
            var List_AccBalanceType = _ICommonService.GetAccBalanceTypeForDD();
            if (List_AccBalanceType != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_AccBalanceType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region TransType
        [HttpPost]
        public HttpResponseMessage GetAllTransType(HttpRequestMessage reqObject)
        {
            var List_TransType = _ICommonService.GetAllTransType();
            if (List_TransType != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_TransType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Type Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Transaction Setup Dropdown
        [HttpPost]
        public HttpResponseMessage GetTransactionSetupForDD(HttpRequestMessage reqObject)
        {
            var List_TransactionSetup = _ICommonService.GetTransactionSetupForDD();
            if (List_TransactionSetup != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_TransactionSetup, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Mobile Operator
        [HttpPost]
        public HttpResponseMessage GetMobileOperator(HttpRequestMessage reqObject)
        {
            var List_MobileOperator = _ICommonService.GetMobileOperator();
            if (List_MobileOperator != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_MobileOperator, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Mobile Operator  Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region TokenFormat
        [HttpPost]
        public HttpResponseMessage GetTokenFormatForDD(HttpRequestMessage reqObject)
        {
            var List_TokenFormat = _ICommonService.GetTokenFormatForDD();
            if (List_TokenFormat != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_TokenFormat, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}