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
    [Table("TEST")]
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        [Display(Name = "Test Id")]
        public string Id { set; get; }

        [Column("NAME")]
        [Display(Name = "Name")]
        public string Name { set; get; }
    }
}
