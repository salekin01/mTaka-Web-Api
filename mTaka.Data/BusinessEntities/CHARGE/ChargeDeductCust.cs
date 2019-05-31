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
    [Table("MTK_CHG_DEDUCT_CUST")]
    public class ChargeDeductCust
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SL { set; get; }

        [Column("CHARGE_RULE_ID")]
        [Display(Name = "Charge Rule Id")]
        public string ChargeRuleId { set; get; }

        [Column("CUSTOMER_CATEGORY_ID")]
        [Display(Name = "Customer Category Id")]
        public string CusCatId { set; get; }

        [Column("AUTH_STATUS_ID")]
        [Display(Name = "Auth. Status Id")]
        public string AuthStatusId { set; get; }

        [Column("LAST_ACTION")]
        [Display(Name = "Last Action")]
        public string LastAction { set; get; }

        [Column("LAST_UPDATE_DT")]
        [Display(Name = "Last Update Date")]
        public DateTime? LastUpdateDT { set; get; }

        [Column("MAKE_BY")]
        [Display(Name = "Make By")]
        public string MakeBy { set; get; }

        [Column("MAKE_DT")]
        [Display(Name = "Make Date")]
        public DateTime? MakeDT { set; get; }
    }
}
