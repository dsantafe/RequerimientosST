using Microsoft.Owin;
using Owin;
using RequerimientosST.BL.Models;

[assembly: OwinStartup(typeof(RequerimientosST.Web.Startup))]

namespace RequerimientosST.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure the db context, user manager and role manager to use a single instance per request
            app.CreatePerOwinContext(DBContext.Create);
        }
    }
}
