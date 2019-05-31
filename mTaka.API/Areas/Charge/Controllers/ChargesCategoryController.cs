using mTaka.API.Common;
using mTaka.Service.BusinessServices.Charge;
using mTaka.Utility;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.Charge.Controllers
{
    [Authorize]
    public class ChargesCategoryController : ApiController
    {
        private HttpResponseMessage _response;
        private IChargesCategoryService _IChargesCategoryService;
        private IDataManipulation _IDataManipulation;
        private APIServiceResponse _serviceResponse;
        public ChargesCategoryController()
        {
            _IChargesCategoryService = new ChargesCategoryService();
            _IDataManipulation = new DataManipulation();
        }
        [HttpPost]
        public HttpResponseMessage GetChargesCategoryForDD(HttpRequestMessage reqObject)
        {
            var List_ChargesCategory = _IChargesCategoryService.GetChargesCategoryForDD();
            if (List_ChargesCategory != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_ChargesCategory, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Charge Category Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
    }
}
