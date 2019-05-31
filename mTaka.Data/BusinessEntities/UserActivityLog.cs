using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities
{
    [Serializable]
    [Table("MTK_USER_ACTIVITY_LOG")]
    public class UserActivityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("SL_ID")]
        public string SlId { set; get; }

        [Column("USER_ID")]
        public string UserId { set; get; }

        [Column("WALLET_ACCOUNT_NO")]
        public string WalletAccountNo { set; get; }

        [Column("BRANCH_ID")]
        public string BranchId { set; get; }

        [Column("DATE_TIME")]
        public DateTime DateTime { set; get; }

        [Column("ACTION")]
        public string Action { set; get; }

        [Column("PARAMETERS")]
        public string Parameters { set; get; }

        [Column("IP_ADDRESS")]
        public string IpAddress { set; get; }

        [Column("TXN_DT")]
        [Display(Name = "Transection Date")]
        public DateTime TransectionDate { set; get; }

        [NotMapped]
        public DateTime FormDate { set; get; }

        [NotMapped]
        public DateTime ToDate { set; get; }

    }
}
