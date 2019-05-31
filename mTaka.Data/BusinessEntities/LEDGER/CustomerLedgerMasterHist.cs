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
    [Table("MTK_CM_LEDGER_MASTER_HIST")]
    public class CustomerLedgerMasterHist
    {
        [Key]
        [Column("SL_NO")]
        [Display(Name = "Sl No")]
        public string SlNo { set; get; }

        [Required]
        [Column("CUSTOMER_ID")]
        [Display(Name = "Customer Id")]
        public string CustomerId { set; get; }

        [Required]
        [Column("SYS_ACC_NO")]
        [Display(Name = "System Account No.")]
        public string SystemAccountNo { set; get; }

        [Required]
        [Column("ACC_TYPE_ID")]
        [Display(Name = "Account Type Id")]
        public string AccountTypeId { set; get; }

        [Required]
        [Column("CUSTOMER_OPENING_BALANCE")]
        [Display(Name = "Customer Opening Balance")]
        public decimal CustomerOpeningBalance { set; get; }

        [Required]
        [Column("CUSTOMER_CLOSING_BALANCE")]
        [Display(Name = "Customer Closing Balance")]
        public decimal CustomerClosingBalance { set; get; }

        [Required]
        [Column("TRANS_DATE")]
        [Display(Name = "Trans Date")]
        public DateTime TransDate { set; get; }

        [Column("PRODUCT_ID")]
        [Display(Name = "Product Id")]
        public string ProductId { set; get; }

        [Column("BRANCH_ID")]
        [Display(Name = "Branch Id")]
        public string BranchId { set; get; }

        [Column("LAST_CAL_DATE")]
        [Display(Name = "Last Calculate Date")]
        public DateTime? LastCalculateDate { set; get; }

        [Column("LAST_PROVISION_DATE")]
        [Display(Name = "Last Provision Date")]
        public DateTime? LastProvisionDate { set; get; }

        [Column("LAST_CHARGED_DATE")]
        [Display(Name = "Last Charged Date")]
        public DateTime? LastChargedDate { set; get; }

        [Column("LAST_PROFIT")]
        [Display(Name = "Last Profit")]
        public Nullable<decimal> LastProfit { set; get; }
    }
}