using System.Web.Mvc;

namespace mTaka.API.Areas.CP
{
    public class CPAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CP";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CP_default",
                "CP/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}