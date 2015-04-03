using System.Web.Http;
using Core.DependencyInjection;

namespace Quiz.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Container.Configure();
        }
    }
}
