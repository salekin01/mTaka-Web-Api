using mTaka.Data.BusinessEntities.CP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.TRN
{
    [Serializable]
    [Table("MTK_TRN_FUND_OUT")]
    public class FundOut
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("FUND_OUT_ID")]
        [Display(Name = "Fund Out Id")]
        public string FundOutId { set; get; }

        [Required]
        [Column("FROM_SYS_ACC_NO")]
        [Display(Name = "From Account No")]
        public string FromSystemAccountNo { set; get; }

        [NotMapped]
        [Display(Name = "From Account Balance")]
        public Nullable<decimal> FromAccountBalance { set; get; }

        //[Required]
        //[Column("FROM_ACC_TYPE_ID")]
        //[Display(Name = "From Account Type Id")]
        //public string FromAccountTypeId { set; get; }

        //[Required]
        [Column("TO_SYS_ACC_NO")]
        [Display(Name = "To Account No.")]
        public string ToSystemAccountNo { set; get; }

        //[Required]
        //[Column("TO_ACC_TYPE_ID")]
        //[Display(Name = "To Account Type Id")]
        //public string ToAccountTypeId { set; get; }

        //[Required]
        [Column("AMOUNT")]
        [Display(Name = "Amount")]
        public decimal Amount { set; get; }

        //[Required]
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

        [Column("TRANS_DATE")]
        [Display(Name = "Trans Date")]
        public DateTime? TransDT { set; get; }

        [NotMapped]
        [Display(Name = "Define Service Id")]
        public string DefineServiceId { set; get; }

        [NotMapped]
        [Display(Name = "Function Id")]
        public string FunctionId { set; get; }

        [NotMapped]
        [Display(Name = "Function Name")]
        public string FunctionName { set; get; }


        [NotMapped]
        public string WalletAccountNo { get; set; }

        [NotMapped]
        public DateTime? FormDate { get; set; }

        [NotMapped]
        public DateTime? ToDate { get; set; }

        [NotMapped]
        public bool Today { get; set; }
    }
}