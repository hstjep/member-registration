using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MemberRegistration.App_Start;
using MemberRegistration.Infrastructure;

namespace MemberRegistration
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Initialize();
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
        }
    }
}
