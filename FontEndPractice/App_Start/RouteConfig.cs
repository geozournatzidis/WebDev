using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RazorSyntaxFrontEnd
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Button",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Button", action = "Index", id = UrlParameter.Optional }
               );


            routes.MapRoute(
                name: "Table",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Table", action = "Index"}
                );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
