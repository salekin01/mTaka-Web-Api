using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities
{
    public class GetMFSMenuResult
    {
        public string ACTION { get; set; }
        public object APP_ID { get; set; }
        public string CONTROLLER { get; set; }
        public object Children { get; set; }
        public object DESCRIPTION { get; set; }
        public object FUNCTION_ID { get; set; }
        public int MENU_ID { get; set; }
        public string NAME { get; set; }
        public int PARENTID { get; set; }
        public int SL_ID { get; set; }
        public object URL { get; set; }
        public string title { get; set; }
        public string stateRef { get; set; }
        public string blank { get; set; }
        public string icon { get; set; }

        public IList<GetMFSMenuResult> subMenu { get; set; }

    }

    public class MenuService
    {
        public List<GetMFSMenuResult> GetMFSMenuResult { get; set; }
    }
    public class GetReportFunctionIdsResult
    {
        public string FUNCTION_ID { get; set; }
        public string FUNCTION_NM { get; set; }

    }
    public class ReportMenuService
    {
        public List<GetReportFunctionIdsResult> GetReportFunctionIdsResult { get; set; }
    }

}
