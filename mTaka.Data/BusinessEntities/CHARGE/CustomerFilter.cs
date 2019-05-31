using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.Charge
{
    [Serializable]
    [Table("MTK_CHG_CUSTOMER_FILTER")]
    public class CustomerFilter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CUSTOMER_FILTER_ID")]
        [Display(Name = "Customer Filter Id")]
        public string CustomerFilterId { set; get; }

        [Column("CUSTOMER_FILTER_NM")]
        [Display(Name = "Customer Filter Name")]
        public string CustomerFilterName { set; get; }
    }
}
