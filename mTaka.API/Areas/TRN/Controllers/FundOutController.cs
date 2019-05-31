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
using System.Threading.Tasks;
using System.Web.Http;

namespace mTaka.API.Areas.TRN.Controllers
{
    [Authorize]
    public class FundOutController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IFundOutService _IFundOutService;
        private IDataManipulation _IDataManipulation;
        FundOut _FundOut = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public FundOutController()
        {
            _IFundOutService = new FundOutService();
            _IDataManipulation = new DataManipulation();
        }

        #region Add

        [HttpPost]
        public async Task<HttpResponseMessage> AddFundOut(HttpRequestMessage reqObject)
        {
            string result = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);

            _FundOut = new FundOut();
            _FundOut = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<FundOut>(_requestedDataObject.BusinessData));
            result = await _IFundOutService.AddFundOut(_FundOut);
            // more code here...
            //return result;

            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(1, "Fund Out successfully. Your transaction id " + result);
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(0, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        /*
        [HttpPost]
        public HttpResponseMessage AddFundOut(HttpRequestMessage reqObject)
        {
            string result = string.Empty;
            int result_result = 0;
            string result_msg = "information hasn't been added";
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _FundOut = new FundOut();
                _FundOut = JsonConvert.DeserializeObject<FundOut>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_FundOut, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IFundOutService.AddFundOut(_FundOut);
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
        */
        #endregion

        #region DailyFundOut
        [HttpPost]
        public HttpResponseMessage DailyFundOut(HttpRequestMessage reqObject)
        {
            string walletaccNo = string.Empty;
            FundOut _FundOut = new FundOut();
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _FundOut = JsonConvert.DeserializeObject<FundOut>(_requestedDataObject.BusinessData);
                walletaccNo = _FundOut.WalletAccountNo;
            }

            var result = _IFundOutService.DailyFundOut(_FundOut);

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