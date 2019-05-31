using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.Report
{
     [Serializable]
        [Table("MTK_DB_CONN_CONFIG")]
        public class DatabaseConnectionConfig 
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column("CONNECTION_ID")]

            public string ConnectionId { get; set; }
            [Required]
            [Column("CONNECTION_NM")]
            public string ConnectionNm { get; set; }
            [Required]
            [Column("CONN_DB_TYPE")]
            public int ConnDbType { get; set; }
            [Column("CONN_DB_NM")]
            public string ConnDbNm { get; set; }
            [Column("CONN_SCHEMA_NM")]
            public string ConnSchemaNm { get; set; }
            [Column("CONN_USER_ID")]
            public string ConnUserId { get; set; }
            [Column("CONN_PASS_WORD")]
            public string ConnPassWord { get; set; }
            [Column("DEFAULT_CONN_FLAG")]
            public int? DefaultConnFlag { get; set; }
            [Column("MAKE_BY")]
            public string MakeBy { get; set; }
            [Column("MAKE_DT")]
            public DateTime? MakeDt { get; set; }
        }
    
}
