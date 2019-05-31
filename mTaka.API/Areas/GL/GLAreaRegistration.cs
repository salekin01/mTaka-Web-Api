using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mTaka.API.Areas.GL
{
    public class GLAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GL";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GL_default",
                "GL/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
