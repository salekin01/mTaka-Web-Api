using mTaka.API.Common;
using mTaka.Data.BusinessEntities;
using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.LEDGER;
using mTaka.Service.BusinessServices;
using mTaka.Service.BusinessServices.ACC;
using mTaka.Service.BusinessServices.LEDGER;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.LEDGER.Controllers
{
    //[Authorize]
    public class LedgerController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IChannelLedgerService _IChannelLedgerService;
        private IDataManipulation _IDataManipulation;
        LedgerTxn _LedgerTxn = null;
        LedgerMaster _LedgerMaster = null;
        AccMaster _AccMaster = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public LedgerController()
        {
            _IChannelLedgerService = new LedgerService();
            _IDataManipulation = new DataManipulation();
        }

        #region GetAllLedgerTxnByAccNoandDate
        [HttpPost]
        public HttpResponseMessage GetAllLedgerTxnByAccNoandDate(HttpRequestMessage reqObject)
        {
            List<LedgerTxnHist> _LedgerTxnHist = new List<LedgerTxnHist>();
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _LedgerTxn = JsonConvert.DeserializeObject<LedgerTxn>(_requestedDataObject.BusinessData);
                _LedgerTxnHist = _IChannelLedgerService.GetAllLedgerTxnByAccNoandDate(_LedgerTxn);
            }
            if (_LedgerTxnHist != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_LedgerTxnHist, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_LedgerTxnHist, "Channel Account Profile Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        #region GetAllLedgerTxnforTopPerformerMonitoring
        [HttpPost]
        public HttpResponseMessage GetAllLedgerTxnforTopPerformerMonitoring(HttpRequestMessage reqObject)
        {
            List<LedgerTxnHist> _LedgerTxnHist = new List<LedgerTxnHist>();
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _LedgerTxn = JsonConvert.DeserializeObject<LedgerTxn>(_requestedDataObject.BusinessData);
                _LedgerTxnHist = _IChannelLedgerService.GetAllLedgerTxnforTopPerformerMonitoring(_LedgerTxn);
            }
            if (_LedgerTxnHist != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_LedgerTxnHist, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_LedgerTxnHist, "Channel Account Profile Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion

        //#region Update for UpdateClosingBalance
        //[HttpPost]
        //public decimal UpdateClosingBalance(LedgerMaster Obj_LedgerMaster)
        //{
        //    decimal result = 0;
        //    result = _IChannelLedgerService.UpdateClosingBalance(_LedgerMaster);
        //    return result;
        //}
        //#endregion

        #region GetAccMasterInfoByAccNo
        [HttpPost]
        public HttpResponseMessage GetAccMasterInfoByAccNo(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _AccMaster = JsonConvert.DeserializeObject<AccMaster>(_requestedDataObject.BusinessData);
            }
            if (!string.IsNullOrWhiteSpace(_AccMaster.FromSystemAccountNo) || !string.IsNullOrWhiteSpace(_AccMaster.WalletAccountNo))
            {
                _AccMaster = _IChannelLedgerService.GetAccMasterInfoByAccNo(_AccMaster);
            }
            if (_AccMaster != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccMaster, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_AccMaster, "Account No. is not valid..");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
	}
}