using mTaka.API.Common;
using mTaka.Data.BusinessEntities.Process;
using mTaka.Service.BusinessServices.Process;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace mTaka.API.Areas.Process.Controller
{
    public class OrganogramsController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IOrganogramService _IOrganogramService;
        private IDataManipulation _IDataManipulation;
        Organogram _Organogram = null;
        string _modelErrorMsg = string.Empty;
        public OrganogramsController()
        {
            _IOrganogramService = new OrganogramService();
            _IDataManipulation = new DataManipulation();
        }

        [HttpPost]
        public HttpResponseMessage GetOrganogram(HttpRequestMessage reqObject)
        {
            string walletaccNo = string.Empty;
            Organogram _Organogram = new Organogram();
            _businessData = _IDataManipulation.GetBusinessData(reqObject);


            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _Organogram = JsonConvert.DeserializeObject<Organogram>(_requestedDataObject.BusinessData);
            }
            var result = _IOrganogramService.GetOrganogram(_Organogram);
            //var result = _IOrganogramService.GetChannelMemberData("01913584138");

            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
    }
}