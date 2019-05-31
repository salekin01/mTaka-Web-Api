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
    [Table("MTK_GLLVL_POLICY")]
    public class GLLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("GL_LVL_SL")]
        [Display(Name = "GL Level SL")]
        public string GLLevelSL { set; get; }

        [Column("GL_LVL_LENTH")]
        [Display(Name = "GL Level Length")]
        public string GLLevelLth { set; get; }

        [Column("GL_LVL_REMARK")]
        [Display(Name = "GL Level Remark")]
        public string GLLevelRemark { set; get; }

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
