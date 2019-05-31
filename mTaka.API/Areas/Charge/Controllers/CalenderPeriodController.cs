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
    public class CalenderPeriodController : ApiController
    {
        private HttpResponseMessage _response;
        private ICalenderPeriodService _ICalenderPeriodService;
        private IDataManipulation _IDataManipulation;
        private APIServiceResponse _serviceResponse;
        public CalenderPeriodController()
        {
            _ICalenderPeriodService = new CalenderPeriodService();
            _IDataManipulation = new DataManipulation();
        }
        [HttpPost]
        public HttpResponseMessage GetCalenderPeriodForDD(HttpRequestMessage reqObject)
        {
            var List_CalenderPeriod = _ICalenderPeriodService.GetCalenderPeriodForDD();
            if (List_CalenderPeriod != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_CalenderPeriod, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Calender Period Info Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
    }
}
