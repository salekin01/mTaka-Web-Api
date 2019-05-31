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
    [Table("MTK_SP_MAN_TYPE")]
    public class ManagerType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("MAN_TYPE_ID")]
        [Display(Name = "Manager Type Id")]
        public string ManTypeId { set; get; }

        [Column("MAN_TYPE_NM")]
        [Display(Name = "Manager Type Name")]
        public string ManTypeNm { set; get; }

        [Column("SHORT_NM")]
        [Display(Name = "Short Name")]
        public string ManTypeShortNm { get; set; }

        [Column("MAN_CAT_ID")]
        [Display(Name = "Manager Category Id")]
        public string ManagerCategoryId { set; get; }

        [Column("PARENT_ACC")]
        [Display(Name = "Parent Account")]
        public string ManTypeParentAcc { get; set; }

        public virtual ManCategory ManCategory { get; set; }

        [NotMapped]
        public string ManagerCategoryNm { set; get; }

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
        public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
