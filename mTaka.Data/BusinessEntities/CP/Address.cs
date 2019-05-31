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
    [Table("MTK_CP_ADDRESS")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ADDRESS_ID")]
        public string AddressId { set; get; }

        [Column("ADDRESS_NM")]
        public string AddressNm { set; get; }

        [Column("AUTH_STATUS_ID")]
        public string AuthStatusId { set; get; }
    }
}
