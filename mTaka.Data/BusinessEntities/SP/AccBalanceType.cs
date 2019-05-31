using mTaka.Data.BusinessEntities.ACC;
using mTaka.Data.BusinessEntities.CP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.SP
{
    [Serializable]
    [Table("MTK_SP_ACC_BALANCE_TYPE")]
    public class AccBalanceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("BALANCE_TYPE_ID")]
        [Display(Name = "Balance Type Id")]
        public string BalanceTypeId { set; get; }

        [Required]
        [Column("BALANCE_TYPE_NM")]
        [Display(Name = "Balance Type Name")]
        public string BalanceTypeName { set; get; }
        
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

        [Column("TRANS_DATE")]
        [Display(Name = "Trans Date")]
        public DateTime? TransDT { set; get; }

        [NotMapped]
        public string FunctionId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}