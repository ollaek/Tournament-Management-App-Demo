using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Owin;

using Owin;
using Ninject;

[assembly: OwinStartup(typeof(APIs.Startup))]

namespace APIs
{
    public class Startup
    {
        public object CreateKernel { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = new HttpConfiguration();
            webApiConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "Tournaments" });

            //app.UseNinjectMiddleware(CreateKernel);
            //app.UseNinjectWebApi(webApiConfiguration);
        }

    }
}
