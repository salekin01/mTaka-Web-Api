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
    public class USBReportingFieldController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IUSBReportingFieldService _IUSBReportingFieldService;
        private IDataManipulation _IDataManipulation;
        USBReportingField _USBReportingField = null;
        string _modelErrorMsg = string.Empty;
        public USBReportingFieldController()
        {
            _IUSBReportingFieldService = new USBReportingFieldService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllUSBReportingField(HttpRequestMessage reqObject)
        {
            var result = _IUSBReportingFieldService.GetAllUSBReportingField();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("USB RPT Field Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddUSBReportingField(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _USBReportingField = new USBReportingField();
                _USBReportingField = JsonConvert.DeserializeObject<USBReportingField>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_USBReportingField, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IUSBReportingFieldService.AddUSBReportingField(_USBReportingField);
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
        public HttpResponseMessage UpdateUSBReportingField(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _USBReportingField = JsonConvert.DeserializeObject<USBReportingField>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_USBReportingField, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IUSBReportingFieldService.UpdateUSBReportingField(_USBReportingField);
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

        #region Get Reporting Info for Dynamic HTML
        [HttpPost]
        public HttpResponseMessage GetProviderRPTInfo(HttpRequestMessage reqObject)
        {
            string _DefineServiceId = null;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _USBReportingField = JsonConvert.DeserializeObject<USBReportingField>(_requestedDataObject.BusinessData);
                _DefineServiceId = _USBReportingField.PvId;
            }

            var List_USBReportingField = _IUSBReportingFieldService.GetProviderRPTInfo(_DefineServiceId);
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

        #region Get Reporting Info According to specific Provider
        [HttpPost]
        public HttpResponseMessage GetUSBReportingField(HttpRequestMessage reqObject)
        {
            string _USBReportingField = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _USBReportingField = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData);
                //_USBReportingField = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData);
                //_DefineServiceId = _USBReportingField.DefineServiceId;
            }

            var List_USBReportingField = _IUSBReportingFieldService.GetUSBReportingField(_USBReportingField);
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