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
    [Table("MTK_SP_DEFINE_SERVICE")]
    public class DefineService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("DEFINE_SERVICE_ID")]
        [Display(Name = "Define Service Id")]
        public string DefineServiceId { set; get; }

        [Required]
        [Column("DEFINE_SERVICE_NM")]
        [Display(Name = "Define Service Name")]
        public string DefineServiceNm { set; get; }

        [Required]
        [Column("FUNCTION_ID")]
        [Display(Name = "Function Id")]
        public string FunctionIdForDefineService { set; get; }

        [NotMapped]
        [Display(Name = "Function Id")]
        public string FunctionId { set; get; }

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

        //[NotMapped]
        //public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
