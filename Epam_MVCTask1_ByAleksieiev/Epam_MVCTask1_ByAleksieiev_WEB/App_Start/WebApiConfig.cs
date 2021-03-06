﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Epam_MVCTask1_ByAleksieiev_WEB
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
);
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
