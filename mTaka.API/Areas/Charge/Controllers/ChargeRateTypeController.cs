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
    public class ChargeRateTypeController : ApiController
    {
        private HttpResponseMessage _response;
        private IChargeRateTypeService _IChargeRateTypeService;
        private IDataManipulation _IDataManipulation;
        private APIServiceResponse _serviceResponse;
        public ChargeRateTypeController()
        {
            _IChargeRateTypeService = new ChargeRateTypeService();
            _IDataManipulation = new DataManipulation();
        }
        [HttpPost]
        public HttpResponseMessage GetChargeRateTypeForDD(HttpRequestMessage reqObject)
        {
            var List_ChargeRateType = _IChargeRateTypeService.GetChargeRateTypeForDD();
            if (List_ChargeRateType != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_ChargeRateType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Charge Rate Type Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
    }
}
