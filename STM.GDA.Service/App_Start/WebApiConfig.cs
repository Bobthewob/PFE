using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace STM.GDA.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var matches = config.Formatters
                                .Where(f => !f.SupportedMediaTypes.Select(m => m.MediaType).Contains("text/json"))
                                .ToList();

            foreach (var match in matches)
            {
                config.Formatters.Remove(match);
            }

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
