using mTaka.API.Common;
using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Data.BusinessEntities.TRN;
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
    public class StatusWiseServiceController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IStatusWiseServiceService _IStatusWiseServiceService;
        private IDataManipulation _IDataManipulation;
        StatusWiseService _StatusWiseService = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public StatusWiseServiceController()
        {
            _IStatusWiseServiceService = new StatusWiseServiceService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllStatusWiseService(HttpRequestMessage reqObject)
        {
            var result = _IStatusWiseServiceService.GetAllStatusWiseService();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Status Wise Services Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetStatusWiseServiceById(HttpRequestMessage reqObject)
        {
            string StatusWiseServiceId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _StatusWiseService = JsonConvert.DeserializeObject<StatusWiseService>(_requestedDataObject.BusinessData);
                StatusWiseServiceId = _StatusWiseService.StatusWiseServiceId;
            }

            if (!string.IsNullOrWhiteSpace(StatusWiseServiceId))
            {
                _StatusWiseService = new StatusWiseService();
                _StatusWiseService = _IStatusWiseServiceService.GetStatusWiseServiceById(StatusWiseServiceId);
            }
            if (_StatusWiseService != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_StatusWiseService, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_StatusWiseService, "Status Wise Service Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetStatusWiseServiceBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _StatusWiseService = JsonConvert.DeserializeObject<StatusWiseService>(_requestedDataObject.BusinessData);
                _StatusWiseService = _IStatusWiseServiceService.GetStatusWiseServiceBy(_StatusWiseService);
            }
            if (_StatusWiseService != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_StatusWiseService, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_StatusWiseService, "Status Wise Service Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddStatusWiseService(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _StatusWiseService = new StatusWiseService();
                _StatusWiseService = JsonConvert.DeserializeObject<StatusWiseService>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_StatusWiseService, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IStatusWiseServiceService.AddStatusWiseService(_StatusWiseService);
                }
            }
            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, _modelErrorMsg);
            }
            else if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been added successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information hasn't been added");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Edit
        [HttpPost]
        public HttpResponseMessage UpdateStatusWiseService(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _StatusWiseService = JsonConvert.DeserializeObject<StatusWiseService>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_StatusWiseService, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IStatusWiseServiceService.UpdateStatusWiseService(_StatusWiseService);
                }
            }

            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, _modelErrorMsg);
            }
            else if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been updated successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information hasn't been updated");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Delete
        [HttpPost]
        public HttpResponseMessage DeleteStatusWiseService(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _StatusWiseService = JsonConvert.DeserializeObject<StatusWiseService>(_requestedDataObject.BusinessData);
            }

            if (_StatusWiseService == null || string.IsNullOrWhiteSpace(_StatusWiseService.StatusWiseServiceId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "StatusWise Service Map Id Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IStatusWiseServiceService.DeleteStatusWiseService(_StatusWiseService);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been deleted successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information hasn't been deleted");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion        

        //#region CheckStatusWiseService
        //[HttpPost]        
        //public HttpResponseMessage CheckStatusWiseService(HttpRequestMessage reqObject)
        //{
        //    string ToSystemAccountNo = string.Empty;
        //    int Result = 0;
        //    _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
        //    if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
        //    {
        //        _StatusWiseService = JsonConvert.DeserializeObject<StatusWiseService>(_requestedDataObject.BusinessData);
        //        ToSystemAccountNo = _StatusWiseService.ToSystemAccountNo;
        //    }
        //    if (!string.IsNullOrWhiteSpace(ToSystemAccountNo))
        //    {
        //        Result = _IStatusWiseServiceService.CheckStatusWiseService(_StatusWiseService);
        //    }
        //    if (Result != 0)
        //    {
        //        _serviceResponse = _IDataManipulation.SetResponseObject(Result, "this account no. is active for transaction");
        //    }
        //    else
        //    {
        //        _serviceResponse = _IDataManipulation.SetResponseObject(Result, "Account No. is not active for this transaction..");
        //    }
        //    _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
        //    return _response;
        //}
        //#endregion
    }
}