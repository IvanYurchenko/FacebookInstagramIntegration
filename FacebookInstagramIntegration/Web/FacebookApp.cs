using System;
using System.Threading.Tasks;

namespace FacebookInstagramIntegration.Web
{
    public class FacebookApp
    {
        public async Task DoFacebook()
        {
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