using FacebookInstagramIntegration.ConsoleApp;
using FacebookInstagramIntegration.ConsoleApp.Interfaces;
using FacebookInstagramIntegration.Web;
using FacebookInstagramIntegration.Web.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FacebookInstagramIntegration
{
    public static class DependencyConfigurator
    {
        public static ServiceProvider Configure()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IFacebookClient, FacebookClient>()
                .AddScoped<IConsoleLogger, ConsoleLogger>()
                .AddScoped<IModelMapper, ModelMapper>()
                .AddScoped<IFacebookService, FacebookService>()
                .AddScoped<IFacebookConsoleApp, FacebookConsoleApp>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}