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
    [Table("MTK_CP_NATIONALITY")]
    public class Nationality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("NATIONALITY_ID")]
        [Display(Name = "Nationality Id")]
        public string NationalityId { set; get; }

        [Column("NATIONALITY_NM")]
        [Display(Name = "Nationality Name")]
        public string NationalityNm { set; get; }

        #region Common
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
        #endregion
    }
}
