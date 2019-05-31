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
    [Table("MTK_ROUNDING")]
    public class DecimalRounding
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ROUNDING_ID")]
        [Display(Name = "Rounding Id")]
        public string RoundingId { set; get; }

        [Column("ROUNDING_NM")]
        [Display(Name = "Rounding Name")]
        public string RoundingName { set; get; }

        [Column("ROUNDING_DESC")]
        [Display(Name = "Rounding Description")]
        public string RoundingDesc { set; get; }

        [Column("MAKE_BY")]
        [Display(Name = "Make By")]
        public string MakeBy { set; get; }

        [Column("MAKE_DT")]
        [Display(Name = "Make Date")]
        public DateTime? MakeDT { set; get; }
    }
}
