using mTaka.API.Common;
using mTaka.Data.BusinessEntities.Upload_File;
using mTaka.Service.BusinessServices.Upload_File;
using mTaka.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace mTaka.API.Areas.Upload_File
{
    public class FileUploadController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;


        private IFileUploadService _IFile_UploadService;
        private IDataManipulation _IDataManipulation;
        File_Upload _FileUpload = null;
        string ResopnsErrMsg = string.Empty;
        public FileUploadController()
        {
            _IFile_UploadService = new FileUploadService();
            _IDataManipulation = new DataManipulation();
        }

        #region Add

        [HttpPost]
        public HttpResponseMessage UploadFile(HttpRequestMessage reqObject)
        {
            int result = 0;
            _requestedDataObject = _IDataManipulation.GetRequestedDataObject(reqObject);
            if (_requestedDataObject != null && _requestedDataObject.BusinessData != null)
            {
                _FileUpload = JsonConvert.DeserializeObject<File_Upload>(_requestedDataObject.BusinessData);
                result = _IFile_UploadService.UploadFile(_FileUpload);
            }

            if (result == 1)
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "information has been added successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.SetResponseObject(result, "Account Type Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }

        #endregion
    }
}