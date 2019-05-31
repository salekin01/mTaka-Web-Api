using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.LEDGER
{
    [Serializable]
    [Table("MTK_LEDGER_MASTER")]
    public class LedgerMaster
    {
        [Key]
        [Column("ACC_PROFILE_ID")]
        [Display(Name = "Account Profile Id")]
        public string AccProfileId { set; get; }

        [Required]
        [Column("SYS_ACC_NO")]
        [Display(Name = "System Account No.")]
        public string SystemAccountNo { set; get; } 

        [Required]
        [Column("ACC_TYPE_ID")]
        [Display(Name = "Account Type Id")]
        public string AccountTypeId { set; get; }

        [Required]
        [Column("OPENING_BALANCE")]
        [Display(Name = "Opening Balance")]
        public decimal OpeningBalance { set; get; }

        [Required]
        [Column("CLOSING_BALANCE")]
        [Display(Name = "Closing Balance")]
        public decimal ClosingBalance { set; get; }

        [Column("APPLIED_PROFIT")]
        [Display(Name = "Applied Profit")]
        public Nullable<decimal> AppliedProfit { set; get; }

        [Column("LAST_APPLIED_DATE")]
        [Display(Name = "Last Applied Date")]
        public DateTime? LastAppliedDate { set; get; }

        [Column("PRODUCT_ID")]
        [Display(Name = "Product Id")]
        public string ProductId { set; get; }

        [Column("BRANCH_ID")]
        [Display(Name = "Branch Id")]
        public string BranchId { set; get; }

        [NotMapped]
        [Display(Name = "Payment Amount")]
        public Nullable<decimal> PaymentAmount { set; get; }

        [NotMapped]
        [Display(Name = "Receive Amount")]
        public Nullable<decimal> ReceiveAmount { set; get; }

        [NotMapped]
        [Display(Name = "From Account No")]
        public string FromSystemAccountNo { set; get; }

        [NotMapped]
        [Display(Name = "To Account No.")]
        public string ToSystemAccountNo { set; get; }

        [NotMapped]
        [Display(Name = "Define Service Id")]
        public string DefineServiceId { set; get; }

        [NotMapped]
        [Display(Name = "Amount")]
        public decimal Amount { set; get; }

        [NotMapped]
        [Display(Name = "Balance Limit")]
        public decimal BalanceLimit { set; get; }
    }
}
