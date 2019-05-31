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
    [Table("MTK_SP_CUS_TYPE_WISE_SERVICE")]
    public class CusTypeWiseServiceList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CUS_TYPE_WISE_SERVICE_ID")]
        [Display(Name = "Account Type Wise Service Id")]
        public string CusTypeWiseServiceId { set; get; }

        [Required]
        [Column("ACC_TYPE_ID")]
        [Display(Name = "Account Type Id")]
        public string AccTypeId { set; get; }

        [Required]
        [Column("ACC_CATEGORY_ID")]
        [Display(Name = "Account Category Id")]
        public string AccCategoryId { set; get; }

        [Required]
        [Column("ACC_SRVICE_ID")]
        [Display(Name = "Account Service Id")]
        public string DefineServiceId { set; get; }

        #region NotMapped

        public virtual AccCategory AccountCategory { get; set; }

        [NotMapped]
        public string AccCategoryNm { set; get; }

        public virtual AccType AccountType { get; set; }

        [NotMapped]
        public string AccountTypeNm { set; get; }

        public virtual DefineService DefineService { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> DefineServiceArray { get; set; }

        [NotMapped]
        public string ServiceNm { set; get; }
        #endregion

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
        public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
