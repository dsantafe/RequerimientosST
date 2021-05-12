using AutoMapper;
using RequerimientosST.BL.DTOs;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RequerimientosST.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        internal static MapperConfiguration MapperConfiguration { get; private set; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //AutoMapper
            MapperConfiguration = MapperConfig.MapperConfiguration();
        }
    }
}
