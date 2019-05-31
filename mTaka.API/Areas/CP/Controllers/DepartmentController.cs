using mTaka.API.Common;
using mTaka.Data.BusinessEntities.CP;
using mTaka.Data.Infrastructure;
using mTaka.Service.BusinessServices.CP;
using mTaka.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.WebPages.Html;


namespace mTaka.API.Areas.CP.Controllers
{
    [Authorize]
    public class DepartmentController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IDepartmentService _IDepartmentService;
        private IDataManipulation _IDataManipulation;
        Department _Department = null;
        string ResopnsErrMsg = string.Empty;

        public DepartmentController()
        {
            _IDepartmentService = new DepartmentService();
            _IDataManipulation = new DataManipulation();
        }


        #region DropDown
        [HttpPost]
        public HttpResponseMessage GetDepartmentInfoForDD(HttpRequestMessage reqObject)
        {
            var List_Department_Info = _IDepartmentService.GetDepartmentInfoForDD();
            if (List_Department_Info != null)
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataFound(List_Department_Info, "information has been fetched successfully");
            }
            else
            {
                _serviceResponse = _IDataManipulation.ResopnseWhenDataNotFound("Department Info Not Found...");
            }
            _response = _IDataManipulation.CreateResponse(_serviceResponse, reqObject);
            return _response;
        }
        #endregion
    }
}