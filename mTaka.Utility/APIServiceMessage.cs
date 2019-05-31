using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Utility
{
    public class APIServiceMessage
    {
    }

    public class APIServiceRequest
    {
        public string RequestId { get; set; }
        public string RequestClientIP { get; set; }
        public string RequestAppId { get; set; }
        public string RequestAppBaseUrl { get; set; }
        public string BusinessData { get; set; }
        public string FunctionId { get; set; }
        public string BranchId { get; set; }
        public string UserId { get; set; }
        public string InstituteId { get; set; }
        public string SessionId { get; set; }
        public string RequestDateTime { get; set; }
        public int SessionTimeout { get; set; }
    }

    public class APIServiceResponse
    {
        public string ResponseId { get; set; }
        public string ResponseDateTime { get; set; }
        public bool ResponseStatus { get; set; }
        public string ResponseMessage { get; set; }
        public string RequestId { get; set; }
        public string ResponseBusinessData { get; set; }
        public string FunctionId { get; set; }
        public string BranchId { get; set; }
        public string UserId { get; set; }
        public string InstituteId { get; set; }
        public string SessionId { get; set; }
        public string RequestDateTime { get; set; }
    }

    //public enum contentType
    //{
    //    [Description("application/json")]
    //    json,
    //    [Description("application/xml")]
    //    xml
    //}
}