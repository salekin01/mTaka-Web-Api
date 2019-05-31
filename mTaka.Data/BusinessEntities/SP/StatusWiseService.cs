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
    [Table("MTK_SP_STATUS_WISE_SERVICE")]
    public class StatusWiseService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("STATUS_WISE_SERVICE_ID")]
        [Display(Name = "Status Wise Service Id")]
        public string StatusWiseServiceId { set; get; }

        [Required]
        [Column("DEFINE_SERVICE_ID")]
        [Display(Name = "Define Service Id")]
        public string DefineServiceId { set; get; }

        [Required]
        [Column("TRANS_ALLOW")]
        [Display(Name = "Transaction Allow")]
        public string TransactionAllow { set; get; }

        [NotMapped]
        [Display(Name = "Define Service Name")]
        public string DefineServiceNm { set; get; }

        [Required]
        [Column("ACC_STATUS_ID")]
        [Display(Name = "Account Status Id")]
        public string AccountStatusId { set; get; }

        [NotMapped]
        [Display(Name = "Account Status Name")]
        public string AccountStatusName { set; get; }

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

        [NotMapped]
        [Display(Name = "To Account No.")]
        public string ToSystemAccountNo { set; get; }

        [NotMapped]
        public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
