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
    [Table("MTK_CHG_RATE_TYPE")]
    public class ChargeRateType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("RATE_TYPE_ID")]
        [Display(Name = "Rate Type Id")]
        public string RateTypeId { set; get; }

        [Column("RATE_TYPE_NM")]
        [Display(Name = "Rate Type Name")]
        public string RateTypeName { set; get; }

        [Column("MAKE_BY")]
        [Display(Name = "Make By")]
        public string MakeBy { set; get; }

        [Column("MAKE_DT")]
        [Display(Name = "Make Date")]
        public DateTime? MakeDT { set; get; }
    }
}
