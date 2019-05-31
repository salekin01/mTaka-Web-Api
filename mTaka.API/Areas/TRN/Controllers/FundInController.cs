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
    public class FundInController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IFundInService _IFundInService;
        private IDataManipulation _IDataManipulation;
        FundIn _FundIn = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public FundInController()
        {
            _IFundInService = new FundInService();
            _IDataManipulation = new DataManipulation();
        }

        #region Add
        /*
        [HttpPost]
        public HttpResponseMessage AddFundIn(HttpRequestMessage reqObject)
        {
            string result = string.Empty;
            int result_result = 0;
            string result_msg = "information hasn't been added";
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _FundIn = new FundIn();
                _FundIn = JsonConvert.DeserializeObject<FundIn>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_FundIn, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IFundInService.AddFundIn(_FundIn);
                    var split = result.ToString().Split(':');
                    result_result = Convert.ToInt32(split[0]);
                    result_msg = split[1];
                }
            }
            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result_result, _modelErrorMsg);
            }
            //else if (result_result == 1 && result_msg == "Saved Successfully")
            //{
            //    _serviceResponse = _IDataManipulation.SetResponseObject(result_result, "information has been added successfully");
            //}
            //else if (result_result == 0 && result_msg == "Account No. not valid..")
            //{
            //    _serviceResponse = _IDataManipulation.SetResponseObject(result_result, "Account No. not valid.");
            //}
            //else if (result_result == 0 && result_msg == "Account No. is not active for this transaction..")
            //{
            //    _serviceResponse = _IDataManipulation.SetResponseObject(result_result, "Account No. is not active for this transaction..");
            //}
            //else if (result_result == 0 && result_msg == "Transaction is not allowed..")
            //{
            //    _serviceResponse = _IDataManipulation.SetResponseObject(result_result, "Transaction is not allowed..");
            //}
            else
                _serviceResponse = _IDataManipulation.SetResponseObject(result_result, result_msg);
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        */


        [HttpPost]
        public async Task<HttpResponseMessage> AddFundIn(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            string result = string.Empty;
            _FundIn = new FundIn();
            _FundIn = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<FundIn>(_requestedDataObject.BusinessData));

            result = await _IFundInService.AddFundIn(_FundIn);
            // more code here...
            //return result;

            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(1, "Fund In successfully. Your transaction id " + result);
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(0, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region DailyFundIn
        [HttpPost]
        public HttpResponseMessage DailyFundIn(HttpRequestMessage reqObject)
        {
            string walletaccNo = string.Empty;
            FundIn _FundIn = new FundIn();
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _FundIn = JsonConvert.DeserializeObject<FundIn>(_requestedDataObject.BusinessData);
                walletaccNo = _FundIn.WalletAccountNo;
            }

            var result = _IFundInService.DailyFundIn(_FundIn);

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