using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(APIs.Startup))]

namespace APIs
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
