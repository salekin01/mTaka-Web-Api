using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.USB
{
    [Serializable]
    [Table("MTK_USB_PARAM_CONFIG")]
    public class UsbParamConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CONFIG_ID")]
        [Display(Name = "Config Id")]
        public string ConfigId { get; set; }

        [Column("PV_ID")]
        [Display(Name = "Provider Id")]
        public string PvId { get; set; }

        [Column("FIELD_NAME")]
        [Display(Name = "Field Name")]
        public string FieldName { get; set; }

        [Column("INPUT_TYPE")]
        [Display(Name = "Input Type")]
        public string InputType { get; set; }

        [Column("FIELD_TYPE")]
        [Display(Name = "Field Type")]
        public string FieldType { get; set; }

        [Column("FIELD_LENGTH")]
        [Display(Name = "Field Length")]
        public string FieldLength { get; set; }

        [Column("FIELD_PREFIX")]
        [Display(Name = "Field Prefix")]
        public string FieldPrefix { get; set; }

        [Column("FIELD_SUFFIX")]
        [Display(Name = "Field Suffix")]
        public string FieldSuffix { get; set; }

        [Column("USER_ASSIST")]
        [Display(Name = "User Assist")]
        public string UserAssist { get; set; }

        [Column("USER_ASSIST_LENGTH")]
        [Display(Name = "User Assist length")]
        public string UserAssistlength { get; set; }

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
