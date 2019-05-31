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
    [Table("MTK_APPL_PREFIX")]
    public class ApplPrefix
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("APPL_TYPE")]
        [Display(Name = "APPL Type")]
        public string ApplType { set; get; }

        [Column("APPL_SL_NO")]
        [Display(Name = "APPL SL No")]
        public string APPLSLNo { set; get; }

        [Column("APPL_NAME")]
        [Display(Name = "APPL Name")]
        public string APPLName { set; get; }

        [Column("APPL_START_PREFIX")]
        [Display(Name = "APPL Start Prefix")]
        public string APPLStartProfix { set; get; }

        [Column("APPL_END_PREFIX")]
        [Display(Name = "APPL End Prefix")]
        public string APPLEndProfix { set; get; }
        
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
        public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
