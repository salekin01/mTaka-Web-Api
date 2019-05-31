using mTaka.Data.BusinessEntities.ACC;
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
    [Table("MTK_USER_TXN")]
    public class UserTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("SL")]
        [Display(Name = "Serial Id")]
        public string SerialId { set; get; }

        [Required]
        [Column("FROM_SYS_ACC_NO")]
        [Display(Name = "From Account No")]
        public string FromSystemAccountNo { set; get; }

        [NotMapped]
        [Display(Name = "From Account Balance")]
        public Nullable<decimal> FromAccountBalance { set; get; }

        //[Required]
        [Column("TO_SYS_ACC_NO")]
        [Display(Name = "To Account No.")]
        public string ToSystemAccountNo { set; get; }

        //[Required]
        [Column("AMOUNT")]
        [Display(Name = "Amount")]
        public decimal Amount { set; get; }

        [Column("SERVICE_ID")]
        [Display(Name = "Service Id")]
        public string ServiceId { set; get; }

        //[Required]
        [Column("NARRATION")]
        [Display(Name = "Narration")]
        public string Narration { set; get; }

        [Column("AUTH_STATUS_ID")]
        [Display(Name = "Auth. Status Id")]
        public string AuthStatusId { set; get; }

        [NotMapped]
        //[Column("LAST_ACTION")]
        [Display(Name = "Last Action")]
        public string LastAction { set; get; }

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
        public string WalletAccountNo { get; set; }

        [NotMapped]
        public DateTime? FromDate { get; set; }

        [NotMapped]
        public DateTime? ToDate { get; set; }

        [NotMapped]
        public bool Today { get; set; }

        [NotMapped]
        [Display(Name = "Function Id")]
        public string FunctionId { set; get; }

        [NotMapped]
        [Display(Name = "Function Name")]
        public string FunctionName { set; get; }

        [NotMapped]
        public int NumberOfCashIn { set; get; }

        //public virtual ChannelAccProfile ChannelAccProfile { get; set; }
    }
}