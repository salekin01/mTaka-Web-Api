using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.CP
{
    [Serializable]
    [Table("MTK_CP_MOBILE_OPERATOR")]
    public class MobileOperator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("MBL_OPERATOR_ID")]
        [Display(Name = "Operator ID")]
        public string OperatorId { set; get; }

        [Column("MBL_OPERATOR_NAME")]
        [Display(Name = "Operator Name")]
        public string OperatorNm { set; get; }

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
