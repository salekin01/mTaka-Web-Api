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
    [Table("MTK_CALENDAR_PERIOD")]
    public class CalenderPeriod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CALENDAR_PERIOD_ID")]
        [Display(Name = "Calender Period Id")]
        public string CalenderPrdId { set; get; }

        [Column("CALENDAR_PERIOD_NM")]
        [Display(Name = "Calender Period Name")]
        public string CalenderPrdName { set; get; }

        [Column("SORT_SL_NO")]
        [Display(Name = "Sorted SL No")]
        public string SortedSlNo { set; get; }

        [Column("MAKE_BY")]
        [Display(Name = "Make By")]
        public string MakeBy { set; get; }

        [Column("MAKE_DT")]
        [Display(Name = "Make Date")]
        public DateTime? MakeDT { set; get; }
    }
}
