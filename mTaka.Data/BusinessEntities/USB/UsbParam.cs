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
    [Table("MTK_USB_PARAM")]
    public class UsbParam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("PV_SL")]
        [Display(Name = "Provider SL")]
        public string PvSL { get; set; }

        [Column("PV_ID")]
        [Display(Name = "Provider Id")]
        public string PvId { get; set; }

        #region General Info
        //General Info
        [Column("PV_NAME")]
        [Display(Name = "Provider Name")]
        public string PvName { set; get; }

        [NotMapped]
        [Display(Name = "Institute Name")]
        public string InstituteName { get; set; }

        [Column("PV_SHORT_NM")]
        [Display(Name = "Provider Short Name")]
        public string PvShortName { set; get; }

        [Column("PV_ADDRESS")]
        [Display(Name = "Provider Address")]
        public string PvAddress { set; get; }

        [Column("PV_API_URL")]
        [Display(Name = "Provider API Address")]
        public string PvApiAddress { set; get; }
        #endregion

        #region Client and Billing Info
        //Client and Billing Info
        [NotMapped]
        public string FieldName { set; get; }

        [NotMapped]
        public string InputType { set; get; }

        [NotMapped]
        public string FieldType { set; get; }

        [NotMapped]
        public string FieldLength { set; get; }

        [NotMapped]
        public string FieldPrefix { set; get; }

        [NotMapped]
        public string FieldSuffix { set; get; }

        [NotMapped]
        public string UserAssist { set; get; }

        [NotMapped]
        public string UserAssistLength { set; get; }


        #endregion

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
