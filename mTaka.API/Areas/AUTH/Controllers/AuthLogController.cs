using mTaka.API.Common;
using mTaka.Data.BusinessEntities.AUTH;
using mTaka.Service.BusinessServices.AUTH;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.AUTH.Controllers
{
    [Authorize]
    public class AuthLogController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IAuthLogService _IAuthLogService;
        private IDataManipulation _IDataManipulation;
        string _modelErrorMsg = string.Empty;
        public AuthLogController()
        {
            _IAuthLogService = new AuthLogService();
            _IDataManipulation = new DataManipulation();
        }

        #region Verify
        [HttpPost]
        public HttpResponseMessage VerifyAuthLog(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                var _AuthLog = JsonConvert.DeserializeObject<AuthLog>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_AuthLog, out _modelErrorMsg);
                if (IsValid)
                {
                    if(_AuthLog.FunctionId == "090106001") //NFT
                    {
                        result = _IAuthLogService.VerifyAuthLog(_AuthLog.LogId, _AuthLog.Remarks, _AuthLog.AuthStatusId, _AuthLog.MakeBy, _AuthLog.SelectedAuthLogIdList);
                    }
                    else if(_AuthLog.FunctionId == "090106002") //FT
                    {
                        result = _IAuthLogService.VerifyAuthLog_FT(_AuthLog.LogId, _AuthLog.Remarks, _AuthLog.AuthStatusId, _AuthLog.MakeBy, _AuthLog.SelectedAuthLogIdList);
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, _modelErrorMsg);
            }
            else if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Processed successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Can't Process");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region DropDown
        [HttpPost]
        public HttpResponseMessage GetNftAuthLogFunctionsForDD(HttpRequestMessage reqObject)
        {
            var _result = _IAuthLogService.GetNftAuthLogFunctionsForDD();
            if (_result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_result, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetFtAuthLogFunctionsForDD(HttpRequestMessage reqObject)
        {
            var _result = _IAuthLogService.GetFtAuthLogFunctionsForDD();
            if (_result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_result, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Grid Show & Details
        [HttpPost]
        public HttpResponseMessage GetAllNftAuthLogByFunctionId(HttpRequestMessage reqObject)
        {
            string _FunctionId = string.Empty;
            IEnumerable<AuthLog> _ListAuthLog = null;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _FunctionId = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData);
            }
            if (!string.IsNullOrWhiteSpace(_FunctionId))
            {
                _ListAuthLog = _IAuthLogService.GetAllNftAuthLogByFunctionId(_FunctionId);
            }

            if (_ListAuthLog != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ListAuthLog, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ListAuthLog, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetAllFtAuthLogByFunctionId(HttpRequestMessage reqObject)
        {
            string _FunctionId = string.Empty;
            IEnumerable<FTAuthLog> _ListAuthLog = null;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _FunctionId = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData);
            }
            if (!string.IsNullOrWhiteSpace(_FunctionId))
            {
                _ListAuthLog = _IAuthLogService.GetAllFtAuthLogByFunctionId(_FunctionId);
            }

            if (_ListAuthLog != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ListAuthLog, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ListAuthLog, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetNftAuthLogDetailsByLogId(HttpRequestMessage reqObject)
        {
            string _LogId = string.Empty;
            IEnumerable<AuthLogDtl> _ListAuthLogDtls = null;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _LogId = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData);
            }
            if (!string.IsNullOrWhiteSpace(_LogId))
            {
                _ListAuthLogDtls = _IAuthLogService.GetNftAuthLogDetailsByLogId(_LogId);
            }

            if (_ListAuthLogDtls != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ListAuthLogDtls, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ListAuthLogDtls, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetFtAuthLogDetailsByLogId(HttpRequestMessage reqObject)
        {
            string _LogId = string.Empty;
            IEnumerable<FTAuthLogDtl> _ListAuthLogDtls = null;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _LogId = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData);
            }
            if (!string.IsNullOrWhiteSpace(_LogId))
            {
                _ListAuthLogDtls = _IAuthLogService.GetFtAuthLogDetailsByLogId(_LogId);
            }

            if (_ListAuthLogDtls != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ListAuthLogDtls, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ListAuthLogDtls, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

    }
}