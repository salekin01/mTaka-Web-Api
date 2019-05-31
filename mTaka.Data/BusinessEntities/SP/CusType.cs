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
    [Table("MTK_SP_CUS_TYPE")]
    public class CusType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CUS_TYPE_ID")]
        [Display(Name = "Customer Type Id")]
        public string CusTypeId { set; get; }

        [Column("CUS_TYPE_NM")]
        [Display(Name = "Customer Type Name")]
        [Required(ErrorMessage = "Customer Type name is required")]
        public string CusTypeNm { set; get; }

        [ForeignKey("CusCategory")]
        [Column("CUS_CATEGORY_ID")]
        [Display(Name = "Customer category Id")]
        [Required(ErrorMessage = "Customer category is required")] 
        public string CusCategoryId { set; get; }

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

        public virtual CusCategory CusCategory { get; set; }

        [NotMapped]
        [Display(Name = "Customer category Name")]
        public string CusCategoryNm { set; get; }

        [NotMapped]
        public IEnumerable<SelectListItem> CusCategoryDD { get; set; }

        [NotMapped]
        public List<Test> ListTest { get; set; }

        [NotMapped]
        public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
