using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace mTaka.API.Common
{
    public interface IDataManipulation
    {
        Task<APIServiceRequest> GetRequestedDataObjectAsync(HttpRequestMessage reqObject);
        APIServiceRequest GetRequestedDataObject(HttpRequestMessage reqObject);
        Newtonsoft.Json.Linq.JObject GetBusinessData(HttpRequestMessage reqObject);
        APIServiceResponse SetResponseObject<T>(T _result, string _Msg);
        Task<APIServiceResponse> SetResponseObjectAsync<T>(T _result, string _Msg) ;
        HttpResponseMessage CreateResponse(APIServiceResponse _serviceResponse, HttpRequestMessage reqObject);
        Task<HttpResponseMessage> CreateResponseAsync(APIServiceResponse _serviceResponse, HttpRequestMessage reqObject);
        APIServiceResponse ResopnseWhenDataFound<T>(T businessData, string successMessage);
        APIServiceResponse ResopnseWhenDataNotFound(string errorMessage);
        HttpResponseMessage CreateHttpResponseXml(string responseXml);


        //Utility Bill Request

        #region USB

        //USBServiceRequestHeader GetUSBRequestedDataObject(HttpRequestMessage UsbReqObject);

        #endregion

    }
    public class DataManipulation : ApiController, IDataManipulation
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        //dynamic _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        //Utility Bill Request
        #region USB
        //private USBServiceRequestHeader _usbRequestedDataObject;
        #endregion

        public async Task<APIServiceRequest> GetRequestedDataObjectAsync(HttpRequestMessage reqObject)
        {
            _requestedData = reqObject.Content.ReadAsStringAsync().Result;
            _requestedDataObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<APIServiceRequest>(_requestedData));
            return _requestedDataObject;
        }
        public APIServiceRequest GetRequestedDataObject(HttpRequestMessage reqObject)
        {
            _requestedData = reqObject.Content.ReadAsStringAsync().Result;
            _requestedDataObject = JsonConvert.DeserializeObject<APIServiceRequest>(_requestedData);
            return _requestedDataObject;
        }
        public Newtonsoft.Json.Linq.JObject GetBusinessData(HttpRequestMessage reqObject)
        {
            _requestedData = reqObject.Content.ReadAsStringAsync().Result;
            _requestedDataObject = JsonConvert.DeserializeObject<APIServiceRequest>(_requestedData);
            _businessData = (_requestedDataObject != null && _requestedDataObject.BusinessData != null) ? Newtonsoft.Json.Linq.JObject.Parse(_requestedDataObject.BusinessData) : null;
            return _businessData;

            //var serializer = new JavaScriptSerializer();
            //_businessData = serializer.Deserialize(_requestedDataObject.BusinessData, typeof(object));

            //_businessData = serializer.Deserialize<List<object>>(_requestedDataObject.BusinessData);
            //JArray json = JArray.Parse(_requestedDataObject.BusinessData);

            //var dictionary = (IDictionary<string, dynamic>)serializer.DeserializeObject(_requestedDataObject.BusinessData);
            //CusCategory oki = Test.FromDynamic<CusCategory>(dictionary);
            //List<CusCategory> test1 = _businessData.Cast<CusCategory>().ToList();
        }



        public APIServiceResponse SetResponseObject<T>(T _result, string _Msg)
        {
            if (_result != null && (_result.GetType() == typeof(int) || _result.GetType() == typeof(decimal)))
            {
                dynamic DynamicBizObject = new System.Dynamic.ExpandoObject();
                DynamicBizObject.Result = _result;
                DynamicBizObject.ResponseMessage = _Msg;
                if (_result.Equals(1))
                {
                    _serviceResponse = ResopnseData(DynamicBizObject, _Msg, true);
                }
                else
                {
                    _serviceResponse = ResopnseData(DynamicBizObject, _Msg, false);
                }
            }
            else
            {
                if (_result != null)
                {
                    _serviceResponse = ResopnseData(_result, _Msg, true);
                }
                else
                {
                    dynamic DynamicBizObject = new System.Dynamic.ExpandoObject();
                    DynamicBizObject.Result = _result;
                    DynamicBizObject.ResponseMessage = _Msg;
                    _serviceResponse = ResopnseData(DynamicBizObject, _Msg, false);
                }
            }
            return _serviceResponse;
        }

        public async Task<APIServiceResponse> SetResponseObjectAsync<T>(T _result, string _Msg) 
        {
            if (_result != null && (_result.GetType() == typeof(int) || _result.GetType() == typeof(decimal)))
            {
                dynamic DynamicBizObject = new System.Dynamic.ExpandoObject();
                DynamicBizObject.Result = _result;
                DynamicBizObject.ResponseMessage = _Msg;
                if (_result.Equals(1))
                {
                    _serviceResponse = await ResopnseDataAsync(DynamicBizObject, _Msg, true);
                }
                else
                {
                    _serviceResponse = await ResopnseDataAsync(DynamicBizObject, _Msg, false);
                }
            }
            else
            {
                if (_result != null)
                {
                    dynamic DynamicBizObject = new System.Dynamic.ExpandoObject();
                    DynamicBizObject.Result = _result;
                    DynamicBizObject.ResponseMessage = _Msg;
                    _serviceResponse = await ResopnseDataAsync(DynamicBizObject, _Msg, true);
                }
                else
                {
                    dynamic DynamicBizObject = new System.Dynamic.ExpandoObject();
                    DynamicBizObject.Result = _result;
                    DynamicBizObject.ResponseMessage = _Msg;
                    _serviceResponse = await ResopnseDataAsync(DynamicBizObject, _Msg, false);
                }
            }
            return _serviceResponse;
        }

        public APIServiceResponse ResopnseData<T>(T businessData, string _ResponseMessage, bool _ResponseStatus)
        {
            _serviceResponse = new APIServiceResponse();
            _serviceResponse.ResponseStatus = _ResponseStatus;
            if (_requestedDataObject != null)
            {
                _serviceResponse.UserId = _requestedDataObject.UserId;
                _serviceResponse.BranchId = _requestedDataObject.BranchId;
                _serviceResponse.RequestId = _requestedDataObject.RequestId;

            }
            _serviceResponse.ResponseDateTime = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            _serviceResponse.ResponseMessage = _ResponseMessage;
            _serviceResponse.ResponseBusinessData = JsonConvert.SerializeObject(businessData);
            return _serviceResponse;
        }
        public async Task<APIServiceResponse> ResopnseDataAsync<T>(T businessData, string _ResponseMessage, bool _ResponseStatus)
        {
            _serviceResponse = new APIServiceResponse();
            _serviceResponse.ResponseStatus = _ResponseStatus;
            if (_requestedDataObject != null)
            {
                _serviceResponse.UserId = _requestedDataObject.UserId;
                _serviceResponse.BranchId = _requestedDataObject.BranchId;
                _serviceResponse.RequestId = _requestedDataObject.RequestId;

            }
            _serviceResponse.ResponseDateTime = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            _serviceResponse.ResponseMessage = _ResponseMessage;
            _serviceResponse.ResponseBusinessData = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(businessData));
            return _serviceResponse;
        }
        public HttpResponseMessage CreateResponse(APIServiceResponse _serviceResponse, HttpRequestMessage reqObject)
        {
            string result = JsonConvert.SerializeObject(_serviceResponse);
            _response = reqObject.CreateResponse(HttpStatusCode.OK);
            _response.Content = new StringContent(result, Encoding.UTF8, "application/json");
            return _response;
        }

        public async Task<HttpResponseMessage> CreateResponseAsync(APIServiceResponse _serviceResponse, HttpRequestMessage reqObject)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(_serviceResponse));
            _response = reqObject.CreateResponse(HttpStatusCode.OK);
            _response.Content = new StringContent(result, Encoding.UTF8, "application/json");
            return _response;
        }
        public HttpResponseMessage CreateHttpResponseXml(string responseXml)
        {
            var responsemessage = new HttpResponseMessage();
            responsemessage.StatusCode = HttpStatusCode.Accepted;
            responsemessage.Content = new StringContent(responseXml, Encoding.UTF8, "application/xml");
            return responsemessage;
        }




        public APIServiceResponse ResopnseWhenDataFound<T>(T businessData, string successMessage)
        {
            _serviceResponse = new APIServiceResponse();
            _serviceResponse.ResponseStatus = true;
            if (_requestedDataObject != null)
            {
                _serviceResponse.UserId = _requestedDataObject.UserId;
                _serviceResponse.BranchId = _requestedDataObject.BranchId;
                _serviceResponse.RequestId = _requestedDataObject.RequestId;

            }
            _serviceResponse.ResponseDateTime = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            _serviceResponse.ResponseMessage = successMessage;
            _serviceResponse.ResponseBusinessData = JsonConvert.SerializeObject(businessData);
            return _serviceResponse;
        }
        public APIServiceResponse ResopnseWhenDataNotFound(string errorMessage)
        {
            _serviceResponse = new APIServiceResponse();
            _serviceResponse.ResponseStatus = false;
            if (_requestedDataObject != null)
            {
                _serviceResponse.UserId = _requestedDataObject.UserId;
                _serviceResponse.BranchId = _requestedDataObject.BranchId;
                _serviceResponse.RequestId = _requestedDataObject.RequestId;
            }
            _serviceResponse.ResponseDateTime = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            _serviceResponse.ResponseMessage = errorMessage;
            return _serviceResponse;
        }



        /*
        private void GetRequestedDataObject(HttpRequestMessage reqObject)
        {
            _requestedData = reqObject.Content.ReadAsStringAsync().Result;
            _requestedDataObject = JsonConvert.DeserializeObject<APIServiceRequest>(_requestedData);
        }
        private void GetBusinessData(HttpRequestMessage reqObject)
        {
            _requestedData = reqObject.Content.ReadAsStringAsync().Result;
            _requestedDataObject = JsonConvert.DeserializeObject<APIServiceRequest>(_requestedData);
            _businessData = _requestedDataObject.BusinessData != null ? Newtonsoft.Json.Linq.JObject.Parse(_requestedDataObject.BusinessData) : null;

            //var serializer = new JavaScriptSerializer();
            //_businessData = serializer.Deserialize(_requestedDataObject.BusinessData, typeof(object));

            //_businessData = serializer.Deserialize<List<object>>(_requestedDataObject.BusinessData);
            //JArray json = JArray.Parse(_requestedDataObject.BusinessData);

            //var dictionary = (IDictionary<string, dynamic>)serializer.DeserializeObject(_requestedDataObject.BusinessData);
            //CusCategory oki = Test.FromDynamic<CusCategory>(dictionary);
            //List<CusCategory> test1 = _businessData.Cast<CusCategory>().ToList();
        }
        private void ResopnseWhenDataFound<T>(T businessData)
        {
            _serviceResponse = new APIServiceResponse();
            _serviceResponse.ResponseStatus = true;
            _serviceResponse.UserId = _requestedDataObject.UserId;
            _serviceResponse.BranchId = _requestedDataObject.BranchId;
            _serviceResponse.ResponseDateTime = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            _serviceResponse.RequestId = _requestedDataObject.RequestId;
            _serviceResponse.ResponseBusinessData = JsonConvert.SerializeObject(businessData);
        }
        private void ResopnseWhenDataNotFound(string errorMessage)
        {
            _serviceResponse = new APIServiceResponse();
            _serviceResponse.ResponseStatus = true;
            _serviceResponse.UserId = _requestedDataObject.UserId;
            _serviceResponse.BranchId = _requestedDataObject.BranchId;
            _serviceResponse.ResponseDateTime = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            _serviceResponse.RequestId = _requestedDataObject.RequestId;
            _serviceResponse.ResponseMessage = errorMessage;
        }
        private void CreateResponse()
        {
            string result = JsonConvert.SerializeObject(_serviceResponse);
            _response = Request.CreateResponse(HttpStatusCode.OK);
            _response.Content = new StringContent(result, Encoding.UTF8, "application/json");
        }  */

        //USB Bill Request
        #region USB
        //public USBServiceRequestHeader GetUSBRequestedDataObject(HttpRequestMessage UsbReqObject)
        //{
        //    _requestedData = UsbReqObject.Content.ReadAsStringAsync().Result;
        //    _usbRequestedDataObject = JsonConvert.DeserializeObject<USBServiceRequestHeader>(_requestedData);
        //    return _usbRequestedDataObject;
        //}
        #endregion

    }
}