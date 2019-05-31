using mTaka.API.Common;
using mTaka.Data.BusinessEntities.GL;
using mTaka.Service.BusinessServices.GL;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.GL.Controller
{
    [Authorize]
    public class GLChartController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IGLChartService _IGLChartService;
        private IDataManipulation _IDataManipulation;
        GLChart _GLChart = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public GLChartController()
        {
            _IGLChartService = new GLChartService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage CheckGLAccNo(HttpRequestMessage reqObject)
        {

            string glAccountNo = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                glAccountNo = _requestedDataObject.BusinessData;
            }

            if (!string.IsNullOrWhiteSpace(glAccountNo) && glAccountNo.Length == 11)
            {
                _GLChart = new GLChart();
                _GLChart = _IGLChartService.GetGLChartByAccNo(glAccountNo);
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(0, "Please select GL Type then type GL Account Number..");
            }

            if (_GLChart != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(0, "GL Account alrady exist.");
            }
            else
            {
                _serviceResponse = _serviceResponse == null ? _IDataManipulation.SetResponseObject(1, "GL Account Not Found...") : _serviceResponse;
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetAllGLChart(HttpRequestMessage reqObject)
        {
            var result = _IGLChartService.GetAllGLChart();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "GL Information Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetGLChartById(HttpRequestMessage reqObject)
        {
            string GLAccountSl = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _GLChart = JsonConvert.DeserializeObject<GLChart>(_requestedDataObject.BusinessData);
                GLAccountSl = _GLChart.GLAccSl;
            }

            if (!string.IsNullOrWhiteSpace(GLAccountSl))
            {
                _GLChart = new GLChart();
                _GLChart = _IGLChartService.GetGLChartByAccSl(GLAccountSl);
            }
            if (_GLChart != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_GLChart, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_GLChart, "GL Information Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetGLChartBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _GLChart = JsonConvert.DeserializeObject<GLChart>(_requestedDataObject.BusinessData);
                _GLChart = _IGLChartService.GetGLChartBy(_GLChart);
            }
            if (_GLChart != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_GLChart, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_GLChart, "GL Information Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddGLChart(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _GLChart = new GLChart();
                _GLChart = JsonConvert.DeserializeObject<GLChart>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_GLChart, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IGLChartService.AddGLChart(_GLChart);
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
        public HttpResponseMessage UpdateGLChart(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _GLChart = JsonConvert.DeserializeObject<GLChart>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_GLChart, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IGLChartService.UpdateGLChart(_GLChart);
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
        public HttpResponseMessage DeleteGLChart(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _GLChart = JsonConvert.DeserializeObject<GLChart>(_requestedDataObject.BusinessData);
            }

            if (_GLChart == null || string.IsNullOrWhiteSpace(_GLChart.GLAccSl))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Union Information Id Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IGLChartService.DeleteGLChart(_GLChart);
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

        #region DropDown


        [HttpPost]
        public HttpResponseMessage GetGLAccForDD(HttpRequestMessage reqObject)
        {
            int level = 0;
            string prefix = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                string[] data = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData).Split('-');
                level = Convert.ToInt32(data[0]);
                prefix = data[1].ToString();

            }
            var List_GLChart = _IGLChartService.GetGLAccForDD();

            if (List_GLChart != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_GLChart, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Totaling GL Info Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetTotalingAccForDD(HttpRequestMessage reqObject)
        {
            int level = 0;
            string prefix = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                string[] data = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData).Split('-');
                level = Convert.ToInt32(data[0]);
                prefix = data[1].ToString();

            }
            var List_GLChart = _IGLChartService.GetTotalingAccForDD(level, prefix);

            if (List_GLChart != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_GLChart, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Totaling GL Info Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetApplPrefixForDD(HttpRequestMessage reqObject)
        {
            var List_ApplPrefix = _IGLChartService.GetApplPrefixForDD();
            if (List_ApplPrefix != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_ApplPrefix, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("APPL Prefix Info Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetGLLevelForDD(HttpRequestMessage reqObject)
        {
            var List_GLLevel = _IGLChartService.GetGLLevelForDD();
            if (List_GLLevel != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_GLLevel, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("GL Level Info Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion
    }
}
