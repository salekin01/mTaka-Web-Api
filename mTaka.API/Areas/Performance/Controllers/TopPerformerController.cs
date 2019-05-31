using mTaka.API.Common;
using mTaka.Data.BusinessEntities.LEDGER;
using mTaka.Data.Performance;
using mTaka.Service.Performance;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace mTaka.API.Areas.Performance
{
    [Authorize]
    public class TopPerformerController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private ITopPerformerService _ITopPerformerService;
        private IDataManipulation _IDataManipulation;
        TopPerformer _TopPerformer = null;
        string ResopnsErrMsg = string.Empty;

        public TopPerformerController()
        {
            _ITopPerformerService = new TopPerformerService();
            _IDataManipulation = new DataManipulation();
        }

        #region TopPerformerInfo
        [HttpPost]
        public HttpResponseMessage TopPerformerInfo(HttpRequestMessage reqObject)
        {
            LedgerTxn _LedgerTxn = new LedgerTxn();
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _LedgerTxn = JsonConvert.DeserializeObject<LedgerTxn>(_requestedDataObject.BusinessData);
            }

            var result = _ITopPerformerService.TopPerformerInfo(_LedgerTxn);

            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(0, "Top Performer Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region LowestPerformerInfo
        [HttpPost]
        public HttpResponseMessage LowestPerformerInfo(HttpRequestMessage reqObject)
        {
            LedgerTxn _LedgerTxn = new LedgerTxn();
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _LedgerTxn = JsonConvert.DeserializeObject<LedgerTxn>(_requestedDataObject.BusinessData);
            }

            var result = _ITopPerformerService.LowestPerformerInfo(_LedgerTxn);

            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(0, "Lowest Performer Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}