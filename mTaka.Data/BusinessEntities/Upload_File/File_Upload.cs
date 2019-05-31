using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.Upload_File
{
    [Serializable]
    [Table("MTK_UPLOADED_FILE")]
    public class File_Upload
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("FILE_ID")]
        public string FileId { set; get; }

        [Column("FILE_NAME")]
        public string fileName { set; get; }

        [Column("FILE_SIZE")]
        public string fileSize { set; get; }

        [Column("FILE_TYPE")]
        public string fileType { set; get; }

        [Column("FILE_LOCATION")]
        public string filelocation { set; get; }

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
