using mTaka.Data.BusinessEntities.Charge;
using mTaka.Data.BusinessEntities.TRN;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace mTaka.Data.BusinessEntities.SP
{
    [Serializable]
    [Table("MTK_SP_ACC_TYPE_WISE_TARGET")]
    public class AccTypeWiseTarget
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("TARGET_SL_ID")]
        [Display(Name = "Target Sl No")]
        public string TargetSlNo { set; get; }


        //[ForeignKey("AccCategoryId")]
        [Column("ACC_CATEGORY_ID")]
        [Display(Name = "Acc category Id")]
        [Required(ErrorMessage = "Acc category is required")]
        public string AccCategoryId { set; get; }
        //public virtual AccCategory FkAccCategory { get; set; }

        //[ForeignKey("AccTypeId")]
        [Column("ACC_TYPE_ID")]
        [Display(Name = "Acc Type Id")]
        [Required(ErrorMessage = "Acc Type is required")]
        public string AccTypeId { set; get; }

        //[ForeignKey("DefineServiceId")]
        [Column("SERVICE_ID")]
        [Display(Name = "Service Id")]
        [Required(ErrorMessage = "Service Id is required")]
        public string DefineServiceId { set; get; }

        //[ForeignKey("CalenderPrdId")]
        [Column("FREQUENCY_ID")]
        [Display(Name = "Frequency Id")]
        [Required(ErrorMessage = "Frequency required")]
        public string CalenderPrdId { set; get; }

        //[ForeignKey("TransTypeSlId")]
        [Column("TRANS_TYPE_ID")]
        [Display(Name = "Trans Type Id")]
        [Required(ErrorMessage = "Transaction Type Id is required")]
        public string TransTypeSlId { set; get; }

        [Column("AMOUNT")]
        [Display(Name = "Amount")]
        public string Amount { set; get; }

        [Column("DISTRICT")]
        [Display(Name = "District")]
        public string District { set; get; }

        [Column("AREA")]
        [Display(Name = "Area")]
        public string Area { set; get; }

        [Column("ACTUAL")]
        [Display(Name = "Actual")]
        public string Actual { set; get; }

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


        #region NotMapped

        public virtual AccCategory AccountCategory { get; set; }

        [NotMapped]
        public string AccCategoryNm { set; get; }

        public virtual AccType AccountType { get; set; }

        [NotMapped]
        public string AccountTypeNm { set; get; }

        public virtual DefineService DefineService { get; set; }

        [NotMapped]
        public string ServiceNm { set; get; }

        public virtual CalenderPeriod CalenderPeriod { get; set; }

        [NotMapped]
        public string CalenderPrdName { set; get; }

        public virtual TransactionType TransactionType { get; set; }

        [NotMapped]
        public string TransTypeName { set; get; }

        [NotMapped]
        public DateTime? FormDate { set; get; }

        [NotMapped]
        public DateTime? ToDate { set; get; }
        #endregion
        //public virtual AccType AccType { get; set; }
        //public virtual DefineService DefineService { get; set; }
        //public virtual CalenderPeriod CalenderPeriod { get; set; }
        //public virtual TransactionType TransactionType { get; set; }

        [NotMapped]
        public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
