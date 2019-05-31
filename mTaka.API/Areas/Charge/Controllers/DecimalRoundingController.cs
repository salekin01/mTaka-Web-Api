using mTaka.API.Common;
using mTaka.Service.BusinessServices.Charge;
using mTaka.Utility;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.Charge.Controllers
{
    [Authorize]
    public class DecimalRoundingController : ApiController
    {
        private HttpResponseMessage _response;
        private IDecimalRoundingService _IDecimalRoundingService;
        private IDataManipulation _IDataManipulation;
        private APIServiceResponse _serviceResponse;
        public DecimalRoundingController()
        {
            _IDecimalRoundingService = new DecimalRoundingService();
            _IDataManipulation = new DataManipulation();
        }
        [HttpPost]
        public HttpResponseMessage GetDecimalRoundingForDD(HttpRequestMessage reqObject)
        {
            var List_DecimalRounding = _IDecimalRoundingService.GetDecimalRoundingForDD();
            if (List_DecimalRounding != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_DecimalRounding, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Rounding Info Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
    }
}
