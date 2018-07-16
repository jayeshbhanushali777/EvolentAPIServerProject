using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Evolent.ContactManager
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Initialize Bootstrapper
            Bootstrapper.Initialise();

            //Define Formatters
            var formatter = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatter.JsonFormatter;
            var jsonSetting = jsonFormatter.SerializerSettings;
            jsonSetting.Formatting = Formatting.Indented;

            var appXmlType = formatter.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            formatter.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            //Add CORS Handler
            //GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());
        }
    }
}
