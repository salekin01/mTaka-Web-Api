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
    public class BankInfoController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IBankInfoService _IBankInfoService;
        private IDataManipulation _IDataManipulation;
        BankInfo _BankInfo = null;
        string _modelErrorMsg = string.Empty;
        public BankInfoController()
        {
            _IBankInfoService = new BankInfoService();
            _IDataManipulation = new DataManipulation();
        }

        // GET: CP/BankInfo
        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllBankInfo(HttpRequestMessage reqObject)
        {
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            var result = _IBankInfoService.GetAllBankInfo();

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
        public HttpResponseMessage GetBankInfoById(HttpRequestMessage reqObject)
        {
            string BankInfoId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _BankInfo = JsonConvert.DeserializeObject<BankInfo>(_requestedDataObject.BusinessData);
                BankInfoId = _BankInfo.BankId;
            }

            if (!string.IsNullOrWhiteSpace(BankInfoId))
            {
                _BankInfo = new BankInfo();
                _BankInfo = _IBankInfoService.GetBankInfoById(BankInfoId);
            }
            if (_BankInfo != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_BankInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_BankInfo, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetBankInfoBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _BankInfo = JsonConvert.DeserializeObject<BankInfo>(_requestedDataObject.BusinessData);
                _BankInfo = _IBankInfoService.GetBankInfoBy(_BankInfo);
            }
            if (_BankInfo != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_BankInfo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_BankInfo, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddBankInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _BankInfo = new BankInfo();
                _BankInfo = JsonConvert.DeserializeObject<BankInfo>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_BankInfo, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IBankInfoService.AddBankInfo(_BankInfo);
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
        public HttpResponseMessage UpdateBankInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _BankInfo = JsonConvert.DeserializeObject<BankInfo>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_BankInfo, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IBankInfoService.UpdateBankInfo(_BankInfo);
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
        public HttpResponseMessage DeleteBankInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _BankInfo = JsonConvert.DeserializeObject<BankInfo>(_requestedDataObject.BusinessData);
            }

            if (_BankInfo == null || string.IsNullOrWhiteSpace(_BankInfo.BankId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Post Office Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IBankInfoService.DeleteBankInfo(_BankInfo);
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
        public HttpResponseMessage GetBankInfoForDD(HttpRequestMessage reqObject)
        {
            var List_Bank = _IBankInfoService.GetBankInfoForDD();
            if (List_Bank != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_Bank, "information has been fetched successfully");
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