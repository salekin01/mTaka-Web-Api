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
    [Table("MTK_USB_RECEIVE")]
    public class UsbReceive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("USB_RECEIVE_ID")]
        [Display(Name = "Usb receive Id")]
        public string UsbReceiveId { get; set; }

        [Column("PV_ID")]
        [Display(Name = "Provider Id")]
        public string PvId { get; set; }

        [Column("PV_NAME")]
        [Display(Name = "Provider Name")]
        public string PvName { set; get; }

        //[NotMapped]
        //public string billNumber { get; set; }
        //[NotMapped]
        //public string paymentBillAmount { get; set; }
        //[NotMapped]
        //public string paymentBranchId { get; set; }
        //[NotMapped]
        //public string paymentAccountNumber { get; set; }

        public  class USBServiceRequest
        {
            public  USBServiceRequestHeader header { get; set; }
            public  USBServiceRequestBody body { get; set; }
        }

        public class USBServiceRequestHeader
        {
            public string utilityServiceBillActionType { get; set; }

            public string utilityServiceBillType { get; set; }

            public string utilityServiceBillPaymentMode { get; set; }

            public string serviceUserID { get; set; }

            public string servicePassword { get; set; }

            public string transactionSourceName { get; set; }

            public string transactionSourceId { get; set; }

            public DateTime? requestDateTime { get; set; }

            public string requestId { get; set; }

            public string submitBy { get; set; }

            public string comments { get; set; }

        }
        public class USBServiceRequestBody
        {
            public string billNumber { get; set; }

            public string paymentBillAmount { get; set; }

            public string paymentBranchId { get; set; }

            public string paymentAccountNumber { get; set; }

        }

        public class USBServiceResponse
        {
            public static USBServiceResponseHeader header { get; set; }
            public static USBServiceResponseBody body { get; set; }

        }
        public class USBServiceResponseHeader
        {
            public string utilityServiceBillActionType { get; set; }

            public string utilityServiceBillType { get; set; }

            public string utilityServiceBillPaymentMode { get; set; }

            public string serviceUserID { get; set; }

            public string transactionSourceName { get; set; }

            public string transactionSourceId { get; set; }

            public DateTime? requestDateTime { get; set; }

            public string requestId { get; set; }

            public DateTime? responsDateTime { get; set; }

            public string responseId { get; set; }

            public string successFalg { get; set; }

            public string successMessage { get; set; }

            public string errorCode { get; set; }

            public string errorMessage { get; set; }

            public string errors { get; set; }

            public string submitBy { get; set; }

            public string comments { get; set; }
        }

        public class USBServiceResponseBody
        {
            public string transactionPaymentAmount { get; set; }

            public string transactionSerialNo { get; set; }

            public string billInfromationDetails { get; set; }

            public string paymentResponseId { get; set; }

            public string billMonth { get; set; }

            public string billYear { get; set; }

            public string ReconcileDetails { get; set; }
        }

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
