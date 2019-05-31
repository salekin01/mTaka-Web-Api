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
    [Table("MTK_CHG_APPLY_DT")]
    public class ChargeApplyDateTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SL { set; get; }

        [Column("CHARGE_RULE_ID")]
        [Display(Name = "Charge Rule Id")]
        public string ChargeRuleId { set; get; }

        [Column("SATURDAY")]
        [Display(Name = "Saturday")]
        public string Saturday { set; get; }

        [Column("SUNDAY")]
        [Display(Name = "Sunday")]
        public string Sunday { set; get; }

        [Column("MONDAY")]
        [Display(Name = "Monday")]
        public string Monday { set; get; }

        [Column("TUESDAY")]
        [Display(Name = "Tuesday")]
        public string Tuesday { set; get; }

        [Column("WEDNESDAY")]
        [Display(Name = "Wednesday")]
        public string Wednesday { set; get; }

        [Column("THURSDAY")]
        [Display(Name = "Thursday")]
        public string Thursday { set; get; }

        [Column("FRIDAY")]
        [Display(Name = "Friday")]
        public string Friday { set; get; }

        [Column("FROMHOUR")]
        [Display(Name = "FromHour")]
        public string FromHour { set; get; }

        [Column("FROMMINUTE")]
        [Display(Name = "FromMinute")]
        public string FromMinute { set; get; }

        [Column("TOHOUR")]
        [Display(Name = "ToHour")]
        public string ToHour { set; get; }

        [Column("TOMINUTE")]
        [Display(Name = "ToMinute")]
        public string ToMinute { set; get; }

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
