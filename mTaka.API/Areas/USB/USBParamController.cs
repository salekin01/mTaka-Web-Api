using mTaka.API.Common;
using mTaka.Data.BusinessEntities.USB;
using mTaka.Service.BusinessServices.USB;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;



namespace mTaka.API.Areas.USB
{
    [Authorize]
    public class USBParamController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IUsbParamService _IUsbParamService;
        private IDataManipulation _IDataManipulation;
        UsbParam _UsbParam = null;
        string _modelErrorMsg = string.Empty;
        public USBParamController()
        {
            _IUsbParamService = new UsbParamService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllUsbParam(HttpRequestMessage reqObject)
        {
            _businessData = _IDataManipulation.GetBusinessData(reqObject);
            var result = _IUsbParamService.GetAllUsbParam();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Account Groups Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddUsbParam(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _UsbParam = new UsbParam();
                _UsbParam = JsonConvert.DeserializeObject<UsbParam>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_UsbParam, out _modelErrorMsg);
                if (IsValid)
                 {
                    result = _IUsbParamService.AddUsbParam(_UsbParam);
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
        public HttpResponseMessage UpdateUsbParam(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _UsbParam = JsonConvert.DeserializeObject<UsbParam>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_UsbParam, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IUsbParamService.UpdateUsbParam(_UsbParam);
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
        #endregion

        #region DropDown
        [HttpPost]
        public HttpResponseMessage GetAllProviderForDD(HttpRequestMessage reqObject)
        {
            var List_AccType = _IUsbParamService.GetAllProviderForDD();
            if (List_AccType != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_AccType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Provider Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region GetAPI
        [HttpPost]
        public HttpResponseMessage GetAPI(HttpRequestMessage reqObject)
        {
            string _UsbParam = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _UsbParam = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData);
            }

            var List_USBReportingField = _IUsbParamService.GetAPI(_UsbParam);
            if (List_USBReportingField != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_USBReportingField, "information has been fetched successfully");
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