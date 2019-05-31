using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.CP
{
    [Serializable]
    [Table("MTK_CP_CURRENCY_INFO")]
    public class CurrencyInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CURRENCY_ID")]
        [Display(Name = "Currency Id")]
        public string CurrencyId { set; get; }

        [Required]
        [Column("CURRENCY_FULL_NM")]
        [Display(Name = "Currency Name")]
        public string CurrencyNm { set; get; }

        [Required]
        [Column("CURRENCY_SH_NM")]
        [Display(Name = "Currency Short Name")]
        public string CurrencyShortNm { set; get; }

        [Required]
        [Column("CURRENCY_REPORT_NM")]
        [Display(Name = "Currency Report Name")]
        public string CurrencyReportNm { set; get; }

        [Required]
        [Column("CURRENCY_DECIMAL_NM")]
        [Display(Name = "Currency Decimal Name")]
        public string CurrencyDecimalNm { set; get; }

        [Column("CB_CODE")]
        [Display(Name = "CB Code")]
        public string CBCode { set; get; }

        [Column("INTERNATIONAL_NM")]
        [Display(Name = "International Name")]
        public string InternationalName { set; get; }

        [Column("BASE_CURR_CONV_FLAG")]
        [Display(Name = "Base Currency Convert Flag")]
        public string BaseCurrencyConvertFlag { set; get; }

        [Column("LOCAL_VARIABLE")]
        [Display(Name = "Local Variable")]
        public string LocalVariable { set; get; }       

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

        [Column("TRANS_DATE")]
        [Display(Name = "Trans Date")]
        public DateTime? TransDT { set; get; }
    }
}


