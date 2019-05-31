using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.Process
{
    [Serializable]
    [Table("MTK_PROCESS_EOD")]
    public class EOD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("EOD_SL_ID")]
        [Display(Name = "EOD ID")]
        public string EodId { set; get; }

        [Column("EOD_NM")]
        [Display(Name = "EOD NAME")]
        public string EodName { set; get; }

        [Column("EOD_DAY")]
        [Display(Name = "EOD DAY")]
        public string DayId { get; set; }

        [Column("EOD_TIME")]
        [Display(Name = "EOD TIME")]
        public DateTime? EODTime { set; get; }

        [Column("AUTH_STATUS_ID")]
        [Display(Name = "Auth. Status Id")]
        public string AuthStatusId { set; get; }

        [Column("LAST_ACTION")]
        [Display(Name = "Last Action")]
        public string LastAction { set; get; }

        [Column("LAST_UPDATE_DT")]
        [Display(Name = "Last Update Date")]
        public DateTime LastUpdateDT { set; get; }

        [Column("MAKE_BY")]
        [Display(Name = "Make By")]
        public string MakeBy { set; get; }

        [Column("MAKE_DT")]
        [Display(Name = "Make Date")]
        public DateTime? MakeDT { set; get; }
    }
}
