using mTaka.API.Common;
using mTaka.Data.Inquery;
using mTaka.Service.Inquery;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.Inquiry.Controllers
{
    public class InqueryController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IMiniStatementService _IMiniStatementService;
        private IDataManipulation _IDataManipulation;
        private MiniStatementService _MiniStatementService = null;
        private string _modelErrorMsg = string.Empty;

        public InqueryController()
        {
            _IMiniStatementService = new MiniStatementService();
            _IDataManipulation = new DataManipulation();
        }

        [HttpPost]
        public HttpResponseMessage GetMiniStatment(HttpRequestMessage reqObject)
        {
            string walletaccNo = string.Empty;
            StatementDataModel _StatementDataModel = new StatementDataModel();
            _businessData = _IDataManipulation.GetBusinessData(reqObject);

            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _StatementDataModel = JsonConvert.DeserializeObject<StatementDataModel>(_requestedDataObject.BusinessData);
            }
            var result = _IMiniStatementService.GetMiniStatment(_StatementDataModel);
            //var result = _IOrganogramService.GetChannelMemberData("01913584138");

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
    }

    // GET api/<controller>
}