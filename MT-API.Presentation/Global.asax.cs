using MTBusinessLogic.Contract;
using MTBusinessLogic.Implementation;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;

namespace MT_API.Presentation
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
