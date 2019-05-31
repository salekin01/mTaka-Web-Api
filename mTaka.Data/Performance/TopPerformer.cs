using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.Performance
{
    public class TopPerformer
    {
        [Key]
        public string PerformerId { get; set; }
        public string AccName { get; set; }
        public string AccNo { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
}
