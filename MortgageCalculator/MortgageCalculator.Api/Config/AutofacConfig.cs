using Autofac;
using Autofac.Integration.WebApi;
using MortgageCalculator.Api.Repository;
using MortgageCalculator.Api.Provider;
using System.Reflection;
using System.Web.Http;

namespace MortgageCalculator.Api.Config
{
    public class AutofacConfig
    {
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        private static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //registration goes here
            builder.RegisterType<MortgageProvider>().As<IMortgageProvider>().InstancePerRequest();
            builder.RegisterType<MortgageRepository>().As<IMortgageRepository>().InstancePerRequest();

            return builder.Build();
        }
    }
}
