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
    public class GLChart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("GL_ACC_SL")]
        [Display(Name = "GL Account SL")]
        public string GLAccSl { set; get; }

        [Column("GL_ACC_NO")]
        [Display(Name = "GL Account No")]
        public string GLAccNo { set; get; }

        [Column("GL_ACC_NM")]
        [Display(Name = "GL Account Name")]
        public string GLAccName { set; get; }

        [Column("GL_PREFIX")]
        [Display(Name = "GL Prefix")]
        public string GLPrefix { set; get; }

        [Column("TOTALLING_ACC_SL")]
        [Display(Name = "Totalling Account Sl")]
        public string TotalingAccSl { set; get; }

        [Column("GL_TYPE")]
        [Display(Name = "GL Type")]
        public string GLType { set; get; }

        [Column("GL_ACC_TYPE")]
        [Display(Name = "GL Account Type")]
        public string GLAccType { set; get; }

        [Column("GL_LEVEL")]
        [Display(Name = "GL Level")]
        public int? GLLevel { set; get; }

        [Column("GL_CURRENCY_ID")]
        [Display(Name = "Currency")]
        public string GLCurrencyId { set; get; }

        [Column("POSTABLE")]
        [Display(Name = "Postable")]
        public int? Postable { set; get; }

        [Column("OFF_BS_FLAG")]
        [Display(Name = "Balance Sheet Item")]
        public int? OffBSFlag { set; get; }

        [Column("STATEMENT_CYCLE")]
        [Display(Name = "Statement Cycle")]
        public string StatementCycle { set; get; }

        [Column("OPENING_DT")]
        [Display(Name = "Opening Date")]
        public DateTime OpeningDate { set; get; }

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
