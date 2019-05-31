using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.SP
{
    [Serializable]
    [Table("MTK_SP_TRANSACTION_RULES")]
    public class TransactionRules
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("TRANS_RULE_ID")]
        [Display(Name = "Transaction Rule Id")]
        public string TransactionRuleId { set; get; }

        [Column("ACC_TYPE_1")]
        [Display(Name = "Account type 1")]
        public string AccountType1 { set; get; }

        [Column("ACC_TYPE_2")]
        [Display(Name = "Account type 2")]
        public string AccountType2 { set; get; }

        [Column("COMMISSION_ALLOWED")]
        [Display(Name = "Commission Allowed")]
        public string commissionAllowed { set; get; }

        [Column("TRANSACTION_ALLOWED")]
        [Display(Name = "Tranaction Allowed")]
        public string TranactionAllowed { set; get; }

        [Required]
        [Column("DEFINE_SERVICE_ID")]
        [Display(Name = "Define Service Id")]
        public string DefineServiceId { set; get; }

        #region Common
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
        #endregion

        [NotMapped]
        [Display(Name = "From Account No.")]
        public string FromSystemAccountNo { set; get; }

        [NotMapped]
        [Display(Name = "To Account No.")]
        public string ToSystemAccountNo { set; get; }

        [NotMapped]
        [Display(Name = "Account type1 Name")]
        public string AccountType1Nm { set; get; }

        [NotMapped]
        [Display(Name = "Account type2 Name")]
        public string AccountType2Nm { set; get; }

        [NotMapped]
        [Display(Name = "Define Service Name")]
        public string DefineServiceNm { set; get; }

        #region Lgurda
        [NotMapped]
        [Display(Name = "Main Authorization Flag")]
        public string GetAuthPermissionByFunctionIdResult { set; get; }
        #endregion

        public virtual DefineService DefineService { get; set; }

        [NotMapped]
        public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
