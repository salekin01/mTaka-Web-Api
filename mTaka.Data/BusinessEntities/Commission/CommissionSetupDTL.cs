using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mTaka.Data.BusinessEntities.Commission
{
    [Serializable]
    [Table("MTK_COMMISSION_SETUP_DTL")]
    public class CommissionSetupDTL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("DTL_ID")]
        [Display(Name = "Detail Id")]
        public string CommissionDtlId { set; get; }

        //[ForeignKey("MTK_COMMISSION_SETUP")]
        [Required]
        [Column("COMMISSION_ID")]
        [Display(Name = "Commission Id")]
        public string CommissionId { set; get; }

        [Required]
        [Column("ACC_TYPE_ID")]
        [Display(Name = "Account Type Id")]
        public string AccTypeId { set; get; }

        [Column("COMMISSION_RATE")]
        [Display(Name = "Commission Rate")]
        public decimal CommissionRate { set; get; }

        [Column("AIT")]
        [Display(Name = "AIT")]
        public decimal AIT { set; get; }

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
    }
}
