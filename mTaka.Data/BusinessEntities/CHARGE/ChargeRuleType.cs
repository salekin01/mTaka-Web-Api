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
    [Table("MTK_CHG_RULE_TYPE")]
    public class ChargeRuleType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("RULE_TYPE_ID")]
        [Display(Name = "Rule Type Id")]
        public string RuleTypeId { set; get; }

        [Column("RULE_TYPE_NM")]
        [Display(Name = "Rule Type Name")]
        public string RuleTypeName { set; get; }

        [Column("MAKE_BY")]
        [Display(Name = "Make By")]
        public string MakeBy { set; get; }

        [Column("MAKE_DT")]
        [Display(Name = "Make Date")]
        public DateTime? MakeDT { set; get; }
    }
}
