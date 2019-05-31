using mTaka.Data.BusinessEntities.CP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.SP
{
    [Serializable]
    [Table("MTK_SP_PROMO_CODE_CONFIG")]
    public class PromoCodeConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CONFIGURATION_ID")]
        [Display(Name = "Configuration Id")]
        public string ConfigurationId { set; get; }

        [Column("INTRODUCER_CONTROL_FLAG")]
        [Display(Name = "Introducer Control Flag")]
        public string IntroducerControlFlag { set; get; }

        [Column("EMAIL_FLAG")]
        [Display(Name = "Email Flag")]
        public string EmailFlag { get; set; }

        [Column("SMS_FLAG")]
        [Display(Name = "SMS Flag")]
        public string SMSFlag { get; set; }

        [Column("PROMO_CODE_LENGTH")]
        [Display(Name = "Promo Code Length")]
        public string PromoCodeLength { get; set; }

        [Column("PROMO_CODE_FORMAT_ID")]
        [Display(Name = "Promo Code Format Id")]
        public string TokenFormatId { get; set; }
        public virtual TokenFormat TokenFormat { get; set; }

        [NotMapped]
        [Display(Name = "Promo Code Format Name")]
        public string TokenFormatName { get; set; }

        [Column("TOTAL_NO_OF_USE_FOR_INTRODUCER")]
        [Display(Name = "No. of Use for Introducer")]
        public string TotalNoOfUseForIntroducer { get; set; }

        [Column("TOTAL_NO_OF_USE")]
        [Display(Name = "No. of Use")]
        public string TotalNoOfUse { get; set; }

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

        [NotMapped]
        [Display(Name = "Function Id")]
        public string FunctionId { set; get; }

        //[NotMapped]
        //public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
