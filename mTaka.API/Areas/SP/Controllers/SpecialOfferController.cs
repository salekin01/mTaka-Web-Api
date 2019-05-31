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
    public class SpecialOfferController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private ISpecialOfferService _ISpecialOfferService;
        private IDataManipulation _IDataManipulation;
        SpecialOffers _SpecialOffer = null;
        string _modelErrorMsg = string.Empty;
        public SpecialOfferController()
        {
            _ISpecialOfferService = new SpecialOfferService();
            _IDataManipulation = new DataManipulation();
        }

        #region Index
        [HttpPost]
        public HttpResponseMessage GetAllSpecialOffer(HttpRequestMessage reqObject)
        {
            var result = _ISpecialOfferService.GetAllSpecialOffers();
            if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account Types Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }


        [HttpPost]
        public HttpResponseMessage GetSpecialOffersBy(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _SpecialOffer = new SpecialOffers();
                _SpecialOffer = JsonConvert.DeserializeObject<SpecialOffers>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_SpecialOffer, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ISpecialOfferService.GetSpecialOffersBy(_SpecialOffer);
                }
            }
            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, _modelErrorMsg);
            }
            else if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Service and Customer Type Already exist");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region Add
        [HttpPost]
        public HttpResponseMessage AddSpecialOffer(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _SpecialOffer = new SpecialOffers();
                _SpecialOffer = JsonConvert.DeserializeObject<SpecialOffers>(_requestedDataObject.BusinessData);

                bool IsValid = ModelValidation.TryValidateModel(_SpecialOffer, out _modelErrorMsg);
                if (IsValid)
                {
                    result = _ISpecialOfferService.AddSpecialOffers(_SpecialOffer);
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
        public HttpResponseMessage UpdateSpecialOffer(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _SpecialOffer = JsonConvert.DeserializeObject<SpecialOffers>(_requestedDataObject.BusinessData);
            }

            if (_SpecialOffer == null || string.IsNullOrWhiteSpace(_SpecialOffer.OfferId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Offers Type Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _ISpecialOfferService.UpdateSpecialOffers(_SpecialOffer);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been updated successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Offer Types Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region Delete

        [HttpPost]
        public HttpResponseMessage DeleteSpecialOffers(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _SpecialOffer = JsonConvert.DeserializeObject<SpecialOffers>(_requestedDataObject.BusinessData);
            }

            if (_SpecialOffer == null || string.IsNullOrWhiteSpace(_SpecialOffer.OfferId))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Offer Not Found...");
                _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
                return _response;
            }

            result = _ISpecialOfferService.DeleteSpecialOffers(_SpecialOffer);
            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been deleted successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Offer Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion

        #region CheckOffer
        [HttpPost]
        public HttpResponseMessage CheckOffer(HttpRequestMessage reqObject)
        {
            dynamic result=0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _SpecialOffer = new SpecialOffers();
                _SpecialOffer = JsonConvert.DeserializeObject<SpecialOffers>(_requestedDataObject.BusinessData);


                result = _ISpecialOfferService.CheckOffers(_SpecialOffer);
            }
            if (!string.IsNullOrWhiteSpace(_modelErrorMsg))
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, _modelErrorMsg);
            }
            else if (result != null)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Successfull");
            }
            else if(result == null)
            {
                result = 0;
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Fail");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}