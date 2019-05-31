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
    public class CustomerFilterController : ApiController
    {
        private HttpResponseMessage _response;
        private ICustomerFilterService _ICustomerFilterService;
        private IDataManipulation _IDataManipulation;
        private APIServiceResponse _serviceResponse;
        public CustomerFilterController()
        {
            _ICustomerFilterService = new CustomerFilterService();
            _IDataManipulation = new DataManipulation();
        }
        [HttpPost]
        public HttpResponseMessage GetCustomerFilterForDD(HttpRequestMessage reqObject)
        {
            var List_CustomerFilter = _ICustomerFilterService.GetCustomerFilterForDD();
            if (List_CustomerFilter != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_CustomerFilter, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Customer Filter Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
    }
}
