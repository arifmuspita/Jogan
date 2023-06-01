using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Jogan
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "AjaxDataTableRoute",                                           // Route name
                url: "Ajax/GetDataTableList/{submodul}/get/{idx}",                            // URL with parameters
                defaults: new { controller = "Ajax", action = "GetDataTableList", submodul = "", idx = "" }  // Parameter defaults
            );
            routes.MapRoute(
                name: "AjaxRoute",                                           // Route name
                url: "Ajax/AutoComplete/{submodul}/get/{idx}",                            // URL with parameters
                defaults: new { controller = "Ajax", action = "AutoComplete", submodul = "", idx = "" }  // Parameter defaults
            );
            ///UserManagement/UserGroup/edit/2
            routes.MapRoute(
               name: "Default2",
               url: "{controller}/{action}/{method}/{id1}",
               defaults: new { controller = "Home", action = "Index", method = UrlParameter.Optional, id1 = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "Default3",
              url: "{controller}/{action}/{method}/{id1}/{id2}",
              defaults: new { controller = "Home", action = "Index", method = UrlParameter.Optional, id1 = UrlParameter.Optional, id2 = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "LoginFromDesktopApp",
              url: "{controller}/{action}/{userid}/{password}",
              defaults: new { controller = "Home", action = "LoginFromDesktopApp", userid = UrlParameter.Optional, password = UrlParameter.Optional }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
