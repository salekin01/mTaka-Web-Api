using mTaka.API.Common;
using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Service.BusinessServices;
using mTaka.Service.BusinessServices.ACC;
using mTaka.Service.BusinessServices.SP;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.SP.Controllers
{
    [Authorize]
    public class AccTypeWiseTargetController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IAccTypeWiseTargetService _IAccTypeWiseTargetService;
        private IDataManipulation _IDataManipulation;
        AccTypeWiseTarget _AccTypeWiseTarget = null;
        string ResopnsErrMsg = string.Empty;
        public AccTypeWiseTargetController()
        {
            _IAccTypeWiseTargetService = new AccTypeWiseTargetService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index

        [HttpPost]
        public HttpResponseMessage GetAllAccTypeWiseTarget(HttpRequestMessage reqObject)
        {
            var result = _IAccTypeWiseTargetService.GetAllAccTypeWiseTarget();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Account Types Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetAccTypeWiseTargetById(HttpRequestMessage reqObject)
        {
            return null;
        }

        [HttpPost]
        public HttpResponseMessage GetAccTypeWiseTargetBy(HttpRequestMessage reqObject)
        {
            return null;
        }

        #endregion

        #region Add

        [HttpPost]
        public HttpResponseMessage AddAccTypeWiseTarget(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccTypeWiseTarget = JsonConvert.DeserializeObject<AccTypeWiseTarget>(_requestedDataObject.BusinessData);
                result = _IAccTypeWiseTargetService.AddAccTypeWiseTarget(_AccTypeWiseTarget);
            }

            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been added successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Information hasn't been added");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region Edit

        [HttpPost]
        public HttpResponseMessage UpdateAccTypeWiseTarget(HttpRequestMessage reqObject)
        {
            return null;
        }

        #endregion

        #region Delete

        [HttpPost]
        public HttpResponseMessage DeleteAccTypeWiseTarget(HttpRequestMessage reqObject)
        {
            return null;
        }

        #endregion

        #region GetTargetInfoForGraph
        [HttpPost]
        public HttpResponseMessage GetTargetInfoForGraph(HttpRequestMessage reqObject)
        {
            string walletaccNo = string.Empty;
            AccTypeWiseTarget _AccTypeWiseTarget = new AccTypeWiseTarget();
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccTypeWiseTarget = JsonConvert.DeserializeObject<AccTypeWiseTarget>(_requestedDataObject.BusinessData);
            }

            var result = _IAccTypeWiseTargetService.GetTargetInfoForGraph(_AccTypeWiseTarget);

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
        #endregion
    }
}