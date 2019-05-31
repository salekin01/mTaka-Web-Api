using mTaka.API.Common;
using mTaka.Data.BusinessEntities.USB;
using mTaka.Service.BusinessServices.USB;
using mTaka.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using static mTaka.Data.BusinessEntities.USB.UsbInqHeader;
using static mTaka.Data.BusinessEntities.USB.UsbReceive;

namespace mTaka.API.Areas.USB
{
    [Authorize]
    public class UsbReceiveController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private USBServiceRequest _usbRequest;
        private USBServiceRequestBody _usbRequestBody;
        private USBServiceRequestHeader _usbRequestHeader;

        private IUsbParamService _IUsbParamService;
        private IUsbReceiveService _IUsbReceiveService;
        private IDataManipulation _IDataManipulation;
        UsbParamConfig _UsbParam = null;
        UsbReceive _UsbReceive = null;
        UsbParam _UsbParamAPI = null;
        string ResopnsErrMsg = string.Empty;
        public UsbReceiveController()
        {
            _IUsbReceiveService = new UsbReceiveService();
            _IDataManipulation = new DataManipulation();
        }

        #region GetUSBParam
        [HttpPost]
        public HttpResponseMessage GetUsbParam(HttpRequestMessage reqObject)
        {
            string _UsbParam = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _UsbParam = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData);
            }

            var List_USBReportingField = _IUsbReceiveService.GetUsbParam(_UsbParam);
            if (List_USBReportingField != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_USBReportingField, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Parent Account Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region GetBillInfo
        [HttpPost]
        public HttpResponseMessage GetBillInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            string APIADDRESS = null;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                //_UsbParamAPI = JsonConvert.DeserializeObject<UsbParam>(_requestedDataObject.BusinessData);
                //   string PvID = _UsbParamAPI.PvId;
                //   UsbParamService obj_UsbParamService = new UsbParamService();
                //   var AllUsbParam = obj_UsbParamService.GetAPI(PvID);
                //   if (AllUsbParam != null)
                //   {
                //       var json = JsonConvert.SerializeObject(AllUsbParam);
                //      // JArray a = JArray.Parse(json);
                //       //JObject jsonObj = JObject.Parse(json);

                //       //_serviceResponse = _IDataManipulation.SetResponseObject(AllUsbParam, "information has been updated successfully");
                //       //_response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);

                //       //_UsbParamAPI = JsonConvert.DeserializeObject<UsbParam>(_serviceResponse.ResponseBusinessData);
                //       //APIADDRESS = json[0];
                //   }
                //   else
                //   {
                //       APIADDRESS = null;
                //   }
                //UsbReceive obJ_UsbReceive = new UsbReceive();
                //USBServiceRequest obj_USBServiceRequest = new USBServiceRequest();
                _UsbParamAPI = JsonConvert.DeserializeObject<UsbParam>(_requestedDataObject.BusinessData);
                APIADDRESS = _UsbParamAPI.PvApiAddress;
                RootObject obj_RootObject = new RootObject();
                obj_RootObject.body = JsonConvert.DeserializeObject<Body>(_requestedDataObject.BusinessData);
                obj_RootObject.header = JsonConvert.DeserializeObject<Header>(_requestedDataObject.BusinessData);
                dynamic data = JsonConvert.SerializeObject(obj_RootObject);
                //dynamic url = ConfigurationManager.AppSettings["UtilityServiceAPIDev_server"].ToString() + "Service/UtilityServiceBillCollection/Request";
                dynamic url = APIADDRESS;
                using (var client = new WebClient())
                {
                    var response=string.Empty;
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    try
                    {
                        response = client.UploadString(new Uri(url), "POST", data);
                    }
                    catch(Exception ex)
                    {
                        _serviceResponse = _IDataManipulation.SetResponseObject(result, "404 Server not responding!!");
                        _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                        return _response;
                    }

                    if (response != null)
                    {
                        _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(response, "information has been fetched successfully");
                    }
                    else if(response=="")
                    {
                        _serviceResponse = _IDataManipulation.SetResponseObject(result, "404 Server not responding!!");
                    }
                    //obj_RootObject = JsonConvert.DeserializeObject<RootObject>(response);
                    _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                    return _response;
                }

            }
            return _response;
        }
        #endregion

        #region UsbHeaderInfo
        [HttpPost]
        public HttpResponseMessage GetUsbInqHeaderById(HttpRequestMessage reqObject)
        {
            string _UsbParam = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _UsbParam = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData);
            }

            var List_USBReportingField = _IUsbReceiveService.GetUsbInqHeaderById(_UsbParam);
            if (List_USBReportingField != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_USBReportingField, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Parent Account Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region SaveUSB
        [HttpPost]
        public HttpResponseMessage SaveUsb(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                UsbCollection _UsbCollection = new UsbCollection();
                _UsbCollection = JsonConvert.DeserializeObject<UsbCollection>(_requestedDataObject.BusinessData);
                result = _IUsbReceiveService.SaveUsb(_UsbCollection);
            }

            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been added successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Account Type Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region TotalUSBAmount
        [HttpPost]
        public HttpResponseMessage TotalUSBAmount(HttpRequestMessage reqObject)
        {

            var result = _IUsbReceiveService.GetTotalUSBAmount();

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

        #region Daily Collection
        #region DESCO
        [HttpPost]
        public HttpResponseMessage DailyDescoCollection(HttpRequestMessage reqObject)
        {
            var result = _IUsbReceiveService.DailyDescoCollection();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Customer Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
        #endregion

        #region DailyBillList
        [HttpPost]
        public HttpResponseMessage DailyBillList(HttpRequestMessage reqObject)
        {
            string walletaccNo = string.Empty;
            UsbCollection _UsbCollection = new UsbCollection();
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _UsbCollection = JsonConvert.DeserializeObject<UsbCollection>(_requestedDataObject.BusinessData);
                walletaccNo = _UsbCollection.WalletAccountNo;
            }

            var result = _IUsbReceiveService.DailyBillList(_UsbCollection);

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

        #region GetOperatorInfo
        [HttpPost]
        public HttpResponseMessage GetOperatorInfo(HttpRequestMessage reqObject)
        {
            USBReportingField _USBReportingField = null;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _USBReportingField = JsonConvert.DeserializeObject<USBReportingField>(_requestedDataObject.BusinessData);
            }

            var List_USBReportingField = _IUsbReceiveService.GetOperatorInfo(_USBReportingField);
            if (List_USBReportingField != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_USBReportingField, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Parent Account Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }

}