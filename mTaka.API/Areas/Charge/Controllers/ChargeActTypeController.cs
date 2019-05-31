using mTaka.API.Common;
using mTaka.Service.BusinessServices.Charge;
using mTaka.Utility;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.Charge.Controllers
{
    [Authorize]
    public class ChargeActTypeController : ApiController
    {
        private HttpResponseMessage _response;
        private IChargeActTypeService _IChargeActTypeService;
        private IDataManipulation _IDataManipulation;
        private APIServiceResponse _serviceResponse;
        public ChargeActTypeController()
        {
            _IChargeActTypeService = new ChargeActTypeService();
            _IDataManipulation = new DataManipulation();
        }
        [HttpPost]
        public HttpResponseMessage GetChargeActTypeForDD(HttpRequestMessage reqObject)
        {
            var List_CalenderPeriod = _IChargeActTypeService.GetChargeActTypeForDD();
            if (List_CalenderPeriod != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_CalenderPeriod, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Charge Actual Type Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
    }
}
