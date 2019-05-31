using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.GL
{
    [Serializable]
    [Table("MTK_TRANS_GL")]
    public class TransGL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("TRACER_NO")]
        [Display(Name = "Tracer No")]
        public string TracerNo { set; get; }

        [Required]
        [Column("BATCH_NO")]
        [Display(Name = "Batch No")]
        public string BatchNo { set; get; }

        [Required]
        [Column("BRANCH_ID")]
        [Display(Name = "Branch Id")]
        public string BranchId { set; get; }

        [Required]
        [Column("DR_CR")]
        [Display(Name = "Debit Or Credit")]
        public string DebitOrCredit { set; get; }

        [Required]
        [Column("GL_ACC_SL")]
        [Display(Name = "GL Account SL")]
        public string GLAccSl { set; get; }

        [Required]
        [Column("ACCOUNT_NO")]
        [Display(Name = "GL Account No")]
        public string GLAccNo { set; get; }

        [Required]
        [Column("AMOUNT_CCY")]
        [Display(Name = "Amount CCY")]
        public decimal AmountCCY { set; get; }

        [Required]
        [Column("AMOUNT_LCY")]
        [Display(Name = "Amount LCY")]
        public decimal AmountLCY { set; get; }

        [Required]
        [Column("BALANCE_CCY")]
        [Display(Name = "Balance CCY")]
        public decimal BalanceCCY { set; get; }

        [Required]
        [Column("BALANCE_LCY")]
        [Display(Name = "Balance LCY")]
        public decimal BalanceLCY { set; get; }

        [Column("NARRATION")]
        [Display(Name = "Narration")]
        public string Narration { set; get; }

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
