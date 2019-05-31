using mTaka.API.Common;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.BusinessEntities.TRN;
using mTaka.Service.BusinessServices.CP;
using mTaka.Service.BusinessServices.TRN;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using mTaka.Utility;
using mTaka.Utility.ISO20022.Camt054;
using CreditDebitCode = mTaka.Utility.ISO20022.Camt054.CreditDebitCode;
using GenericAccountIdentification1 = mTaka.Utility.ISO20022.Pacs008.GenericAccountIdentification1;
using System.Threading.Tasks;

namespace mTaka.API.Areas.TRN.Controllers
{
    //[Authorize]
    public class CashInController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private Task<APIServiceRequest> _requestedDataObjectAsync;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private ICashInService _ICashInService;
        private IDataManipulation _IDataManipulation;
        UserTransaction _UserTransaction = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public CashInController()
        {
            _ICashInService = new CashInService();
            _IDataManipulation = new DataManipulation();
        }

        #region AddCashIn ISO 20022

        public HttpResponseMessage AddCashInIso20022(HttpRequestMessage reqObject)
        {
            string result = string.Empty;
            int result_result = 0;
            string result_msg = "information hasn't been added";
            var requestedData = reqObject.Content.ReadAsStringAsync().Result;
            mTaka.Utility.ISO20022.Pacs008.Document obj = new mTaka.Utility.ISO20022.Pacs008.Document();
            Exception ex;
            var deserializestatus = Utility.ISO20022.Pacs008.Document.Deserialize(requestedData, out obj, out ex);
            if (!deserializestatus)
            {
                return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            }
            var responseDoucment = new mTaka.Utility.ISO20022.Camt054.Document();

            var cdtTrxInf = obj?.FIToFICstmrCdtTrf.CdtTrfTxInf.FirstOrDefault();
            if (cdtTrxInf?.IntrBkSttlmAmt.Value != null)
            {
                var creditorAccount = cdtTrxInf?.CdtrAcct.Id.Item as GenericAccountIdentification1;
                var debitorAccount = cdtTrxInf?.DbtrAcct.Id.Item as GenericAccountIdentification1;
                _UserTransaction = new UserTransaction()
                {
                    FromSystemAccountNo = debitorAccount?.Id,
                    ToSystemAccountNo = creditorAccount?.Id,
                    DefineServiceId = "003",
                    FunctionId = "090107003",
                    FunctionName = "CashIn",
                    Amount = (decimal)cdtTrxInf?.IntrBkSttlmAmt.Value,
                    Narration = "Cashout",
                    MakeBy = "Prova"
                };

                bool IsValid = ModelValidation.TryValidateModel(_UserTransaction, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICashInService.AddCashIn(_UserTransaction, out responseDoucment);
                    var split = result.ToString().Split(':');
                    result_result = Convert.ToInt32(split[0]);
                    result_msg = split[1];
                }

             }
            if (result_result == 1)
            {
               
                var ntfctn = responseDoucment.BkToCstmrDbtCdtNtfctn.Ntfctn.FirstOrDefault() ?? new AccountNotification15();
                var ntry = ntfctn.Ntry.FirstOrDefault() ?? new ReportEntry9();
                ntry.CdtDbtInd = CreditDebitCode.CRDT;

            }

            var responseString = responseDoucment.Serialize(new UTF8Encoding());
            return _IDataManipulation.CreateHttpResponseXml(responseString);

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

        #region Add
        /*
        [HttpPost]
        public HttpResponseMessage AddCashIn(HttpRequestMessage reqObject)
        {
            string result = string.Empty;
            int result_result = 0;
            string result_msg = "information hasn't been added";
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CashIn = new CashIn();
                _CashIn = JsonConvert.DeserializeObject<CashIn>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_CashIn, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICashInService.AddCashIn(_CashIn);
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
        } */

        [HttpPost]
        public async Task<HttpResponseMessage> AddCashIn(HttpRequestMessage reqObject)
        {
            _requestedDataObjectAsync = _IDataManipulation.GetRequestedDataObjectAsync(reqObject);
            string result = string.Empty;
            _UserTransaction = new UserTransaction();
            _UserTransaction = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<UserTransaction>(_requestedDataObjectAsync.Result.BusinessData));

            result = await _ICashInService.AddCashIn(_UserTransaction);
            // more code here...
            //return result;

            if (result != null)
            {
                _serviceResponse =await _IDataManipulation.SetResponseObjectAsync(1, "Cash In successfully. Your transaction id "+ result);
            }
            else
            {
                _serviceResponse = await _IDataManipulation.SetResponseObjectAsync(0, "Data Not Found...");
            }
            _response =await _IDataManipulation.CreateResponseAsync(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region TotalCashIn
        [HttpPost]
        public HttpResponseMessage TotalCashIn(HttpRequestMessage reqObject)
        {

            var result = _ICashInService.TotalCashIn();

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

        #region DailyCashIn
        [HttpPost]
        public HttpResponseMessage DailyCashIn(HttpRequestMessage reqObject)
        {
            string walletaccNo = string.Empty;
            UserTransaction _UserTransaction = new UserTransaction();
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _UserTransaction = JsonConvert.DeserializeObject<UserTransaction>(_requestedDataObject.BusinessData);
                walletaccNo = _UserTransaction.WalletAccountNo;
            }

            var result = _ICashInService.DailyCashIn(_UserTransaction);

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