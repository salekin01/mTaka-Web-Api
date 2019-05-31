using mTaka.Data.BusinessEntities.Charge;
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
    [Table("MTK_SP_CUS_CATEGORY")]
    public class CusCategory
    {
        public CusCategory()
        {
            this.ChargeRules = new HashSet<ChargeRule>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CUS_CATEGORY_ID")]
        [Display(Name = "Customer Group Id")]
        public string CusCategoryId { set; get; }

        [Column("CUS_CATEGORY_NM")]
        [Display(Name = "Customer Group Name")]
        public string CusCategoryNm { set; get; }

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

        public virtual ICollection<ChargeRule> ChargeRules { get; set; }

        [NotMapped]
        public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}


