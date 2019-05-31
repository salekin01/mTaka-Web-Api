using System.Web.Mvc;

namespace mTaka.API.Areas.LEDGER
{
    public class LEDGERAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LEDGER";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LEDGER_default",
                "LEDGER/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}