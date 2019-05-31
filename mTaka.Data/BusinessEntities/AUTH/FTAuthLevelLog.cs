using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.AUTH
{
    [Serializable]
    [Table("MTK_FT_AUTH_LEVEL_LOG")]
    public class FTAuthLevelLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("SL")]
        [Display(Name = "Serial Id")]
        public string Sl { set; get; }

        [Column("LOG_ID")]
        [Display(Name = "Log Id")]
        public string LogId { set; get; }

        [Column("FUNCTION_ID")]
        [Display(Name = "Function Id")]
        public string FunctionId { set; get; }

        [Column("LAST_ACTION")]
        [Display(Name = "Last Action")]
        public string LastAction { set; get; }

        [Column("MAKE_BY")]
        [Display(Name = "Make By")]
        public string MakeBy { set; get; }

        [Column("MAKE_DT")]
        [Display(Name = "Make Date")]
        public DateTime? MakeDT { set; get; }

        [Column("LAST_AUTH_BY")]
        [Display(Name = "Last Auth By")]
        public string LastAuthBy { set; get; }

        [Column("LAST_AUTH_DT")]
        [Display(Name = "Last Auth Date")]
        public DateTime? LastAuthDT { set; get; }

        [Column("REMARKS")]
        [Display(Name = "Remarks")]
        public string Remarks { set; get; }

        [Column("LEVEL_LOG_STATUS")]
        [Display(Name = "Level Log Status")]
        public string LevelLogStatus { set; get; }

        [Column("AUTH_LEVEL_PENDING")]
        [Display(Name = " Pending Auth Level")]
        public int AuthLevelPending { set; get; }
    }
}
