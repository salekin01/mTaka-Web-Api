using mTaka.Data.BusinessEntities.SP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mTaka.Data.BusinessEntities.Charge
{
    [Serializable]
    [Table("MTK_CHG_RULE")]
    public class ChargeRule
    {
        public ChargeRule()
        {
            this.CusCategories = new HashSet<CusCategory>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CHARGE_RULE_ID")]
        [Display(Name = "Charge Rule Id")]
        public string ChargeRuleId { set; get; }

        [Column("CHARGE_RULE_NM")]
        [Display(Name = "Charge Rule Name")]
        public string ChargeRuleName { set; get; }

        [Column("CHARGE_RULE_TYPE_ID")]
        [Display(Name = "Charge Rule Type Id")]
        public string ChargeRuleTypeId { set; get; }

        [Column("CHARGE_CATEGORY_LGID")]
        [Display(Name = "Charge Ctg Log Id")]
        public int ChargeCtgLogId { set; get; }

        [Column("RATE_METHOD_ID")]
        [Display(Name = "Rate Method Id")]
        public string RateMethodId { set; get; }

        [Column("RATE_TYPE_ID")]
        [Display(Name = "Rate Type Id")]
        public string RateTypeId { set; get; }

        [Column("RATE_FLAT_PERCENT")]
        [Display(Name = "Rate Persent")]
        public decimal? RatePersent { set; get; }

        [Column("RATE_FLAT_AMOUNT")]
        [Display(Name = "Rate Amount")]
        public decimal? RateAmount { set; get; }

        [Column("MIN_AMOUNT")]
        [Display(Name = "Minimum Amount")]
        public decimal? MinAmount { set; get; }

        [Column("MAX_AMOUNT")]
        [Display(Name = "Maximum Amount")]
        public decimal? MaxAmount { set; get; }
        
        [Column("RATE_PERIOD_NO")]
        [Display(Name = "Rate Period No")]
        public int? RatePrdNo { set; get; }

        [Column("RATE_PERIOD_ID")]
        [Display(Name = "Rate Period Id")]
        public string RatePrdId { set; get; }

        [Column("DECIMAL_ROUND_ID")]
        [Display(Name = "Decimal Round Id")]
        public string DecRndId { set; get; }

        [Column("GL_ACCOUNT_SL")]
        [Display(Name = "GL Account SL")]
        public string GLAccSl { set; get; }

        [Column("CHARGE_EVENT_ID")]
        [Display(Name = "Charge Event Id")]
        public string ChargeEventId { set; get; }

        [Column("CHILD_CHARGE_RULE_FLAG")]
        [Display(Name = "Child Charge Rule Flag")]
        public string ChildChargeRuleFlag { set; get; }

        [Column("PARENT_CHARGE_RULE_ID")]
        [Display(Name = "Parent Charge Rule ID")]
        public string ParentChargeRuleID { set; get; }

        [Column("CHARGE_ACTUAL_FLAG")]
        [Display(Name = "Charge Actual Flag")]
        public string ChargeActulaFlag { set; get; }

        [Column("CHARGE_ACTUAL_TYPE_ID")]
        [Display(Name = "Charge Actual Type Id")]
        public string ChargeActTypeId { set; get; }

        [Column("SWAP_GL_ACCOUNT_SL")]
        [Display(Name = "Swap GL Acc SL")]
        public string SwapAccSl { set; get; }

        [Column("CHARGE_ONDEMAND_FLAG")]
        [Display(Name = "Charge Ondemand Flag")]
        public string ChargeOndemandFlag { set; get; }

        [Column("ACCOUNT_BALANCE_FLAG")]
        [Display(Name = "Account Balance Flag")]
        public string AccBalanceFlag { set; get; }

        [Column("ACCOUNT_BALANCE")]
        [Display(Name = "Account Balance")]
        public decimal AccBalance { set; get; }

        [Column("TAX_PENALTY_RATE")]
        [Display(Name = "Tax Penalty Rate")]
        public decimal? TaxPenaltyRate { set; get; }

        [Column("DR_CR")]
        [Display(Name = "Debit or Credit")]
        public string DebitOrCredit { set; get; }

        [Column("ACC_TYPE_ID")]
        [Display(Name = "Account Type Id")]
        public string AccountTypeId { set; get; }

        [Column("BALANCE_METHOD_ID")]
        [Display(Name = "Balance Method Id")]
        public string BalanceMethodId { set; get; }

        [Column("POINT_OF_TIME_BAL_FLAG")]
        [Display(Name = "Point of Time Balance Flag")]
        public string PointTimeBalFlag { set; get; }

        [Column("INSUFFICIENT_BAL_REALIZE_ID")]
        [Display(Name = "Insufficient Balance Realize Id")]
        public string InsuffBalRefId { set; get; }

        [Column("DEDUCT_PERIOD_ID")]
        [Display(Name = "Deduct Period Id")]
        public string DeductPrdId { set; get; }

        [Column("DEDUCT_COND_FLAG")]
        [Display(Name = "Deduct Condition Flag")]
        public string DeductCondtionFlag { set; get; }

        [Column("DEDUCT_COND_ID")]
        [Display(Name = "Deduct Condition Id")]
        public string DeductCondtionId { set; get; }

        [Column("DEDUCT_COND_VALUE")]
        [Display(Name = "Deduct Condition Value")]
        public int? DeductCondtionValue { set; get; }

        [Column("CUSTOMER_FILTER_APPLY_FLAG")]
        [Display(Name = "Customer Filter Apply Flag")]
        public string CustomerFilterAppFlag { set; get; }

        [Column("CUSTOMER_FILTER_TYPE_ID")]
        [Display(Name = "Customer Filter Apply Id")]
        public string CustomerFilterAppId { set; get; }

        [Column("STAFF_ACCOUNT_EXCLUDE_FLAG")]
        [Display(Name = "Staff Account Exclude Flag")]
        public string StaffAccExcFlag { set; get; }

        [Column("NEXT_APPLY_DT")]
        [Display(Name = "Next Apply Date")]
        public DateTime? NextApplyDate { set; get; }

        [Column("CHARGE_APPLY_COND_FLAG")]
        [Display(Name = "Charge Apply Condition Flag")]
        public string ChargeAppConFlag { set; get; }

        [Column("EXCHANGE_RATE_ID")]
        [Display(Name = "Exchange Rate Id")]
        public string ExchangeRateId { set; get; }

        [Column("NBR_CATEGORY_ID")]
        [Display(Name = "NBR Category Id")]
        public string NBRCatgoryId { set; get; }

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
        public string FunctionId { set; get; }

        [NotMapped]
        public ChargeDeductCust[] ListChargeDeductCust { set; get; }
        [NotMapped]
        public ChargeApplyDateTime[] ListChargeApplyDT { set; get; }

        public virtual ICollection<CusCategory> CusCategories { get; set; }

        //public virtual ChargeRuleType ChargeRuleTypes { get; set; }
        //public virtual ChargesCategory ChargesCategories { get; set; }
        //public virtual ChargeRateMethod ChargeRateMethods { get; set; }
        //public virtual ChargeRateType ChargeRateTypes { get; set; }
        //public virtual CalenderPeriod CalenderPeriod { get; set; }
        //public virtual DecimalRounding DecimalRoundings { get; set; }
        //public virtual ChargeActType ChargeActTypes { get; set; }
        //public virtual DefineService DefineServices { get; set; }
        //public virtual ChargeDeductCust ChargeDeductCustomers { get; set; }
    }
}
