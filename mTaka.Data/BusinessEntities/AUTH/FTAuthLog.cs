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
    [Table("MTK_FT_AUTH_LOG")]
    public class FTAuthLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("SL")]
        [Display(Name = "Serial Id")]
        public string Sl { set; get; }

        [Column("LOG_ID")]
        [Display(Name = "Log Id")]
        //[Required(ErrorMessage = "Log Id is required")]
        public string LogId { set; get; }

        [Column("BRANCH_ID")]
        [Display(Name = "Branch Id")]
        public string BranchId { set; get; }

        [Column("FUNCTION_ID")]
        [Display(Name = "Function Id")]
        public string FunctionId { set; get; }

        [Column("PRIMARY_TABLE_FLAG")]
        [Display(Name = "Primary Table Flag")]
        public int PrimaryTableFlag { set; get; }

        [Column("MODEL_NM")]
        [Display(Name = "Model Name")]
        public string ModelNm { set; get; }

        [Column("TABLE_NM")]
        [Display(Name = "Table Name")]
        public string TableNm { set; get; }

        [Column("TABLE_PK_COL_NM")]
        [Display(Name = "Table Primary Column Name")]
        public string TablePkColNm { set; get; }

        [Column("TABLE_PK_COL_VAL")]
        [Display(Name = "Table Primary Column Value")]
        public string TablePkColVal { set; get; }

        [Column("AUTH_LEVEL_MAX")]
        [Display(Name = "Maximum Auth Level")]
        public int AuthLevelMax { set; get; }

        [Column("AUTH_LEVEL_PENDING")]
        [Display(Name = " Pending Auth Level")]
        public int AuthLevelPending { set; get; }

        [Column("REMARKS")]
        [Display(Name = "Remarks")]
        public string Remarks { set; get; }

        [Column("AUTH_STATUS_ID")]
        [Display(Name = "Auth. Status Id")]
        [Required(ErrorMessage = "Auth. Status Id is required")]
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
        public string[] SelectedAuthLogIdList { set; get; }
    }
}
