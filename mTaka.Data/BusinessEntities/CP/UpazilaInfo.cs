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
    [Table("MTK_CP_UPAZILA_INFO")]
    public class UpazilaInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("UPAZILA_ID")]
        [Display(Name = "Upazila Id")]
        public string UpazilaId { set; get; }

        [Required]
        [Column("UPAZILA_NM")]
        [Display(Name = "Upazila Name")]
        public string UpazilaNm { set; get; }

        [Required]
        [Column("UPAZILA_SH_NM")]
        [Display(Name = "Upazila Short Name")]
        public string UpazilaShortNm { set; get; }

        [ForeignKey("DistrictInfo")]
        [Column("DISTRICT_ID")]
        [Display(Name = "District Id")]
        public string DistrictId { set; get; }
        public virtual DistrictInfo DistrictInfo { get; set; }

        [NotMapped]
        [Display(Name = "District Name")]
        public string DistrictNm { set; get; }

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


