using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.Inquery
{
    public class StatementDataModel
    {
        public string ServiceName { get; set; }
        public DateTime StatementDate { get; set; }        
        public string AmountReffno { get; set; }
        public string Amount { get; set; }
        public string DebitCredit { get; set; }
        public string CurrentBalance { get; set; }
        public string Description { get; set; }
    }
}
