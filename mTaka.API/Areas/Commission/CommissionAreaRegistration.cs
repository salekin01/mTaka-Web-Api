using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mTaka.API.Areas.Commission
{
    public class CommissionAreaRegistration: AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Commission";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Commission_default",
                "Commission/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}