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
    [Table("MTK_SP_ACC_TYPE")]
    public class AccType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ACC_TYPE_ID")]
        [Display(Name = "Account Type Id")]
        public string AccTypeId { set; get; }

        [Column("ACC_TYPE_NM")]
        [Display(Name = "Account Type Name")]
        public string AccTypeNm { set; get; }

        [Column("ACC_TYPE_SHORT_NM")]
        [Display(Name ="Short Name")]
        public string AccTypeShortNm { get; set; }

        [Column("ACC_CATEGORY_ID")]
        [Display(Name = "Account Category Id")]
        public string AccCategoryId { set; get; }

        public virtual AccCategory AccCategory { get; set; }

        [NotMapped]
        public string AccCategoryNm { set; get; }

        [Column("ACC_TYPE_PARENT_ACC")]
        [Display(Name = "Parent Account")]
        public string AccTypeParentAcc { get; set; }

        //[NotMapped]
        //public string AccTypeParentAccNm { get; set; }

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
