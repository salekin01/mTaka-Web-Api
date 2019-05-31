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
    [Table("MTK_CM_LEDGER_TXN_HIST")]
    public class CustomerLedgerTxnHist
    {
        [Key]
        [Column("SL_NO")]
        [Display(Name = "Sl No")]
        public string SlNo { set; get; }

        [Required]
        [Column("BATCH_NO")]
        [Display(Name = "Batch No")]
        public string BatchNo { set; get; }

        [Column("TXN_ID")]
        [Display(Name = "Transection Id")]
        public string TransectionId { set; get; }

        [Required]
        [Column("TXN_DT")]
        [Display(Name = "Transection Date")]
        public DateTime TransectionDate { set; get; }

        [Required]
        [Column("CUSTOMER_ID")]
        [Display(Name = "Customer Id")]
        public string CustomerId { set; get; }

        [Required]
        [Column("FROM_SYS_ACC_NO")]
        [Display(Name = "From System Account No.")]
        public string FromSystemAccountNo { set; get; }

        [Required]
        [Column("TO_SYS_ACC_NO")]
        [Display(Name = "To System Account No.")]
        public string ToSystemAccountNo { set; get; }

        [Required]
        [Column("ACC_TYPE_ID")]
        [Display(Name = "Account Type Id")]
        public string AccountTypeId { set; get; }

        [Column("PAYMENT_AMT")]
        [Display(Name = "Payment Amount")]
        public Nullable<decimal> PaymentAmount { set; get; }

        [Column("RCV_AMT")]
        [Display(Name = "Receive Amount")]
        public Nullable<decimal> ReceiveAmount { set; get; }

        [Column("CURRENT_BALANCE")]
        [Display(Name = "Current Balance")]
        public Nullable<decimal> CurrentBalance { set; get; }

        [Required]
        [Column("FUNCTION_ID")]
        [Display(Name = "Function Id")]
        public string FunctionId { set; get; }

        [Required]
        [Column("AMOUNT_ID")]
        [Display(Name = "Amount Id")]
        public string AmountId { set; get; }

        [Required]
        [Column("DEFINE_SERVICE_ID")]
        [Display(Name = "Define Service Id")]
        public string DefineServiceId { set; get; }

        [Required]
        [Column("NARRATION")]
        [Display(Name = "Narration")]
        public string Narration { set; get; }

        //[Required]
        //[Column("TXN_PARENT_ID")]
        //[Display(Name = "Transection Parent Id")]
        //public string TransectionParentId { set; get; }

        [Column("PRODUCT_ID")]
        [Display(Name = "Product Id")]
        public string ProductId { set; get; }

        [Column("BRANCH_ID")]
        [Display(Name = "Branch Id")]
        public string BranchId { set; get; }

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
        [Display(Name = "Customer Opening Balance")]
        public decimal CustomerOpeningBalance { set; get; }

        [NotMapped]
        [Display(Name = "Customer Closing Balance")]
        public decimal CustomerClosingBalance { set; get; }

        [NotMapped]
        [Display(Name = "Applied Profit")]
        public Nullable<decimal> AppliedProfit { set; get; }

        [NotMapped]
        public string[] SelectedCustomerLedgerTxnIdList { set; get; }

        [NotMapped]
        [Display(Name = "From Date")]
        public DateTime FromDate { set; get; }

        [NotMapped]
        [Display(Name = "To Date")]
        public DateTime ToDate { set; get; }

        [NotMapped]
        [Display(Name = "From Transection Id")]
        public string FromTransectionId { set; get; }

        [NotMapped]
        [Display(Name = "To Transection Id")]
        public string ToTransectionId { set; get; }

        [NotMapped]
        [Display(Name = "From Channel Account Profile Id")]
        public string FromAccProfileId { set; get; }

        [NotMapped]
        [Display(Name = "To Channel Account Profile Id")]
        public string ToAccProfileId { set; get; }

        [NotMapped]
        [Display(Name = "From Customer Id")]
        public string FromCustomerId { set; get; }

        [NotMapped]
        [Display(Name = "To Customer Id")]
        public string ToCustomerId { set; get; }

        [NotMapped]
        [Display(Name = "From Account Type Id")]
        public string FromAccountTypeId { set; get; }

        [NotMapped]
        [Display(Name = "To Account Type Id")]
        public string ToAccountTypeId { set; get; }

    }
}