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
    [Table("MTK_FT_AUTH_LOG_DTL")]
    public class FTAuthLogDtl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("SL")]
        [Display(Name = "Serial Id")]
        public string Sl { set; get; }

        [Column("LOG_ID")]
        [Display(Name = "Log Id")]
        public string LogId { set; get; }

        [Column("LOG_CHILD_ID")]
        [Display(Name = "Log Child Id")]
        public string LogChildId { set; get; }

        [Column("MODEL_NM")]
        [Display(Name = "Model Name")]
        public string ModelNm { set; get; }

        [Column("TABLE_NM")]
        [Display(Name = "Table Name")]
        public string TableNm { set; get; }

        [Column("TABLE_COL_NM")]
        [Display(Name = "Table Column Name")]
        public string TableColNm { set; get; }

        [Column("TABLE_PK_COL_FLAG")]
        [Display(Name = "Primarykey Column Flag")]
        public int TablePkColFlag { set; get; }

        [Column("OLD_VALUE")]
        [Display(Name = "Old Value")]
        public string OldValue { set; get; }

        [Column("NEW_VALUE")]
        [Display(Name = "New Value")]
        public string NewValue { set; get; }

        [Column("DISPLAY_TABLE_COL_NM")]
        [Display(Name = "Display Table Column Name")]
        public string DisplayTableColNm { set; get; }
    }
}
