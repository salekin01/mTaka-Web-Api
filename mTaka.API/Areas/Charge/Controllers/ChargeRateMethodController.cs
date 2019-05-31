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
    public class ChargeRateMethodController : ApiController
    {
        private HttpResponseMessage _response;
        private IChargeRateMethodService _IChargeRateMethodService;
        private IDataManipulation _IDataManipulation;
        private APIServiceResponse _serviceResponse;
        public ChargeRateMethodController()
        {
            _IChargeRateMethodService = new ChargeRateMethodService();
            _IDataManipulation = new DataManipulation();
        }
        [HttpPost]
        public HttpResponseMessage GetChargeRateMethodForDD(HttpRequestMessage reqObject)
        {
            var List_ChargeRateMethod = _IChargeRateMethodService.GetChargeRateMethodForDD();
            if (List_ChargeRateMethod != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_ChargeRateMethod, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Charge Rate Method Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
    }
}
