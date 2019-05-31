using mTaka.API.Common;
using mTaka.Data.BusinessEntities.Charge;
using mTaka.Service.BusinessServices.Charge;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.Charge.Controllers
{
    [Authorize]
    public class ChargeRuleController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IChargeRuleService _IChargeRuleService;
        private IDataManipulation _IDataManipulation;
        ChargeRule _ChargeRule = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public ChargeRuleController()
        {
            _IChargeRuleService = new ChargeRuleService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllChargeRules(HttpRequestMessage reqObject)
        {
            var result = _IChargeRuleService.GetAllChargeRules();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Charge Rule Setup Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetChargeRuleById(HttpRequestMessage reqObject)
        {
            string ChargeRuleId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ChargeRule = JsonConvert.DeserializeObject<ChargeRule>(_requestedDataObject.BusinessData);
                ChargeRuleId = _ChargeRule.ChargeRuleId;
            }

            if (!string.IsNullOrWhiteSpace(ChargeRuleId))
            {
                _ChargeRule = new ChargeRule();
                _ChargeRule = _IChargeRuleService.GetChargeRuleById(ChargeRuleId);
            }
            if (_ChargeRule != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ChargeRule, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ChargeRule, "Charge Rule Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetChargeRuleBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ChargeRule = JsonConvert.DeserializeObject<ChargeRule>(_requestedDataObject.BusinessData);
                _ChargeRule = _IChargeRuleService.GetChargeRuleBy(_ChargeRule);
            }
            if (_ChargeRule != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ChargeRule, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_ChargeRule, "Charge Rule Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddChargeRule(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ChargeRule = new ChargeRule();
                _ChargeRule = JsonConvert.DeserializeObject<ChargeRule>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_ChargeRule, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IChargeRuleService.AddChargeRule(_ChargeRule);
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
        public HttpResponseMessage UpdateChargeRule(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ChargeRule = JsonConvert.DeserializeObject<ChargeRule>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_ChargeRule, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IChargeRuleService.UpdateChargeRule(_ChargeRule);
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
        public HttpResponseMessage DeleteChargeRule(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _ChargeRule = JsonConvert.DeserializeObject<ChargeRule>(_requestedDataObject.BusinessData);
            }

            if (_ChargeRule == null || string.IsNullOrWhiteSpace(_ChargeRule.ChargeRuleId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Charge Rule Id Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IChargeRuleService.DeleteChargeRule(_ChargeRule);
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

        #region DropDown
        [HttpPost]
        public HttpResponseMessage GetChargeRuleForDD(HttpRequestMessage reqObject)
        {
            var List_ChargeRule = _IChargeRuleService.GetChargeRuleForDD();
            if (List_ChargeRule != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_ChargeRule, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Charge Rule Info Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}
