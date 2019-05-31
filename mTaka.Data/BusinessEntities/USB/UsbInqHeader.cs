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
    [Table("MTK_USB_INQ_HEADER")]
    public class UsbInqHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("HEADER_ID")]
        [Display(Name = "Header Id")]
        public string HeaderId { set; get; }

        [Column("PV_ID")]
        [Display(Name = "Provider Id")]
        public string ProviderId { set; get; }

        [Column("USB_ACTION_TYPE")]
        [Display(Name = "Utility Service Bill Action Type")]
        public string UtilityServiceBillActionType { get; set; }

        [Column("USB_TYPE")]
        [Display(Name = "Utility Service Bill  Type")]
        public string UtilityServiceBillType { set; get; }

        [Column("USB_PAYMENT_MODE")]
        [Display(Name = "Utility Service Bill Payment Mode")]
        public string UtilityServiceBillPaymentMode { set; get; }

        [Column("SERVICE_USER_ID")]
        [Display(Name = "Service User Id")]
        public string ServiceUserId { get; set; }

        [Column("SERVICE_PASSWORD")]
        [Display(Name = "Service Password")]
        public string ServicePassword { set; get; }
        //
        [Column("TRANSACTION_SOURCE_NAME")]
        [Display(Name = "Transaction Source Name")]
        public string transactionSourceName { set; get; }

        [Column("TRANSACTION_SOURCE_ID")]
        [Display(Name = "Transaction Source Id")]
        public string transactionSourceId { get; set; }

        [Column("REQUEST_DATE_TIME")]
        [Display(Name = "Request Date")]
        public DateTime? requestDateTime { set; get; }


        [Column("REQUEST_ID")]
        [Display(Name = "Request Id")]
        public string RequestId { get; set; }


        [Column("SUBMIT_BY")]
        [Display(Name = "Submit By")]
        public string SubmitBy { set; get; }


        [Column("COMMENTS")]
        [Display(Name = "Comments")]
        public string Comments { get; set; }

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


        public class Header
        {
            public string utilityServiceBillActionType { get; set; }
            public string utilityServiceBillType { get; set; }
            public string utilityServiceBillPaymentMode { get; set; }
            public string serviceUserID { get; set; }
            public string servicePassword { get; set; }
            public string transactionSourceName { get; set; }
            public string transactionSourceId { get; set; }
            public string requestDateTime { get; set; }
            public string requestId { get; set; }
            public string submitBy { get; set; }
            public string comments { get; set; }

            public string responsDateTime { get; set; }
            public string responseId { get; set; }
            public int successFalg { get; set; }
            public object successMessage { get; set; }
            public string errorCode { get; set; }
            public string errorMessage { get; set; }
            public object errors { get; set; }


        }

        public class Body
        {
            public string billNumber { get; set; }
            public int paymentBillAmount { get; set; }
            public string paymentBranchId { get; set; }
            public string paymentAccountNumber { get; set; }

            public int transactionPaymentAmount { get; set; }
            public object transactionSerialNo { get; set; }
            public object billInfromationDetails { get; set; }
            public object paymentResponseId { get; set; }
            public object billMonth { get; set; }
            public object billYear { get; set; }
            public object ReconcileDetails { get; set; }
        }

        public class RootObject
        {
            public Header header { get; set; }
            public Body body { get; set; }
        }
    }
}
