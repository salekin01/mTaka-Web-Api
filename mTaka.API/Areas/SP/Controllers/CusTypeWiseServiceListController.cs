using mTaka.API.Common;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Service.BusinessServices.SP;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace mTaka.API.Areas.SP.Controllers
{
    [Authorize]
    public class CusTypeWiseServiceListController : ApiController
    {
         private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private ICusTypeWiseServiceListService _ICusTypeWiseServiceListService;
        private IDataManipulation _IDataManipulation;
        CusTypeWiseServiceList _CusTypeWiseServiceList = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public CusTypeWiseServiceListController()
        {
            _ICusTypeWiseServiceListService = new CusTypeWiseServiceListService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index

        [HttpPost]
        public HttpResponseMessage GetAllCusTypeWiseServiceList(HttpRequestMessage reqObject)
        {
            var result = _ICusTypeWiseServiceListService.GetAllCusTypeWiseServiceList();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result,"Customer Type Wise Service s Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetCusTypeWiseServiceListById(HttpRequestMessage reqObject)
        {
            string CustomerServiceId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusTypeWiseServiceList = JsonConvert.DeserializeObject<CusTypeWiseServiceList>(_requestedDataObject.BusinessData);
                CustomerServiceId = _CusTypeWiseServiceList.DefineServiceId;
            }

            if (!string.IsNullOrWhiteSpace(CustomerServiceId))
            {
                _CusTypeWiseServiceList = new CusTypeWiseServiceList();
                _CusTypeWiseServiceList = _ICusTypeWiseServiceListService.GetCusTypeWiseServiceListById(CustomerServiceId);
            }
            if (_CusTypeWiseServiceList != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(_CusTypeWiseServiceList, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Customer Type Wise Service  Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetCusTypeWiseServiceListBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusTypeWiseServiceList = JsonConvert.DeserializeObject<CusTypeWiseServiceList>(_requestedDataObject.BusinessData);
                _CusTypeWiseServiceList = _ICusTypeWiseServiceListService.GetCusTypeWiseServiceListBy(_CusTypeWiseServiceList);
            }
            if (_CusTypeWiseServiceList != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(_CusTypeWiseServiceList, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Customer Type Wise Service  Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region Add

        [HttpPost]
        public HttpResponseMessage AddCusTypeWiseServiceList(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusTypeWiseServiceList = JsonConvert.DeserializeObject<CusTypeWiseServiceList>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_CusTypeWiseServiceList, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICusTypeWiseServiceListService.AddCusTypeWiseServiceList(_CusTypeWiseServiceList);
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
                _serviceResponse = _IDataManipulation.SetResponseObject(result,"Customer Type Wise Service  Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region Edit

        [HttpPost]
        public HttpResponseMessage UpdateCusTypeWiseServiceList(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusTypeWiseServiceList = JsonConvert.DeserializeObject<CusTypeWiseServiceList>(_requestedDataObject.BusinessData);
            }

            if (_CusTypeWiseServiceList == null || string.IsNullOrWhiteSpace(_CusTypeWiseServiceList.CusTypeWiseServiceId))
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Customer Type Wise Service  Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _ICusTypeWiseServiceListService.UpdateCusTypeWiseServiceList(_CusTypeWiseServiceList);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been updated successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Customer Type Wise Service s Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region Delete

        [HttpPost]
        public HttpResponseMessage DeleteCusTypeWiseServiceList(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusTypeWiseServiceList = JsonConvert.DeserializeObject<CusTypeWiseServiceList>(_requestedDataObject.BusinessData);
            }

            if (_CusTypeWiseServiceList == null || string.IsNullOrWhiteSpace(_CusTypeWiseServiceList.DefineServiceId))
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Customer Type Wise Service Id Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            var result = _ICusTypeWiseServiceListService.DeleteCusTypeWiseServiceList(_CusTypeWiseServiceList);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been deleted successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Customer Type Wise Service s Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion


        [HttpPost]
        public HttpResponseMessage AccTypeForCusCategory(HttpRequestMessage reqObject)
        {
            string AccCategoryId=null;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusTypeWiseServiceList = JsonConvert.DeserializeObject<CusTypeWiseServiceList>(_requestedDataObject.BusinessData);
                AccCategoryId = _CusTypeWiseServiceList.AccCategoryId;
            }

            var List_AccType = _ICusTypeWiseServiceListService.AccTypeForCusCategory(AccCategoryId);
            if (List_AccType != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_AccType, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Parent Account Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
    }
}