using NAS.Logic.Managers.Interfaces;
using NAS.Web.App_Start;
using NAS.Web.Controllers;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NAS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule registrations = new NinjectWebCommon();
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
