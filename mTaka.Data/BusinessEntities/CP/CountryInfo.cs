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
    [Table("MTK_CP_COUNTRY_INFO")]
    public class CountryInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("COUNTRY_ID")]
        [Display(Name = "Country Id")]
        public string CountryId { set; get; }

        [Required]
        [Column("COUNTRY_NM")]
        [Display(Name = "Country Name")]
        public string CountryNm { set; get; }

        [Required]
        [Column("COUNTRY_SH_NM")]
        [Display(Name = "Country Short Name")]
        public string CountryShortNm { set; get; }

        [Column("ISO_CODE")]
        [Display(Name = "ISO Code")]
        public string ISOCode { set; get; }

        [Column("CB_CODE")]
        [Display(Name = "CB Code")]
        public string CBCode { set; get; }

        [Column("NATIONALITY_NM")]
        [Display(Name = "Nationality Name")]
        public string NationalityName { set; get; }

        [ForeignKey("CurrencyInfo")]
        [Column("CURRENCY_ID")]
        [Display(Name = "Currency Id")]
        public string CurrencyId { set; get; }
        public virtual CurrencyInfo CurrencyInfo { get; set; }

        [NotMapped]
        [Display(Name = "Currency Name")]
        public string CurrencyNm { set; get; }

        [Column("NATIVE_COUNTRY_FLAG")]
        [Display(Name = "Native Country Flag")]
        public string NativeCountryFlag { set; get; }

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

