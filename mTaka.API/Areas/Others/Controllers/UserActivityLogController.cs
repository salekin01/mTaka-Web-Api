using mTaka.API.Common;
using mTaka.Data.BusinessEntities;
using mTaka.Service.BusinessServices;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace mTaka.API.Areas.Others.Controllers
{
    [Authorize]
    public class UserActivityLogController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IUserActivityLogService _IUserActivityLogService;
        private IDataManipulation _IDataManipulation;
        UserActivityLog _UserActivityLog = null;
        string ResopnsErrMsg = string.Empty;
        string _modelErrorMsg = string.Empty;
        public UserActivityLogController()
        {
            _IUserActivityLogService = new UserActivityLogService();
            _IDataManipulation = new DataManipulation();
        }

        #region UserActivityLogByAccNo

        [HttpPost]
        public HttpResponseMessage UserActivityLogByAccNo(HttpRequestMessage reqObject)
        {
            string WalletAccountNo = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedData != null && _requestedDataObject.BusinessData != null)
            {
                _UserActivityLog = JsonConvert.DeserializeObject<UserActivityLog>(_requestedDataObject.BusinessData);
                WalletAccountNo = _UserActivityLog.WalletAccountNo;
            }
            if (string.IsNullOrWhiteSpace(WalletAccountNo))
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Information Not Found");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            var result = _IUserActivityLogService.UserActivityLogByAccNo(WalletAccountNo);

            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");

            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result,"Information Not Found");

            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region UserActivityLogByDate
        [HttpPost]
        public HttpResponseMessage UserActivityLogByDate(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            

            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _UserActivityLog = JsonConvert.DeserializeObject<UserActivityLog>(_requestedDataObject.BusinessData);

            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Information Not Found");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            var result = _IUserActivityLogService.UserActivityLogByDate(_UserActivityLog);

            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");

            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result,"Information Not Found");

            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region add
        [HttpPost]
        public HttpResponseMessage AddUserActivityLog(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _UserActivityLog = new UserActivityLog();
                _UserActivityLog = JsonConvert.DeserializeObject<UserActivityLog>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_UserActivityLog, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IUserActivityLogService.AddUserActivityLog(_UserActivityLog);
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
    }
}