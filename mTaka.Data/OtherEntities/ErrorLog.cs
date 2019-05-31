using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.OtherEntities
{
    [Table("MTK_ERROR_LOG")]
    public class ErrorLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("SL")]
        [Display(Name = "SL")]
        public string SL { set; get; }

        [Column("FUNCTION_ID")]
        [Display(Name = "Function Id")]
        public string FunctionId { set; get; }

        [Column("ERR_SOURCE")]
        [Display(Name = "Error Source")]
        public string ErrorSource { set; get; }

        [Column("ERR_METHOD")]
        [Display(Name = "Error Method")]
        public string ErrorMethod { set; get; }

        [Column("ERR_MESSAGE")]
        [Display(Name = "Error Message")]
        public string ErrorMessage { set; get; }

        [Column("INNER_EXCEPTION")]
        [Display(Name = "Inner Exception")]
        public string InnerException { set; get; }

        [Column("STACK_TRACE")]
        [Display(Name = "Stack Trace")]
        public string StackTrace { set; get; }

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
