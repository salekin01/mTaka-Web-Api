using mTaka.Data.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mTaka.Data.Report
{
    [Serializable]
    [Table("MTK_RPT_CONFIG_PARAM")]
    public class ReportConfigParam 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column("FUNCTION_ID", Order = 0)]
        public string FunctionId { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column("SL_NO", Order = 1)]
        public int SlNo { get; set; }
        [Column("PARAMETER")]
        public string Parameter { get; set; }
        [Column("PARAMETER_NAME")]
        public string ParameterName { get; set; }
        [Column("PARAMETER_DATATYPE")]
        public string ParameterDatatype { get; set; }
        [Column("PARAMETER_MAXLENGTH")]
        public string ParameterMaxlength { get; set; }
        [Column("DEFAULT_VALUE")]
        public string DefaultValue { get; set; }
        [Column("PARAMETER_USER_ASIST")]
        public string ParameterUserAsist { get; set; }
        [Column("IS_MANDATORY")]
        public string IsMandatory { get; set; }
        [Column("CONTROL_TYPE")]
        public string ControlType { get; set; }
        [Column("LIST_SP_NAME")]
        public string ListSpName { get; set; }
        [Column("IS_READONLY")]
        public string IsReadonly { get; set; }
        [Column("IS_VISIBLE")]
        public string IsVisible { get; set; }
        [Column("MIN_VALUE")]
        public string MinValue { get; set; }
        [Column("MAX_VALUE")]
        public string MaxValue { get; set; }
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
        [NotMapped]
        [MTKAttributes(isNftLog = false)]
        public string Value { get; set; }
    }
}
