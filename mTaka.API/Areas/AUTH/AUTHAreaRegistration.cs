using System.Web.Mvc;

namespace mTaka.API.Areas.AUTH
{
    public class AUTHAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AUTH";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AUTH_default",
                "AUTH/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}