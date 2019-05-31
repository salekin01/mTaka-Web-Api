using mTaka.API.Common;
using mTaka.Service.BusinessServices.Charge;
using mTaka.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.Charge.Controllers
{
    [Authorize]
    public class ChargeRuleTypeController : ApiController
    {
        private HttpResponseMessage _response;
        private IChargeRuleTypeService _IChargeRuleTypeService;
        private IDataManipulation _IDataManipulation;
        private APIServiceResponse _serviceResponse;
        public ChargeRuleTypeController()
        {
            _IChargeRuleTypeService = new ChargeRuleTypeService();
            _IDataManipulation = new DataManipulation();
        }
        [HttpPost]
        public HttpResponseMessage GetChargeRuleTypeForDD(HttpRequestMessage reqObject)
        {
            var List_ChargeRuleType = _IChargeRuleTypeService.GetChargeRuleTypeForDD();
            if (List_ChargeRuleType != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_ChargeRuleType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Charge Rule Type Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
    }
}
