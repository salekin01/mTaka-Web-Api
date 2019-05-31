using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.Charge
{
    [Serializable]
    [Table("MTK_CHG_RATE_METHOD")]
    public class ChargeRateMethod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("RATE_METHOD_ID")]
        [Display(Name = "Rate Method Id")]
        public string RateMethodId { set; get; }

        [Column("RATE_METHOD_NM")]
        [Display(Name = "Rate Method Name")]
        public string RateMethodName { set; get; }

        [Column("MAKE_BY")]
        [Display(Name = "Make By")]
        public string MakeBy { set; get; }

        [Column("MAKE_DT")]
        [Display(Name = "Make Date")]
        public DateTime? MakeDT { set; get; }
    }
}
