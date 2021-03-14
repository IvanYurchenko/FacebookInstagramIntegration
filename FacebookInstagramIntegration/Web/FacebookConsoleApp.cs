using System;
using System.Threading.Tasks;

namespace FacebookInstagramIntegration.Web
{
    public class FacebookConsoleApp
    {
        public async Task DoFacebook()
        {
            var facebookClient = new FacebookClient();
            var facebookService = new FacebookService(facebookClient);
            var account = await facebookService.GetAccountAsync(FacebookSettings.AccessToken);
            Console.WriteLine($"{account.Id} {account.Name}");
            Console.WriteLine($"");

            var pages = await facebookService.GetPagesAsync(FacebookSettings.AccessToken);
            Console.WriteLine("Pages: ");
            var pageNumber = 1;
            foreach (var page in pages)
            {
                Console.WriteLine($"Page {pageNumber}:");
                Console.WriteLine($"Name: {page.Name}");
                Console.WriteLine($"Id: {page.Id}");
                Console.WriteLine($"AccessToken: {page.AccessToken}");
                Console.WriteLine();

                pageNumber++;
            }

            Console.ReadLine();
        }
    }
}