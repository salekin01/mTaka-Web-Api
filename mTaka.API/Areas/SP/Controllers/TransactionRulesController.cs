using mTaka.API.Common;
using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Service.BusinessServices;
using mTaka.Service.BusinessServices.ACC;
using mTaka.Service.BusinessServices.SP;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
namespace mTaka.API.Areas.SP.Controllers
{
    [Authorize]
    public class TransactionRulesController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requesteData = string.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private ITransactionRulesService _ITransactionRulesService;
        private IDataManipulation _IDataManipulation;
        TransactionRules _TransactionRules = null;
        string _modelErrorMsg = string.Empty;
        public TransactionRulesController()
        {
            _ITransactionRulesService = new TransactionRulesService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index

        [HttpPost]
        public HttpResponseMessage GetAllTransactionRule(HttpRequestMessage requestObj)
        {
            var result = _ITransactionRulesService.GetAllTransactionRules();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been fetched successfully");

            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Information Not Found");

            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, requestObj);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetTransactionRuleById(HttpRequestMessage requestObj)
        {
            string TransactionRuleId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(requestObj);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _TransactionRules = JsonConvert.DeserializeObject<TransactionRules>(_requestedDataObject.BusinessData);
                TransactionRuleId = _TransactionRules.TransactionRuleId;
            }

            if (!string.IsNullOrWhiteSpace(TransactionRuleId))
            {
                _TransactionRules = new TransactionRules();
                _TransactionRules = _ITransactionRulesService.GetAccountRuleById(TransactionRuleId);
            }
            if (_TransactionRules != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(_TransactionRules, "Account Rule Found");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Account Rule Not Found");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, requestObj);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetTransactionRuleBy(HttpRequestMessage requestObj)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(requestObj);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _TransactionRules = JsonConvert.DeserializeObject<TransactionRules>(_requestedDataObject.BusinessData);
                _TransactionRules = _ITransactionRulesService.GetAccountRuleBy(_TransactionRules);
            }
            if (_TransactionRules != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(_TransactionRules, "Account Rule Fouingd");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Account Rule Not Found");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, requestObj);
            return _response;
        }
        #endregion

        #region Add
        public HttpResponseMessage AddTransactionRule(HttpRequestMessage requestObj)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(requestObj);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _TransactionRules = JsonConvert.DeserializeObject<TransactionRules>(_requestedDataObject.BusinessData);
                result = _ITransactionRulesService.AddTransactionRules(_TransactionRules);
            }
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been added successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information can't be added successfully");
            }

            _response = _IDataManipulation.CreateResponse(_serviceResponse,requestObj);
            return _response;

        }
        #endregion

        #region Edit
        [HttpPost]
        public HttpResponseMessage EditTransactionRule(HttpRequestMessage requestObj)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(requestObj);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _TransactionRules = JsonConvert.DeserializeObject<TransactionRules>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_TransactionRules, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ITransactionRulesService.EditTransactionRules(_TransactionRules);
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
            _response = _IDataManipulation.CreateResponse(_serviceResponse, requestObj);
            return _response;
        }
        #endregion

        #region Delete
        [HttpPost]
        public HttpResponseMessage DeleteTransactionRule(HttpRequestMessage requestObj)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(requestObj);

            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _TransactionRules = JsonConvert.DeserializeObject<TransactionRules>(_requestedDataObject.BusinessData);
            }
            if (_TransactionRules == null || string.IsNullOrWhiteSpace(_TransactionRules.TransactionRuleId))
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Account Rule Not found");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, requestObj);
            }
            else
            {
                result = _ITransactionRulesService.DeleteTransactionRules(_TransactionRules);
            }
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "Account Rule Delete Successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Account Rule Not Updated");
            }

            _response = _IDataManipulation.CreateResponse(_serviceResponse, requestObj);
            return _response;
        }
        #endregion

        //#region CheckTransactionRules
        //[HttpPost]
        //public HttpResponseMessage CheckTransactionRules(HttpRequestMessage reqObject)
        //{
        //    string FromSystemAccountNo = string.Empty;
        //    string ToSystemAccountNo = string.Empty;
        //    int Result = 0;
        //    _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
        //    if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
        //    {
        //        _TransactionRules = JsonConvert.DeserializeObject<TransactionRules>(_requestedDataObject.BusinessData);
        //        FromSystemAccountNo = _TransactionRules.FromSystemAccountNo;
        //        ToSystemAccountNo = _TransactionRules.ToSystemAccountNo;
        //    }
        //    if (!string.IsNullOrWhiteSpace(FromSystemAccountNo) && !string.IsNullOrWhiteSpace(ToSystemAccountNo))
        //    {
        //        Result = _ITransactionRulesService.CheckTransactionRules(_TransactionRules);
        //    }
        //    if (Result != 0)
        //    {
        //        _serviceResponse = _IDataManipulation.SetResponseObject(Result, "Transaction is allowed..");
        //    }
        //    else
        //    {
        //        _serviceResponse = _IDataManipulation.SetResponseObject(Result, "Transaction is not allowed..");
        //    }
        //    _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
        //    return _response;
        //}
        //#endregion
    }
}