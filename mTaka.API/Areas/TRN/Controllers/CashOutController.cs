using mTaka.API.Common;
using mTaka.Data.BusinessEntities.TRN;
using mTaka.Service.BusinessServices.TRN;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace mTaka.API.Areas.TRN.Controllers
{
    [Authorize]
    public class CashOutController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private ICashOutService _ICashOutService;
        private IDataManipulation _IDataManipulation;
        CashOut _CashOut = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public CashOutController()
        {
            _ICashOutService = new CashOutService();
            _IDataManipulation = new DataManipulation();
        }

        #region Add
        [HttpPost]
        public async Task<HttpResponseMessage> AddCashOut(HttpRequestMessage reqObject)
        {
            string result = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
          
            _CashOut = new CashOut();
            _CashOut = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CashOut>(_requestedDataObject.BusinessData));
            result = await _ICashOutService.AddCashOut(_CashOut);
            // more code here...
            //return result;

            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(1, "Cash Out successfully. Your transaction id "+ result);
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(0, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        //[HttpPost]
        //public HttpResponseMessage AddCashOut(HttpRequestMessage reqObject)
        //{
        //    string result = string.Empty;
        //    int result_result = 0;
        //    string result_msg = "information hasn't been added";
        //    _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
        //    if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
        //    {
        //        _CashOut = new CashOut();
        //        _CashOut = JsonConvert.DeserializeObject<CashOut>(_requestedDataObject.BusinessData);

        //        bool IsValid = ModelValidation.TryValidateModel(_CashOut, out _modelErrorMsg);
        //        if (IsValid)
        //        {
        //            result = _ICashOutService.AddCashOut(_CashOut);
        //            var split = result.ToString().Split(':');
        //            result_result = Convert.ToInt32(split[0]);
        //            result_msg = split[1];
        //        }
        //    }
        //    if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
        //    {
        //        _serviceResponse = _IDataManipulation.SetResponseObject(result_result, _modelErrorMsg);
        //    }
        //    else
        //        _serviceResponse = _IDataManipulation.SetResponseObject(result_result, result_msg);
        //    _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
        //    return _response;
        //}
        #endregion

        #region TotalCashOut
        [HttpPost]
        public HttpResponseMessage TotalCashOut(HttpRequestMessage reqObject)
        {

            var result = _ICashOutService.TotalCashOut();

            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(0, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region DailyCashOut
        [HttpPost]
        public HttpResponseMessage DailyCashOut(HttpRequestMessage reqObject)
        {
            string walletaccNo = string.Empty;
            CashOut _CashOut = new CashOut();
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CashOut = JsonConvert.DeserializeObject<CashOut>(_requestedDataObject.BusinessData);
                walletaccNo = _CashOut.WalletAccountNo;
            }

            var result = _ICashOutService.DailyCashOut(_CashOut);

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