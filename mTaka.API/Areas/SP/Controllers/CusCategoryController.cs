using mTaka.API.Common;
using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Service.BusinessServices;
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
    public class CusCategoryController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        //dynamic _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private ICusCategoryService _ICusCategoryService;
        private IDataManipulation _IDataManipulation;
        CusCategory _CusCategory = null;
        string _modelErrorMsg = string.Empty;
        public CusCategoryController()
        {
            _ICusCategoryService = new CusCategoryService();
            _IDataManipulation = new DataManipulation();
        }

        #region Fetch
        [HttpPost]
        public HttpResponseMessage GetAllCusCategory(HttpRequestMessage reqObject)
        {
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            var result = _ICusCategoryService.GetAllCusCategory();
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
        [HttpPost]
        public HttpResponseMessage GetCusCategoryById(HttpRequestMessage reqObject)
        {
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            //CusCategory _CusCategory = null;
            //string CusCategoryId = _businessData["CusCategoryId"] != null ? _businessData["CusCategoryId"].ToString() : string.Empty;
            string CusCategoryId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusCategory = JsonConvert.DeserializeObject<CusCategory>(_requestedDataObject.BusinessData);
                CusCategoryId = _CusCategory.CusCategoryId;
            }

            if (!string.IsNullOrWhiteSpace(CusCategoryId))
            {
                _CusCategory = new CusCategory();
                _CusCategory = _ICusCategoryService.GetCusCategoryById(CusCategoryId);
            }
            if (_CusCategory != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CusCategory, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CusCategory, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        [HttpPost]
        public HttpResponseMessage GetCusCategoryBy(HttpRequestMessage reqObject)
        {
            string CusCategoryId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusCategory = JsonConvert.DeserializeObject<CusCategory>(_requestedDataObject.BusinessData);
                CusCategoryId = _CusCategory.CusCategoryId;
            }

            if (!string.IsNullOrWhiteSpace(CusCategoryId))
            {
                _CusCategory = new CusCategory();
                _CusCategory = _ICusCategoryService.GetCusCategoryBy(CusCategoryId);
            }
            if (_CusCategory != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CusCategory, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_CusCategory, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddCusCategory(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusCategory = JsonConvert.DeserializeObject<CusCategory>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_CusCategory, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICusCategoryService.AddCusCategory(_CusCategory);
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
        public HttpResponseMessage UpdateCusCategory(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusCategory = JsonConvert.DeserializeObject<CusCategory>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_CusCategory, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ICusCategoryService.UpdateCusCategory(_CusCategory);
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
        public HttpResponseMessage DeleteCusCategory(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _CusCategory = JsonConvert.DeserializeObject<CusCategory>(_requestedDataObject.BusinessData);
            }

            if (_CusCategory == null || string.IsNullOrWhiteSpace(_CusCategory.CusCategoryId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Customer GroupId Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _ICusCategoryService.DeleteCusCategory(_CusCategory);
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

        #region DropDown
        [HttpPost]
        public HttpResponseMessage GetCusCategoryForDD(HttpRequestMessage reqObject)
        {
            var List_CusCategory = _ICusCategoryService.GetCusCategoryForDD();
            if (List_CusCategory != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(List_CusCategory, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(List_CusCategory, "Data Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        [HttpGet]
        public HttpResponseMessage GetTest()
        {
            return _response;
        }
        #region Old Way

        /*
        public IEnumerable<CusCategory> GetAllCusCategory()
        {
            var result = _ICusCategoryBLL.GetAllCusCategory();
            return result;
        }

        public CusCategory GetCusCategoryById(string id)
        {
            return _ICusCategoryBLL.GetCusCategoryById(id);
        }

        public int Post([FromBody]dynamic value)
        {
            return _ICusCategoryBLL.AddCusCategory(value);
        }

        public int Put(int id, [FromBody]dynamic value)
        {
            return _ICusCategoryBLL.UpdateCusCategory(value);
        }

        public int Delete([FromBody]dynamic value)
        {
            return _ICusCategoryBLL.deleteCusCategory(value);
        } */

        #endregion Old Way
    }

    //public static class Test
    //{
    //    public static T FromDynamic<T>(this IDictionary<string, object> dictionary)
    //    {
    //        var bindings = new List<MemberBinding>();
    //        foreach (var sourceProperty in typeof(T).GetProperties().Where(x => x.CanWrite))
    //        {
    //            var key = dictionary.Keys.SingleOrDefault(x => x.Equals(sourceProperty.Name, StringComparison.OrdinalIgnoreCase));
    //            if (string.IsNullOrEmpty(key)) continue;
    //            var propertyValue = dictionary[key];
    //            bindings.Add(Expression.Bind(sourceProperty, Expression.Constant(propertyValue)));
    //        }
    //        Expression memberInit = Expression.MemberInit(Expression.New(typeof(T)), bindings);
    //        return Expression.Lambda<Func<T>>(memberInit).Compile().Invoke();
    //    }
    //}
}