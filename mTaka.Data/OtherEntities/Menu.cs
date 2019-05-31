using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.OtherEntities
{
    public class Menu
    {
        public int SL_ID { get; set; }
        public string APP_ID { get; set; }
        public Nullable<int> MENU_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string CONTROLLER { get; set; }
        public string ACTION { get; set; }
        public string URL { get; set; }
        public Nullable<int> PARENTID { get; set; }
        public string FUNCTION_ID { get; set; }

        //public IEnumerable<LG_MENU_MAP> Children { get; set; }
        public IEnumerable<Menu> subMenu { get; set; }

        public string title { get; set; }
        public string stateRef { get; set; }
        public string blank { get; set; }
        public string icon { get; set; }
    }
}
