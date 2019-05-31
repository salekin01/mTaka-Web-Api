using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.SP
{
    public class AccTypeWiseTargetView
    {
        public string name { set; get; }
        public int market1 { set; get; }
        public int market2 { set; get; }
        public int target { set; get; }
        public decimal actual { set; get; }

    }
}
