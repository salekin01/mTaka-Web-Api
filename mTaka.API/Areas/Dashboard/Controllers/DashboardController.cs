using mTaka.API.Common;
using mTaka.Data.BusinessEntities.LEDGER;
using mTaka.Service.BusinessServices.DashBoard;
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
    public class DashboardController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IDashboardService _IDashboardService;
        private IDataManipulation _IDataManipulation;
        string ResopnsErrMsg = string.Empty;

        public DashboardController()
        {
            _IDashboardService = new DashboardService();
            _IDataManipulation = new DataManipulation();
        }

        #region GetCommonDashboardInfo
        [HttpPost]
        public HttpResponseMessage GetCommonDashboardInfo(HttpRequestMessage reqObject)
        {

            var result = _IDashboardService.GetCommonDashboardInfo();

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
        #endregion

        #region GetDashBoardInfo
        [HttpPost]
        public HttpResponseMessage GetDashBoardInfo(HttpRequestMessage reqObject)
        {
            LedgerTxn _Dashboard = new LedgerTxn();
            _businessData = _IDataManipulation.GetBusinessData(reqObject);
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _Dashboard = JsonConvert.DeserializeObject<LedgerTxn>(_requestedDataObject.BusinessData);
            }

            var result = _IDashboardService.GetDashBoardInfo(_Dashboard);
            
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
        #endregion
    }
}