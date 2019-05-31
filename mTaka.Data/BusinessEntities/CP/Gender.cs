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
    [Table("MTK_CP_GENDER")]
    public class Gender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("GENDER_ID")]
        public string GenderId { set; get; }

        [Column("GENDER_NM")]
        public string GenderNm { set; get; }

        [Column("AUTH_STATUS_ID")]
        public string AuthStatusId { set; get; }
    }
}
