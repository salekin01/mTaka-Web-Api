using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.Charge
{
    [Serializable]
    [Table("MTK_CHARGES_CATEGORY")]
    public class ChargesCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CATEGORY_ID")]
        [Display(Name = "Rule Type Id")]
        public int CategoryId { set; get; }

        [Column("CATEGORY_NAME")]
        [Display(Name = "Rule Type Name")]
        public string CategoryName { set; get; }

        [Column("CATEGORY_SH_NAME")]
        [Display(Name = "Rule Type Id")]
        public string CategorySHName { set; get; }

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

    }
}
