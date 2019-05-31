using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.USB
{
    [Serializable]
    [Table("MTK_USB_COLLECTION")]
    public class UsbCollection
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("BILL_SL_NO")]
        [Display(Name = "Bill Sl No")]
        public string BillSlNo { set; get; }

        [Column("BILL_NO")]
        [Display(Name = "Boll No")]
        public string billNumber { set; get; }

        [Column("PV_ID")]
        [Display(Name = "Provider Id")]
        public string PvId { set; get; }

        [Column("TOTAL_PAYABLE_AMOUNT")]
        [Display(Name = "Total Payble Amount")]
        public decimal totalBillAmount { get; set; }

        [Column("TOTAL_PAID_AMOUNT")]
        [Display(Name = "Total Paid Amount")]
        public decimal totalPaidAmount { set; get; }

        [Column("LPC")]
        [Display(Name = "Late Payment")]
        public string Lpc { get; set; }

        [Column("VAT_AMOUNT")]
        [Display(Name = "Vat Amount")]
        public string VatAmount { set; get; }

        [Column("PAID")]
        [Display(Name = "Paid")]
        public string Paid { get; set; }

        [Column("DUE_DATE")]
        [Display(Name = "Due Date")]
        public string billDueDate { set; get; }

        [Column("DEPARTMENT_ID")]
        [Display(Name = "Department Id")]
        public string depatmentId { get; set; }

        [Column("ORGANIZATION_CODE")]
        [Display(Name = "Organization Code")]
        public string organizationCode { set; get; }

        [Column("ACCOUNT_NO")]
        [Display(Name = "Account No")]
        public string AccountNo { get; set; }

        [Column("MAKE_DATE")]
        [Display(Name = "Make Date")]
        public DateTime? MakeDate { get; set; }

        [Column("MAKE_BY")]
        [Display(Name = "Make By")]
        public string MakeBy { get; set; }

        [Column("TRANS_DATE")]
        [Display(Name = "Trans Date")]
        public DateTime? TransDate { get; set; }

        [Column("SYS_ACC_NO")]
        [Display(Name = "Sys Acc No")]
        public string SysAccNo { get; set; }

        [NotMapped]
        public string WalletAccountNo { get; set; }

        [NotMapped]
        public DateTime? FormDate { get; set; }

        [NotMapped]
        public DateTime? ToDate { get; set; }

        [NotMapped]
        public string FromSystemAccountNo { get; set; }

        [NotMapped]
        public Nullable<decimal> CurrentBalance { set; get; }

        [NotMapped]
        [Display(Name = "Function Id")]
        public string FunctionId { set; get; }

        [NotMapped]
        [Display(Name = "Function Name")]
        public string FunctionName { set; get; }
    }
}
