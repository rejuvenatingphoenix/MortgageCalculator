using Autofac;
using Autofac.Integration.Mvc;
using MortgageCalculator.Web;
using MortgageCalculator.Web.Helpers;
using MortgageCalculator.Web.Provider;
using System.Web.Mvc;

namespace MortgageCalculator.Web
{
    public class AutofacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(RegisterServices(builder)));
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<MortageApiProvider>().As<IMortageApiProvider>().InstancePerRequest();
            builder.RegisterType<ApiClientHelper>().As<IApiClientHelper>()
       .SingleInstance();
            return builder.Build();
        

        }
    }
}