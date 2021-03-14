using System.Threading.Tasks;
using FacebookInstagramIntegration.ConsoleApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FacebookInstagramIntegration
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = DependencyConfigurator.Configure();
            var app = serviceProvider.GetService<IFacebookConsoleApp>();
            await app.DoFacebook();
        }
    }
}
