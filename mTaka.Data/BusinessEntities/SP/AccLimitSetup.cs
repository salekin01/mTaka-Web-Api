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
    [Table("MTK_SP_ACC_LIMIT_SETUP")]
    public class AccLimitSetup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ACC_LIMIT_ID")]
        [Display(Name = "Account Limit Id")]
        public string AccLimitId { set; get; }

        //[Required]
        [Column("ACC_CATEGORY_ID")]
        [Display(Name = "Account Category")]
        public string AccCategoryId { set; get; }

        //[Required]
        [Column("ACC_TYPE_ID")]
        [Display(Name = "Account Type")]
        public string AccTypeId { set; get; }

        //[Required]
        [Column("DEFINE_SERVICE_ID")]
        [Display(Name = "Define Service Id")]
        public string DefineServiceId { set; get; }

        [Required]
        [Column("NO_OF_OCCURENCE")]
        [Display(Name = "No. Of Occurrence")]
        public string NoOfOccurrence { set; get; }

        [Required]
        [Column("AMOUNT_OF_OCCURENCE")]
        [Display(Name = "Amount Of Occurrence")]
        public decimal AmountOfOccurrence { set; get; }

        [Required]
        [Column("AMOUNT_OF_TOTAL_OCCURENCE")]
        [Display(Name = "Amount Of total Occurrences")]
        public decimal AmountOftotalOccurrences { set; get; }

        #region NotMapped
        [NotMapped]
        public string AllAccCategory { set; get; }

        [NotMapped]
        public string AllAccType { set; get; }

        [NotMapped]
        public string AllDefineService { set; get; }

        public virtual AccCategory AccountCategory { get; set; }

        [NotMapped]
        public string AccCategoryNm { set; get; }

        public virtual AccType AccountType { get; set; }

        [NotMapped]
        public string AccountTypeNm { set; get; }

        public virtual DefineService DefineService { get; set; }

        [NotMapped]
        public string ServiceNm { set; get; }
        #endregion


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

        [Column("BALANCE_LIMIT")]
        [Display(Name = "Balance Limit")]
        public decimal? BalanceLimit { set; get; }

        [NotMapped]
        [Display(Name = "From Account No.")]
        public string FromSystemAccountNo { set; get; }

        [NotMapped]
        [Display(Name = "To Account No.")]
        public string ToSystemAccountNo { set; get; }

        [NotMapped]
        [Display(Name = "From Account Type")]
        public string FromAccType { set; get; }

        [NotMapped]
        [Display(Name = "To Account Type")]
        public string ToAccType { set; get; }

        [NotMapped]
        [Display(Name = "Amount")]
        public decimal Amount { set; get; }

        [NotMapped]
        public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
