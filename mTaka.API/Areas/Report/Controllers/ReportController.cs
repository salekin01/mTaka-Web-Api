using mTaka.API.Common;
using mTaka.Data.Report;
using mTaka.Service.OtherServices;
using mTaka.Service.ReportService;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.Report.Controllers
{
    [Authorize]
    public class ReportController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IReportService _IReportService;
        private IDataManipulation _IDataManipulation;
        ReportConfigMaster _ReportConfigMasters = null;
        List<ReportConfigParam> _ReportConfigParam = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public ReportController()
        {
            _IReportService = new ReportService();
            _IDataManipulation = new DataManipulation();
        }
        [HttpPost]
        public HttpResponseMessage GetReportConfigParams(HttpRequestMessage reqObject)
        {
            string FunctionId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                FunctionId= JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData);
                //_ReportConfigMasters = JsonConvert.DeserializeObject<ReportConfigMaster>(_requestedDataObject.BusinessData);
                //FunctionId = _ReportConfigMasters.FunctionId;
            }

            if (!string.IsNullOrWhiteSpace(FunctionId))
            {
                _ReportConfigParam = new List<ReportConfigParam>();
                //_ReportConfigMasters = _IReportService.GetReportConfigMasterByFunctionId(FunctionId);
                _ReportConfigParam = _IReportService.GetReportConfigParamByFunctionId(FunctionId);
                //_ReportConfigMasters.DatabaseConnection = _IReportService.GetDatabaseConConfigByFunctionId(_ReportConfigMasters.ConnectionId);
            }
            if (_ReportConfigParam != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ReportConfigParam, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ReportConfigParam, "Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetReportByFunctionId(HttpRequestMessage reqObject)
        {
            string FunctionId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                FunctionId = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData);
                //_ReportConfigMasters = JsonConvert.DeserializeObject<ReportConfigMaster>(_requestedDataObject.BusinessData);
                //FunctionId = _ReportConfigMasters.FunctionId;
            }

            if (!string.IsNullOrWhiteSpace(FunctionId))
            {
                _ReportConfigMasters = new ReportConfigMaster();
                _ReportConfigMasters = _IReportService.GetReportConfigMasterByFunctionId(FunctionId);
                _ReportConfigMasters.ReportConfigParams = _IReportService.GetReportConfigParamByFunctionId(FunctionId);
                _ReportConfigMasters.DatabaseConnection = _IReportService.GetDatabaseConConfigByFunctionId(_ReportConfigMasters.ConnectionId);
            }
            if (_ReportConfigMasters != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ReportConfigMasters, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ReportConfigMasters, "Account Status Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetReportFunctionsForDD(HttpRequestMessage reqObject)
        {
            var _result = _IReportService.GetReportFunctionForDD();
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
    }
}
