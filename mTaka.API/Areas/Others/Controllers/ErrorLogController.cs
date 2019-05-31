using mTaka.API.Common;
using mTaka.Data.OtherEntities;
using mTaka.Service.OtherServices;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace mTaka.API.Areas.Others.Controllers
{
    [Authorize]
    public class ErrorLogController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IErrorLogService _IErrorLogService;
        private IDataManipulation _IDataManipulation;
        ErrorLog _ErrorLog = null;
        string ResopnsErrMsg = string.Empty;
        public ErrorLogController()
        {
            _IErrorLogService = new ErrorLogService();
            _IDataManipulation = new DataManipulation();
        }


        #region Fetch
        [HttpPost]
        public HttpResponseMessage GetAllErrorLog(HttpRequestMessage reqObject)
        {
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            var result = _IErrorLogService.GetAllErrorLog();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Customer Types Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Delete
        [HttpPost]
        public HttpResponseMessage DeleteErrorLog(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ErrorLog = JsonConvert.DeserializeObject<ErrorLog>(_requestedDataObject.BusinessData);
            }

            if (_ErrorLog == null || string.IsNullOrWhiteSpace(_ErrorLog.SL))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Error Id Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IErrorLogService.DeleteErrorLog(_ErrorLog);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been deleted successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Error Id Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

    }
}