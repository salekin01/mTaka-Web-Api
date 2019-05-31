using mTaka.API.Common;
using mTaka.Data.Report;
using mTaka.Service.BusinessServices.SP;
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
    public class ReportConfigParmController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IReportConfigarationService _IReportConfigarationService;
        private IDataManipulation _IDataManipulation;
        List<ReportConfigParam> _ReportConfigParamList = null;
        ReportConfigParam _ReportConfigParam = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public ReportConfigParmController()
        {
            _IReportConfigarationService = new ReportConfigarationService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
  
        [HttpPost]
        public HttpResponseMessage GetReportConfigParamByFunc(HttpRequestMessage reqObject)
        {
            string _FunctionId = string.Empty;
            
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                //_ReportConfigParam = JsonConvert.DeserializeObject<ReportConfigParam>(_requestedDataObject.BusinessData);
                _FunctionId = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData);
               
                //FunctionId = _ReportConfigParam.FunctionId;
            }

            var result = _IReportConfigarationService.GetReportConfigParamByFunc(_FunctionId);
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Report Configaration Parm Information Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetReportConfigParamByFuncSl(HttpRequestMessage reqObject)
        {
            string _FunctionId = string.Empty;
            int _sl = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                //_ReportConfigParam = JsonConvert.DeserializeObject<ReportConfigParam>(_requestedDataObject.BusinessData);
                _FunctionId = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData);
                _sl = 2;
                //FunctionId = _ReportConfigParam.FunctionId;
            }

            var result = _IReportConfigarationService.GetReportConfigParamByFuncSl(_FunctionId, _sl);
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Report Configaration Parm Information Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        //[HttpPost]
        //public HttpResponseMessage GetReportConfigurationBy(HttpRequestMessage reqObject)
        //{
        //    _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
        //    if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
        //    {
        //        _ReportConfigParam = JsonConvert.DeserializeObject<ReportConfigParam>(_requestedDataObject.BusinessData);
        //        _ReportConfigParam = _IReportConfigarationService.GetReportConfig(_ReportConfigParam);
        //    }
        //    if (_IReportConfigarationService != null)
        //    {
        //        _serviceResponse = _IDataManipulation.SetResponseObject(_IReportConfigarationService, "information has been fetched successfully");
        //    }
        //    else
        //    {
        //        _serviceResponse = _IDataManipulation.SetResponseObject(_IReportConfigarationService, "Report Configaration Master Information Not Found...");
        //    }
        //    _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
        //    return _response;
        //}
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddReportConfigParam(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ReportConfigParamList = new List<ReportConfigParam>();
                _ReportConfigParamList = JsonConvert.DeserializeObject<List<ReportConfigParam>>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_IReportConfigarationService, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IReportConfigarationService.AddReportConfigParam(_ReportConfigParamList);
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
        public HttpResponseMessage UpdateReportConfigParam(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ReportConfigParam = JsonConvert.DeserializeObject<ReportConfigParam>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_IReportConfigarationService, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IReportConfigarationService.UpdateReportConfigParam(_ReportConfigParam);
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

        #region DropDown
        [HttpPost]
        public HttpResponseMessage GetReportForDD(HttpRequestMessage reqObject)
        {
            var List_IReportConfigarationService = _IReportConfigarationService.GetReportForDD();
            if (List_IReportConfigarationService != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_IReportConfigarationService, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Report Info Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}
