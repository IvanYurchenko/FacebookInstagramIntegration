using System.Threading.Tasks;
using FacebookInstagramIntegration.Web;
using FacebookInstagramIntegration.Web.Interfaces;

namespace FacebookInstagramIntegration.Console
{
    public class FacebookConsoleApp
    {
        public async Task DoFacebook()
        {
            var facebookClient = new FacebookClient();
            var facebookService = new FacebookService(facebookClient);
            var consoleLogger = new ConsoleLogger();;

            var account = await facebookService.GetAccountAsync(FacebookSettings.AccessToken);
            consoleLogger.Log(account);

            var pages = await facebookService.GetPagesAsync(FacebookSettings.AccessToken);
            consoleLogger.Log(pages);

            foreach (var page in pages)
            {
                await facebookService.SetInstagramAccounts(page);
            }

            System.Console.ReadLine();
        }
    }
}