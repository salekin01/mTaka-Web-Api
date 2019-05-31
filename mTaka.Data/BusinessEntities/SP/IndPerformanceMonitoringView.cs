using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.SP
{
    public class IndPerformanceMonitoringView
    {
        public DateTime? time { set; get; }
        public decimal amount { set; get; }
        public string color { set; get; }
    }
}
