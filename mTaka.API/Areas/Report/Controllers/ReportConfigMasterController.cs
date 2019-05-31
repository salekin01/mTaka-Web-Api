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
    public class ReportConfigMasterController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IReportConfigarationService _IReportConfigarationService;
        private IDataManipulation _IDataManipulation;
        ReportConfigMaster _ReportConfigMaster = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public ReportConfigMasterController()
        {
            _IReportConfigarationService = new ReportConfigarationService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllReportConfigMaster(HttpRequestMessage reqObject)
        {
            var result = _IReportConfigarationService.GetAllReportConfigMaster();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Report Configaration Master Information Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetReportConfigByFunc(HttpRequestMessage reqObject)
        {
            string FunctionId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                //_ReportConfigMaster = JsonConvert.DeserializeObject<ReportConfigMaster>(_requestedDataObject.BusinessData);
                FunctionId = _requestedDataObject.BusinessData;
            }

            if (!string.IsNullOrWhiteSpace(FunctionId))
            {
                _ReportConfigMaster = new ReportConfigMaster();
                _ReportConfigMaster = _IReportConfigarationService.GetReportConfigByFunc(FunctionId);
            }
            if (_ReportConfigMaster != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ReportConfigMaster, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ReportConfigMaster, "Report Configaration Master Information Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetReportConfigurationBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ReportConfigMaster = JsonConvert.DeserializeObject<ReportConfigMaster>(_requestedDataObject.BusinessData);
                _ReportConfigMaster = _IReportConfigarationService.GetReportConfigurationBy(_ReportConfigMaster);
            }
            if (_IReportConfigarationService != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_IReportConfigarationService, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_IReportConfigarationService, "Report Configaration Master Information Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddReportConfigMaster(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ReportConfigMaster = new ReportConfigMaster();
                _ReportConfigMaster = JsonConvert.DeserializeObject<ReportConfigMaster>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_IReportConfigarationService, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IReportConfigarationService.AddReportConfigMaster(_ReportConfigMaster);
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
        public HttpResponseMessage UpdateReportConfigMaster(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ReportConfigMaster = JsonConvert.DeserializeObject<ReportConfigMaster>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_IReportConfigarationService, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IReportConfigarationService.UpdateReportConfigMaster(_ReportConfigMaster);
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

        //#region Delete
        //[HttpPost]
        //public HttpResponseMessage DeleteUnionInfo(HttpRequestMessage reqObject)
        //{
        //    int result = 0;
        //    _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
        //    if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
        //    {
        //        _IReportConfigarationService = JsonConvert.DeserializeObject<UnionInfo>(_requestedDataObject.BusinessData);
        //    }

        //    if (_IReportConfigarationService == null || string.IsNullOrWhiteSpace(_IReportConfigarationService.UnionId))
        //    {
        //        _serviceResponse = _IDataManipulation.SetResponseObject(result, "Union Information Id Not Found...");
        //        _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
        //        return _response;
        //    }

        //    result = _IUnionInfoService.DeleteUnionInfo(_IReportConfigarationService);
        //    if (result == 1)
        //    {
        //        _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been deleted successfully");
        //    }
        //    else
        //    {
        //        _serviceResponse = _IDataManipulation.SetResponseObject(result, "information hasn't been deleted");
        //    }
        //    _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
        //    return _response;
        //}
        //#endregion

        #region DropDown
        [HttpPost]
        public HttpResponseMessage GetConnectionForDD(HttpRequestMessage reqObject)
        {
            var List_IReportConfigarationService = _IReportConfigarationService.GetConnectionForDD();
            if (List_IReportConfigarationService != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_IReportConfigarationService, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Connection Info Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

    }
}
