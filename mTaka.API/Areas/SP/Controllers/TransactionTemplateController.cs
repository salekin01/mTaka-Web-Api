using mTaka.API.Common;
using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.BusinessEntities.TRN;
using mTaka.Service.BusinessServices;
using mTaka.Service.BusinessServices.ACC;
using mTaka.Service.BusinessServices.SP;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.SP.Controllers
{
    [Authorize]
    public class TransactionTemplateController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private ITransactionTemplateService _ITransactionTemplateService;
        private IDataManipulation _IDataManipulation;
        TransactionTemplate _TransactionTemplate = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public TransactionTemplateController()
        {
            _ITransactionTemplateService = new TransactionTemplateService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllTransactionTemplate(HttpRequestMessage reqObject)
        {
            var result = _ITransactionTemplateService.GetAllTransactionTemplate();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Status Wise Services Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetTransactionTemplateById(HttpRequestMessage reqObject)
        {
            string TransactionTemplateId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _TransactionTemplate = JsonConvert.DeserializeObject<TransactionTemplate>(_requestedDataObject.BusinessData);
                TransactionTemplateId = _TransactionTemplate.TransactionTemplateId;
            }

            if (!string.IsNullOrWhiteSpace(TransactionTemplateId))
            {
                _TransactionTemplate = new TransactionTemplate();
                _TransactionTemplate = _ITransactionTemplateService.GetTransactionTemplateById(TransactionTemplateId);
            }
            if (_TransactionTemplate != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_TransactionTemplate, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_TransactionTemplate, "Status Wise Service Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetTransactionTemplateBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _TransactionTemplate = JsonConvert.DeserializeObject<TransactionTemplate>(_requestedDataObject.BusinessData);
                _TransactionTemplate = _ITransactionTemplateService.GetTransactionTemplateBy(_TransactionTemplate);
            }
            if (_TransactionTemplate != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_TransactionTemplate, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_TransactionTemplate, "Status Wise Service Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddTransactionTemplate(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                //_TransactionTemplate = new TransactionTemplate();
                var _TransactionTemplate = JsonConvert.DeserializeObject<TransactionTemplate>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_TransactionTemplate, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ITransactionTemplateService.AddTransactionTemplate(_TransactionTemplate.ListTransactionTemplate_API);
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
        public HttpResponseMessage UpdateTransactionTemplate(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _TransactionTemplate = JsonConvert.DeserializeObject<TransactionTemplate>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_TransactionTemplate, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ITransactionTemplateService.UpdateTransactionTemplate(_TransactionTemplate);
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
        public HttpResponseMessage DeleteTransactionTemplate(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _TransactionTemplate = JsonConvert.DeserializeObject<TransactionTemplate>(_requestedDataObject.BusinessData);
            }

            if (_TransactionTemplate == null || string.IsNullOrWhiteSpace(_TransactionTemplate.TransactionTemplateId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "StatusWise Service Map Id Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _ITransactionTemplateService.DeleteTransactionTemplate(_TransactionTemplate);
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
    }
}