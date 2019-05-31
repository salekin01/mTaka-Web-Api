using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.ACC
{
    [Serializable]
    [Table("MTK_ACC_MASTER")]
    public class AccMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ACC_ID")]
        [Display(Name = "Account Id")]
        public string AccountId { set; get; }

        //[Required]
        //[Column("ACC_PROFILE_ID")]
        //[Display(Name = " Account Profile Id")]
        //public string AccProfileId { set; get; }

        [Required]
        [Column("WALLET_ACC_NO")]
        [Display(Name = "Wallet Account No")]
        public string WalletAccountNo { set; get; }

        [Required]
        [Column("SYS_ACC_NO")]
        [Display(Name = "System Account No.")]
        public string SystemAccountNo { set; get; }

        [Required]
        [Column("ACC_TYPE_ID")]
        [Display(Name = "Account Type")]
        public string AccTypeId { set; get; }

        [Required]
        [Column("ACC_STATUS_ID")]
        [Display(Name = "Account Status Id")]
        public string AccountStatusId { set; get; }

        [Required]
        [Column("ACC_NM")]
        [Display(Name = "Account Name")]
        public string AccNm { set; get; }

        [Column("BANK_ACC_NO")]
        [Display(Name = "Bank Account No")]
        public string BankAccountNo { set; get; }

        [Column("ACC_BALANCE")]
        [Display(Name = "Acc Balance")]
        public string AccBalance { set; get; }

        [Column("TOTAL_CHARGE")]
        [Display(Name = "Total Charge")]
        public string TotalCharge { set; get; }

        [Column("AUTH_STATUS_ID")]
        [Display(Name = "Auth. Status Id")]
        public string AuthStatusId { set; get; }

        [Column("LAST_ACTION")]
        [Display(Name = "Last Action")]
        public string LastAction { set; get; }

        //[Column("LAST_UPDATE_DT")]
        //[Display(Name = "Last Update Date")]
        //public DateTime? LastUpdateDT { set; get; }

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
        [Display(Name = "From Account No.")]
        public string FromSystemAccountNo { set; get; }

        [NotMapped]
        [Display(Name = "To Account No.")]
        public string ToSystemAccountNo { set; get; }

        [NotMapped]
        [Display(Name = "To Account No.")]
        public string ToSystemAccountNo1 { set; get; }

        [NotMapped]
        [Display(Name = "From Account Type")]
        public string FromAccType { set; get; }

        [NotMapped]
        [Display(Name = "To Account Type")]
        public string ToAccType { set; get; }

        [NotMapped]
        [Display(Name = "Function Id")]
        public string FunctionId { set; get; }

        //[NotMapped]
        //public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
