using mTaka.API.Common;
using mTaka.Data.BusinessEntities.SP;
using mTaka.Service.BusinessServices.SP;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.SP.Controllers
{
    [Authorize]
    public class PromoCodeConfigController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IPromoCodeConfigService _IPromoCodeConfigService;
        private IDataManipulation _IDataManipulation;
        PromoCodeConfig _PromoCodeConfig = null;
        string _modelErrorMsg = string.Empty;
        string ResopnsErrMsg = string.Empty;
        public PromoCodeConfigController()
        {
            _IPromoCodeConfigService = new PromoCodeConfigService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index

        [HttpPost]
        public HttpResponseMessage GetAllPromoCodeConfig(HttpRequestMessage reqObject)
        {
            var result = _IPromoCodeConfigService.GetAllPromoCodeConfig();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Promo Code Configurations Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetPromoCodeConfigById(HttpRequestMessage reqObject)
        {
            string ConfigurationId = string.Empty;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _PromoCodeConfig = JsonConvert.DeserializeObject<PromoCodeConfig>(_requestedDataObject.BusinessData);
                ConfigurationId = _PromoCodeConfig.ConfigurationId;
            }

            if (!string.IsNullOrWhiteSpace(ConfigurationId))
            {
                _PromoCodeConfig = new PromoCodeConfig();
                _PromoCodeConfig = _IPromoCodeConfigService.GetPromoCodeConfigById(ConfigurationId);
            }
            if (_PromoCodeConfig != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_PromoCodeConfig, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_PromoCodeConfig, "Promo Code Configuration Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        [HttpPost]
        public HttpResponseMessage GetPromoCodeConfigBy(HttpRequestMessage reqObject)
        {
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _PromoCodeConfig = JsonConvert.DeserializeObject<PromoCodeConfig>(_requestedDataObject.BusinessData);
                _PromoCodeConfig = _IPromoCodeConfigService.GetPromoCodeConfigBy(_PromoCodeConfig);
            }
            if (_PromoCodeConfig != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_PromoCodeConfig, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(_PromoCodeConfig, "Promo Code Configuration Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddPromoCodeConfig(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _PromoCodeConfig = new PromoCodeConfig();
                _PromoCodeConfig = JsonConvert.DeserializeObject<PromoCodeConfig>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_PromoCodeConfig, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IPromoCodeConfigService.AddOrUpdatePromoCodeConfig(_PromoCodeConfig);
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
        public HttpResponseMessage UpdatePromoCodeConfig(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _PromoCodeConfig = JsonConvert.DeserializeObject<PromoCodeConfig>(_requestedDataObject.BusinessData);
                bool IsValid = ModelValidation.TryValidateModel(_PromoCodeConfig, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _IPromoCodeConfigService.AddOrUpdatePromoCodeConfig(_PromoCodeConfig);
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
        public HttpResponseMessage DeletePromoCodeConfig(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _PromoCodeConfig = JsonConvert.DeserializeObject<PromoCodeConfig>(_requestedDataObject.BusinessData);
            }

            if (_PromoCodeConfig == null || string.IsNullOrWhiteSpace(_PromoCodeConfig.ConfigurationId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "StatusWise Service Map Id Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _IPromoCodeConfigService.DeletePromoCodeConfig(_PromoCodeConfig);
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
    }
}