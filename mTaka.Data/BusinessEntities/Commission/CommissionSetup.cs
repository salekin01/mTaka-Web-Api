using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mTaka.Data.BusinessEntities.Commission
{
    [Serializable]
    [Table("MTK_COMMISSION_SETUP")]
    public class CommissionSetup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("COMMISSION_ID")]
        [Display(Name = "Commission Id")]
        public string CommissionId { set; get; }

        //[ForeignKey("MTK_SP_DEFINE_SERVICE")]
        [Required]
        [Column("SERVICE_ID")]
        [Display(Name = "Service Id")]
        public string DefineServiceId { set; get; }

        //[Required]
        //[Column("CHARGE")]
        //[Display(Name = "Charge")]
        //public decimal Charge { set; get; }
        
        [Column("VAT")]
        [Display(Name = "Vat")]
        public decimal Vat { set; get; }
        
        [Column("GLACCOUNT")]
        [Display(Name = "GL Account")]
        public string GLAccount { set; get; }

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
        public CommissionSetupDTL[] ListCommissionSetupDTL { set; get; }

        public virtual ICollection<CommissionSetupDTL> CommissionSetupDTL { get; set; }
    }
}
