using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.CP;
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
    [Table("MTK_SP_TRANSACTION_TEMPLATE")]
    public class TransactionTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("TRANS_TEMP_ID")]
        [Display(Name = "Transaction Template Id")]
        public string TransactionTemplateId { set; get; }

        [Required]
        [Column("DEFINE_SERVICE_ID")]
        [Display(Name = "Define Service Id")]
        public string DefineServiceId { set; get; }

        [NotMapped]
        [Display(Name = "Define Service Name")]
        public string DefineServiceName { set; get; }

        [Required]
        [Column("SOURCE_OF_ACC_ID")]
        [Display(Name = "Source of Account Id")]
        public string SourceofAccountId { set; get; }

        [NotMapped]
        [Display(Name = "Source of Account Name")]
        public string SourceofAccountName { set; get; }

        [Required]
        [Column("TYPE_OF_ACC_ID")]
        [Display(Name = "Type of Account Id")]
        public string TypeofAccountId { set; get; }

        [NotMapped]
        [Display(Name = "Type of Account Name")]
        public string TypeofAccountName { set; get; }

        [Required]
        [Column("ACC_TYPE_ID")]
        [Display(Name = "Account Type Id")]
        public string AccountTypeId { set; get; }

        [NotMapped]
        [Display(Name = "Account Type Name")]
        public string AccountTypeName { set; get; }

        [Required]
        [Column("GL_ACC_SL", Order = 1)]
        [Display(Name = "GL Account SL")]
        public string GLAccSl { set; get; }

        [NotMapped]
        [Display(Name = "GL Account Name")]
        public string GLAccName { set; get; }

        [Required]
        [Column("DR_CR")]
        [Display(Name = "Debit Or Credit")]
        public string DebitOrCredit { set; get; }

        [NotMapped]
        [Display(Name = "Balance Type Name")]
        public string BalanceTypeName { set; get; }

        [Required]
        [Column("NARRATION")]
        [Display(Name = "Narration")]
        public string Narration { set; get; }

        //[Required]
        [Column("CHARGE_RULE_ID")]
        [Display(Name = "Charge Rule Id")]
        public string ChargeRuleId { set; get; }

        [NotMapped]
        [Display(Name = "Charge Rule Name")]
        public string ChargeRuleName { set; get; }

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

        //[NotMapped]
        //[Display(Name = "Trans Date")]
        //public string id { set; get; }

        [NotMapped]
        public TransactionTemplate[] ListTransactionTemplate_API { set; get; }
        [NotMapped]
        public TransactionTemplate[] ListTransactionTemplate_API1 { set; get; }

        //[NotMapped]
        //[Display(Name = "Add to List")]

        [NotMapped]
        public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }

    }
    //public class TransactionTemplateContents
    //{
    //    public TransactionTemplate ListTransactionTemplate { get; set; }
    //}
}
