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
    [Table("MTK_CP_DIVISION_INFO")]
    public class DivisionInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("DIVISION_ID")]
        [Display(Name = "Division Id")]
        public string DivisionId { set; get; }

        [Required]
        [Column("DIVISION_NM")]
        [Display(Name = "Division Name")]
        public string DivisionNm { set; get; }

        [Required]
        [Column("DIVISION_SH_NM")]
        [Display(Name = "Division Short Name")]
        public string DivisionShortNm { set; get; }

        [ForeignKey("CountryInfo")]
        [Column("COUNTRY_ID")]
        [Display(Name = "Country Id")]
        public string CountryId { set; get; }
        public virtual CountryInfo CountryInfo { get; set; }

        [NotMapped]
        [Display(Name = "Country Name")]
        public string CountryNm { set; get; }

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

