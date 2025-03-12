using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AnropasMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Özel route: SetFirmSession için firmID parametresi zorunlu
            routes.MapRoute(
                name: "SetFirmSession",
                url: "MemberPanel/SetFirmSession/{firmID}",
                defaults: new { controller = "MemberPanel", action = "SetFirmSession" },
                constraints: new { firmID = @"\d+" } // firmID yalnızca sayısal olabilir
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "HomePage", id = UrlParameter.Optional }
            );
        }
    }
}
