using mTaka.API.Common;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Service.BusinessServices.CP;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace mTaka.API.Areas.CP.Controllers
{
    [Authorize]
    public class IdentificationTypeController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IIdentificationTypeService _IIdentificationTypeService;
        private IDataManipulation _IDataManipulation;
        IdentificationType _IdentificationType = null;
        string ResopnsErrMsg = string.Empty;
        public IdentificationTypeController()
        {
            _IIdentificationTypeService = new IdentificationTypeService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllCustomer(HttpRequestMessage reqObject)
        {
            var result = _IIdentificationTypeService.GetAllIdentificationType();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Identification Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetIdentificationById(HttpRequestMessage reqObject)
        {
            string IdentificationId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _IdentificationType = JsonConvert.DeserializeObject<IdentificationType>(_requestedDataObject.BusinessData);
                IdentificationId = _IdentificationType.IdentificationId;
            }

            if (!string.IsNullOrWhiteSpace(IdentificationId))
            {
                _IdentificationType = new IdentificationType();
                _IdentificationType = _IIdentificationTypeService.GetIdentificationTypeById(IdentificationId);
            }
            if (_IdentificationType != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(_IdentificationType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Identification Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetIdentificationBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _IdentificationType = JsonConvert.DeserializeObject<IdentificationType>(_requestedDataObject.BusinessData);
                _IdentificationType = _IIdentificationTypeService.GetIdentificationTypeBy(_IdentificationType);
            }
            if (_IdentificationType != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(_IdentificationType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Identification Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddIdentificationType(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _IdentificationType = JsonConvert.DeserializeObject<IdentificationType>(_requestedDataObject.BusinessData);
                result = _IIdentificationTypeService.AddIdentificationType(_IdentificationType);
            }

            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been added successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Identification Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Edit
        [HttpPost]
        public HttpResponseMessage UpdateAccGroup(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _IdentificationType = JsonConvert.DeserializeObject<IdentificationType>(_requestedDataObject.BusinessData);
            }

            if (_IdentificationType == null || string.IsNullOrWhiteSpace(_IdentificationType.IdentificationId))
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Identification Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IIdentificationTypeService.UpdateIdentificationType(_IdentificationType);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been updated successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Identification Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        //#region Delete
        //[HttpPost]
        //public HttpResponseMessage DeleteAccGroup(HttpRequestMessage reqObject)
        //{
        //    _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
        //    if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
        //    {
        //        _AccGroup = JsonConvert.DeserializeObject<AccGroup>(_requestedDataObject.BusinessData);
        //    }

        //    if (_AccGroup == null || string.IsNullOrWhiteSpace(_AccGroup.AccGroupId))
        //    {
        //        _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Account GroupId Not Found...");
        //        _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
        //        return _response;
        //    }

        //    var result = _IAccGroupService.DeleteAccGroup(_AccGroup);
        //    if (result == 1)
        //    {
        //        _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been deleted successfully");
        //    }
        //    else
        //    {
        //        _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Account Groups Not Found...");
        //    }
        //    _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
        //    return _response;
        //}
        //#endregion

        #region Dropdown

        [HttpPost]
        public HttpResponseMessage GetIdentificationTypeForDD(HttpRequestMessage reqObject)
        {
            var List_Customer_Identification = _IIdentificationTypeService.GetIdentificationTypeForDD();
            if (List_Customer_Identification != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_Customer_Identification, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Identification Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}
