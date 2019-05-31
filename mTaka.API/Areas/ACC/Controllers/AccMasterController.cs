using mTaka.API.Common;
using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Service.BusinessServices;
using mTaka.Service.BusinessServices.ACC;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace mTaka.API.Areas.ACC.Controllers
{
    [Authorize]
    public class AccMasterController : ApiController
    {
        
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IAccInfoService _IAccInfoService;
        private IDataManipulation _IDataManipulation;
        AccMaster _AccInfo = null;
        CustomerAccProfile _customerAccProfile = null;
        string _modelErrorMsg = string.Empty;


        public AccMasterController()
        {
            _IAccInfoService = new AccMasterService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllAccInfo(HttpRequestMessage reqObject)
        {
            //_businessData = _IDataManipulation.GetBusinessData(reqObject);
            var result = _IAccInfoService.GetAllAccInfo();

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

        #region Add
        [HttpPost]
        public HttpResponseMessage AddAccInfo(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccInfo = JsonConvert.DeserializeObject<AccMaster>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_AccInfo, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IAccInfoService.AddAccInfo(_AccInfo);
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

        //#region GetAccInfo
        //[HttpPost]
        //public HttpResponseMessage GetAccInfo(HttpRequestMessage reqObject)
        //{
        //    AccInfo Acc_Info = new AccInfo();
        //    string WalletAccountNo = "";
        //    _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
        //    if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
        //    {
        //        WalletAccountNo = JsonConvert.DeserializeObject<string>(_requestedDataObject.BusinessData);
        //    }
        //    Acc_Info = _IAccInfoService.GetAccInfo(WalletAccountNo);
        //    if (Acc_Info != null)
        //    {
        //        _serviceResponse = _IDataManipulation.SetResponseObject(Acc_Info, "information has been fetched successfully");
        //    }
        //    else
        //    {
        //        _serviceResponse = _IDataManipulation.SetResponseObject(Acc_Info, "Account No. Not Found...");
        //    }
        //    _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
        //    return _response;
        //}
        //#endregion

        #region GetAccInfoForDD
        [HttpPost]
        public HttpResponseMessage GetAccInfoForDD(HttpRequestMessage reqObject)
        {
            var List_AccNo = _IAccInfoService.GetAccNoForDD();
            if (List_AccNo != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_AccNo, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Parent Account Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region GetAccInfo
        [HttpPost]
        public HttpResponseMessage GetAccInfo(HttpRequestMessage reqObject)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                string WalletAccNo = string.Empty;
                _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
                if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
                {
                    _AccInfo = JsonConvert.DeserializeObject<AccMaster>(_requestedDataObject.BusinessData, settings);
                    WalletAccNo = _AccInfo.WalletAccountNo;
                }

                if (!string.IsNullOrWhiteSpace(WalletAccNo))
                {
                    _AccInfo = new AccMaster();
                    _AccInfo = _IAccInfoService.GetAccInfoForDetails(WalletAccNo);
                    string accType = _AccInfo.AccTypeId;
                    if (accType == "004")
                    {
                        _customerAccProfile = _IAccInfoService.GetCusAccInfoForDetails(WalletAccNo);
                    }
                    if (_customerAccProfile != null)
                    {
                        _serviceResponse = _IDataManipulation.SetResponseObject(_customerAccProfile, "information has been fetched successfully");
                    }
                    else
                    {
                        _serviceResponse = _IDataManipulation.SetResponseObject(_customerAccProfile, "Data Not Found...");
                    }
                }
                //if (_AccInfo != null)
                //{
                //    _serviceResponse = _IDataManipulation.SetResponseObject(_AccInfo, "information has been fetched successfully");
                //}
                //else
                //{
                //    _serviceResponse = _IDataManipulation.SetResponseObject(_AccInfo, "Data Not Found...");
                //}
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            }
            catch (Exception ex)
            {

            }
            return _response;
        }
        #endregion

        #region GetBankAccInfoByWalletAccNo
        [HttpPost]
        public HttpResponseMessage GetBankAccInfoByWalletAccNo(HttpRequestMessage reqObject)
        {
            AccMaster _Acc_Info = new AccMaster();
            string FromSystemAccountNo = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccInfo = JsonConvert.DeserializeObject<AccMaster>(_requestedDataObject.BusinessData);
                FromSystemAccountNo = _AccInfo.FromSystemAccountNo;
            }
            if (!string.IsNullOrWhiteSpace(FromSystemAccountNo))
            {
                _Acc_Info = _IAccInfoService.GetBankAccInfoByWalletAccNo(_AccInfo);
            }
            if (_Acc_Info != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_Acc_Info, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_Acc_Info, "Account No. is not valid..");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}