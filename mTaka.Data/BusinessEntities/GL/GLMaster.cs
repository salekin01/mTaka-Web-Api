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
    [Table("MTK_GL_MASTER")]
    public class GLMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("SL")]
        [Display(Name = "Serial Id")]
        public string Sl { set; get; }

        [Required]
        [Column("GL_ACC_SL", Order = 1)]
        [Display(Name = "GL Account SL")]
        public string GLAccSl { set; get; }

        [Column("GL_ACC_NO")]
        [Display(Name = "GL Account No")]
        public string GLAccNo { set; get; }

        [Column("GL_ACC_NM")]
        [Display(Name = "GL Account Name")]
        public string GLAccName { set; get; }

        [Required]
        [Column("GL_BRANCH_ID", Order = 0)]
        [Display(Name = "Branch Id")]
        public string BranchId { set; get; }

        [Column("GL_PREFIX")]
        [Display(Name = "GL Prefix")]
        public string GLPrefix { set; get; }

        [Column("TOTALLING_ACC_SL")]
        [Display(Name = "Totalling Account Sl")]
        public string TotalingAccSl { set; get; }

        [Column("GL_TYPE")]
        [Display(Name = "GL Type")]
        public string GLType { set; get; }

        [Column("GL_ACC_TYPE")]
        [Display(Name = "GL Account Type")]
        public string GLAccType { set; get; }

        [Column("GL_LEVEL")]
        [Display(Name = "GL Level")]
        public int? GLLevel { set; get; }

        [Column("GL_CURRENCY_ID")]
        [Display(Name = "Currency")]
        public string GLCurrencyId { set; get; }

        [Column("POSTABLE")]
        [Display(Name = "Postable")]
        public int? Postable { set; get; }

        [Column("OFF_BS_FLAG")]
        [Display(Name = "Balance Sheet Item")]
        public int? OffBSFlag { set; get; }

        [Column("STATEMENT_CYCLE")]
        [Display(Name = "Statement Cycle")]
        public string StatementCycle { set; get; }

        [Column("OPENING_DT")]
        [Display(Name = "Opening Date")]
        public DateTime? OpeningDate { set; get; }

        [Column("LAST_TRANS_DT")]
        [Display(Name = "Last Transaction Date")]
        public DateTime? LastTransactionDate { set; get; }

        [Column("OPENING_BALANCE_LCY")]
        [Display(Name = "Opining Balance LCY")]
        public decimal? OpiningBalanceLCY { set; get; }

        [Column("OPENING_BALANCE_CCY")]
        [Display(Name = "Opining Balance CCY")]
        public decimal? OpiningBalanceCCY { set; get; }

        [Column("CLOSING_BALANCE_LCY")]
        [Display(Name = "Closing Balance LCY")]
        public decimal? ClosingBalanceLCY { set; get; }

        [Column("CLOSING_BALANCE_CCY")]
        [Display(Name = "Closing Balance CCY")]
        public decimal? ClosingBalanceCCY { set; get; }

        [Column("CURRENT_BALANCE_LCY")]
        [Display(Name = "Current Balance LCY")]
        public decimal? CurrentBalanceLCY { set; get; }

        [Column("CURRENT_BALANCE_CCY")]
        [Display(Name = "Current Balance CCY")]
        public decimal? CurrentBalanceCCY { set; get; }

        [Column("BALANCE_LCY")]
        [Display(Name = "Balance LCY")]
        public decimal? BalanceLCY { set; get; }

        [Column("BALANCE_CCY")]
        [Display(Name = "Balance CCY")]
        public decimal? BalanceCCY { set; get; }
                
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
        [Display(Name = "Amount")]
        public decimal Amount { set; get; }

        [NotMapped]
        [Display(Name = "Define Service Id")]
        public string DefineServiceId { set; get; }

        [NotMapped]
        [Display(Name = "Narration")]
        public string Narration { set; get; }
    }
}
