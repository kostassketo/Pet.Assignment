using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Pet.Assignment.IoC;

namespace Pet.Assignment.WebServices
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

            PetTestDependencyResolver.Register(Assembly.GetExecutingAssembly());
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), PetTestDependencyResolver.CreateApiControllerActivator());
        }
    }
}
