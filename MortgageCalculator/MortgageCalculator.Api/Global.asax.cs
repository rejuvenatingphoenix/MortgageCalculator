using MortgageCalculator.Api.Config;
using MortgageCalculator.Api.Helpers;
using System.Web.Http;

namespace MortgageCalculator.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var config = GlobalConfiguration.Configuration;
            AutofacConfig.Initialize(config);
            config.Filters.Add(new APIExceptionFilter());
        }

    }
}
