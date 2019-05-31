using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mTaka.API.Areas.Charge
{
    public class ChargeAreaRegistration: AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Charge";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Charge_default",
                "Charge/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}