using mTaka.Data.BusinessEntities.SP;
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
    [Table("MTK_LEDGER_TXN")]
    public class LedgerTxn
    {
        [Key, Column("SL", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Column("SL")]
        [Display(Name = "Serial Id")]
        public string Sl { set; get; }

        [Key, Column("BATCH_NO", Order = 1)]
        [Required]
        //[Column("BATCH_NO")]
        [Display(Name = "Batch No")]
        public string BatchNo { set; get; }

        [Key, Column("TXN_DT", Order = 0)]
        [Required]
        //[Column("TXN_DT")]
        [Display(Name = "Transection Date")]
        public DateTime TransectionDate { set; get; }

        [Required]
        [Column("TXN_ID")]
        [Display(Name = "Txn Id")]
        public string TxnID { set; get; }

        //[Column("TXN_CODE")]
        //[Display(Name = "Transection Code")]
        //public string TransectionCode { set; get; }

        //[Required]
        //[Column("ACC_PROFILE_ID")]
        //[Display(Name = "Account Profile Id")]
        //public string AccProfileId { set; get; }

        //[Required]
        //[Column("FROM_SYS_ACC_NO")]
        //[Display(Name = "From System Account No.")]
        //public string FromSystemAccountNo { set; get; }

        //[Required]
        //[Column("TO_SYS_ACC_NO")]
        //[Display(Name = "To System Account No.")]
        //public string ToSystemAccountNo { set; get; }

        [Required]
        [Column("DEFINE_SERVICE_ID")]
        [Display(Name = "Define Service Id")]
        public string DefineServiceId { set; get; }

        [Required]
        [Column("ACC_TYPE_ID")]
        [Display(Name = "Account Type Id")]
        public string AccountTypeId { set; get; }

        [Required]
        [Column("SYS_ACC_NO")]
        [Display(Name = "System Account No.")]
        public string SystemAccountNo { set; get; }

        [Column("ACC_BALANCE")]
        [Display(Name = "Acc Balance")]
        public decimal AccBalance { set; get; }

        [Column("DR_CR")]
        [Display(Name = "Debit or Credit")]
        public string DebitOrCredit { set; get; }

        [Column("AMOUNT")]
        [Display(Name = "Amount")]
        public Nullable<decimal> Amount { set; get; }

        [Required]
        [Column("PROCESS_STATUS")]
        [Display(Name = "Process Status")]
        public string ProcessStatus { set; get; }

        [Required]
        [Column("NARRATION")]
        [Display(Name = "Narration")]
        public string Narration { set; get; }

        //[Required]
        //[Column("TXN_PARENT_ID")]
        //[Display(Name = "Transection Parent Id")]
        //public string TransectionParentId { set; get; }

        [Required]
        [Column("FUNCTION_ID")]
        [Display(Name = "Function Id")]
        public string FunctionId { set; get; }

        //[Column("BRANCH_ID")]
        //[Display(Name = "Branch Id")]
        //public string BranchId { set; get; }

        //[Column("AUTH_STATUS_ID")]
        //[Display(Name = "Auth. Status Id")]
        //public string AuthStatusId { set; get; }

        //[Column("LAST_ACTION")]
        //[Display(Name = "Last Action")]
        //public string LastAction { set; get; }

        //[Column("LAST_UPDATE_DT")]
        //[Display(Name = "Last Update Date")]
        //public DateTime? LastUpdateDT { set; get; }

        [Column("MAKE_BY")]
        [Display(Name = "Make By")]
        public string MakeBy { set; get; }

        [Column("MAKE_DT")]
        [Display(Name = "Make Date")]
        public DateTime? MakeDT { set; get; }

        [NotMapped]
        [Display(Name = "Opening Balance")]
        public decimal OpeningBalance { set; get; }

        [NotMapped]
        [Display(Name = "Closing Balance")]
        public decimal ClosingBalance { set; get; }

        [NotMapped]
        [Display(Name = "Applied Profit")]
        public Nullable<decimal> AppliedProfit { set; get; }

        [NotMapped]
        public string[] SelectedLedgerTxnIdList { set; get; }

        [NotMapped]
        [Display(Name = "From Date")]
        public DateTime? FromDate { set; get; }

        [NotMapped]
        [Display(Name = "To Date")]
        public DateTime? ToDate { set; get; }

        [NotMapped]
        [Display(Name = "From Transection Id")]
        public string FromTransectionId { set; get; }

        [NotMapped]
        [Display(Name = "To Transection Id")]
        public string ToTransectionId { set; get; }

        [NotMapped]
        [Display(Name = "From Account Profile Id")]
        public string FromAccProfileId { set; get; }

        [NotMapped]
        [Display(Name = "To Account Profile Id")]
        public string ToAccProfileId { set; get; }

        [NotMapped]
        [Display(Name = "From Account Type Id")]
        public string FromAccountTypeId { set; get; }

        [NotMapped]
        [Display(Name = "To Account Type Id")]
        public string ToAccountTypeId { set; get; }

        [NotMapped]
        [Display(Name = "Wallet Account No")]
        public string WalletAccountNo { set; get; }

        [NotMapped]
        public string TotalAmountOfTransaction { set; get; }

        [NotMapped]
        public string TotalNoOfTransaction { set; get; }

        [NotMapped]
        public DateTime? StartDate { set; get; }

        [NotMapped]
        public DateTime? EndDate { set; get; }
    }
}
