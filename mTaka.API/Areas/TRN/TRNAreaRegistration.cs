using System.Web.Mvc;

namespace mTaka.API.Areas.TRN
{
    public class TRNAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TRN";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TRN_default",
                "TRN/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}