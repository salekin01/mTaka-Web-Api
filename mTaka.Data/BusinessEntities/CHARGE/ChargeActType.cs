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
    [Table("MTK_CHG_ACTUAL_TYPE")]
    public class ChargeActType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CHARGE_ACTUAL_TYPE_ID")]
        [Display(Name = "Charge Actual Type Id")]
        public string CrgActTypeId { set; get; }

        [Column("CHARGE_ACTUAL_TYPE_NM")]
        [Display(Name = "Charge Actual Type Name")]
        public string CrgActTypeName { set; get; }

        [Column("MAKE_BY")]
        [Display(Name = "Make By")]
        public string MakeBy { set; get; }

        [Column("MAKE_DT")]
        [Display(Name = "Make Date")]
        public DateTime? MakeDT { set; get; }
    }
}
