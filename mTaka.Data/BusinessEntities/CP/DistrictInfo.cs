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
    [Table("MTK_CP_DISTRICT_INFO")]
    public class DistrictInfo
    {
        public DistrictInfo()
        {
            DistrictShortNm = "anythingh";
            DistrictNm = "aasdf";
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("DISTRICT_ID")]
        [Display(Name = "District Id")]
        public string DistrictId { set; get; }

        [Required]
        [Column("DISTRICT_NM")]
        [Display(Name = "District Name")]
        public string DistrictNm { set; get; }

        [Required]
        [Column("DISTRICT_SH_NM")]
        [Display(Name = "District Short Name")]
        public string DistrictShortNm { set; get; }

        [ForeignKey("DivisionInfo")]
        [Column("DIVISION_ID")]
        [Display(Name = "Division Id")]
        public string DivisionId { set; get; }
        public virtual DivisionInfo DivisionInfo { get; set; }

        [NotMapped]
        [Display(Name = "Division Name")]
        public string DivisionNm { set; get; }

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

