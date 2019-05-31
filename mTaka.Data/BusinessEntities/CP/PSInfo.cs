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
    [Table("MTK_CP_PS_INFO")]
    public class PSInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("PS_ID")]
        [Display(Name = "Police Station Id")]
        public string PoliceStationId { set; get; }

        [Required]
        [Column("PS_NM")]
        [Display(Name = "Police Station Name")]
        public string PoliceStationNm { set; get; }

        [Required]
        [Column("PS_SH_NM")]
        [Display(Name = "Police Station Short Name")]
        public string PoliceStationShortNm { set; get; }

        [ForeignKey("UpazilaInfo")]
        [Column("UPAZILA_ID")]
        [Display(Name = "Upazila Id")]
        public string UpazilaId { set; get; }
        public virtual UpazilaInfo UpazilaInfo { get; set; }

        [NotMapped]
        [Display(Name = "Upazila Name")]
        public string UpazilaNm { set; get; }

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

