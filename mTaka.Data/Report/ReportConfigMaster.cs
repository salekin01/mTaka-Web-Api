using mTaka.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.Report
{
    [Serializable]
    [Table("MTK_RPT_CONFIG_MAST")]
    public class ReportConfigMaster 
    {
        public ReportConfigMaster()
        {
            ReportConfigParams = new List<ReportConfigParam>();
            DatabaseConnection = new DatabaseConnectionConfig();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column("FUNCTION_ID")]
        public string FunctionId { get; set; }
        [Column("REPORT_NAME")]
        public string ReportName { get; set; }
        [Column("REPORT_FILE")]
        public string ReportFile { get; set; }
        [Column("AUTO_GEN_PERIOD")]
        public string AutoGenPeriod { get; set; }
        [Column("GEN_BEFORE_EOD")]
        public string GenBeforeEod { get; set; }
        [Required]
        [Column("CONNECTION_ID")]
        public string ConnectionId { get; set; }
        [Column("MAKE_BY")]
        public string MakeBy { get; set; }
        [Column("MAKE_DT")]
        public DateTime? MakeDt { get; set; }
        [Column("IS_VISIBLE")]
        public string IsVisible { get; set; }

        [MTKAttributes(isNftLog = false)]
        [NotMapped]
        public virtual List<ReportConfigParam> ReportConfigParams { get; set; }

        [MTKAttributes(isNftLog = false)]
        [NotMapped]
        public virtual DatabaseConnectionConfig DatabaseConnection { get; set; }
    }
}
