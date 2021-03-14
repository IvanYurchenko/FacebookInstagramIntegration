using System;
using System.Threading.Tasks;
using FacebookInstagramIntegration.Web;

namespace FacebookInstagramIntegration
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await DoFacebook();
        }

        public static async Task DoFacebook()
        {
            var pageId = "1350436821637222";

            var facebookClient = new FacebookClient();
            var facebookService = new FacebookService(facebookClient);
            var account = await facebookService.GetAccountAsync(FacebookSettings.AccessToken);
            Console.WriteLine($"{account.Id} {account.Name}");

            var pages = await facebookService.GetPagesAsync(FacebookSettings.AccessToken);
            Console.WriteLine("Pages: ");
            foreach (var page in pages)
            {
                Console.WriteLine($"{page.Id} | {page.Name} | {page.AccessToken}");
            }

            Console.ReadLine();
        }
    }
}
