using mTaka.API.Common;
using mTaka.Data.BusinessEntities;
using mTaka.Data.OtherEntities;
using mTaka.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mTaka.API.Areas.Others.Controllers
{
    [Authorize]
    public class MenuController : ApiController
    {
        private HttpResponseMessage _response;
        private string _requestedData = String.Empty;
        private Newtonsoft.Json.Linq.JObject _businessData;
        private APIServiceRequest _requestedDataObject;
        private APIServiceResponse _serviceResponse;

        private IDataManipulation _IDataManipulation;
        string _modelErrorMsg = string.Empty;

        public MenuController()
        {
            _IDataManipulation = new DataManipulation();
        }


        public MenuService OBJ_GetMFSMenuResult = new MenuService();
        public List<GetMFSMenuResult> LIST_GetMFSMenuResult = new List<GetMFSMenuResult>();

        #region Fetch

        [HttpGet]
        public dynamic GetAllMenuService()
        {
            string url = ConfigurationManager.AppSettings["LgurdaService_server"] + "/GetMFSMenu/09?format=json";
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                OBJ_GetMFSMenuResult = JsonConvert.DeserializeObject<MenuService>(json);

                LIST_GetMFSMenuResult = OBJ_GetMFSMenuResult.GetMFSMenuResult;
                var menuItems = CreateVM(0, LIST_GetMFSMenuResult);
                return menuItems;
            }
        }

        private List<GetMFSMenuResult> CreateVM(int PARENTID, List<GetMFSMenuResult> OBJ_MenuService)
        {
            var abc = (from men in OBJ_MenuService
                       where men.PARENTID == PARENTID
                       select new GetMFSMenuResult()
                       {
                           MENU_ID = men.MENU_ID,
                           NAME = men.NAME,
                           CONTROLLER = men.CONTROLLER,
                           title = men.NAME,
                           stateRef = men.CONTROLLER,
                           //blank = "false",
                           icon = "ion-document",
                           subMenu = CreateVM(men.MENU_ID, OBJ_MenuService)
                       }).ToList();

            foreach (var item in abc)
            {
                if (item.subMenu.Count() <= 0)
                {
                    item.subMenu = null;
                }
            }

            return abc;
        }

        #endregion Fetch
    }
}