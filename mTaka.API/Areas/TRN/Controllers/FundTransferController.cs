using mTaka.API.Common;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.BusinessEntities.TRN;
using mTaka.Service.BusinessServices.CP;
using mTaka.Service.BusinessServices.TRN;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.TRN.Controllers
{
    [Authorize]
    public class FundTransferController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IFundTransferService _IFundTransferService;
        private IDataManipulation _IDataManipulation;
        FundTransfer _FundTransfer = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public FundTransferController()
        {
            _IFundTransferService = new FundTransferService();
            _IDataManipulation = new DataManipulation();
        }

        #region Add
        [HttpPost]
        public HttpResponseMessage AddFundTransfer(HttpRequestMessage reqObject)
        {
            string result = string.Empty;
            int result_result = 0;
            string result_msg = "information hasn't been added";
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _FundTransfer = new FundTransfer();
                _FundTransfer = JsonConvert.DeserializeObject<FundTransfer>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_FundTransfer, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IFundTransferService.AddFundTransfer(_FundTransfer);
                    var split = result.ToString().Split(':');
                    result_result = Convert.ToInt32(split[0]);
                    result_msg = split[1];
                }
            }
            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result_result, _modelErrorMsg);
            }
            else
                _serviceResponse = _IDataManipulation.SetResponseObject(result_result, result_msg);
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}