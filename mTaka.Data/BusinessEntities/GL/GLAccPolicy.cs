using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.GL
{
    [Serializable]
    [Table("MTK_GL_CHART")]
    public class GLAccPolicy
    {
      
        [Column("GL_MAX_LVL")]
        [Display(Name = "GL Max Level")]
        public string GLMaxLVL { set; get; }

        [Column("GL_ACC_NO_TOT_LENTH")]
        [Display(Name = "GL Acc Length")]
        public string GLAccLen { set; get; }
        
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
