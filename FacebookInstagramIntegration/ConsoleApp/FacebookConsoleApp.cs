using System.Threading.Tasks;
using FacebookInstagramIntegration.ConsoleApp.Interfaces;
using FacebookInstagramIntegration.Web;
using FacebookInstagramIntegration.Web.Interfaces;

namespace FacebookInstagramIntegration.ConsoleApp
{
    public class FacebookConsoleApp : IFacebookConsoleApp
    {
        private readonly IFacebookService _facebookService;
        private readonly IConsoleLogger _consoleLogger;

        public FacebookConsoleApp(IFacebookService facebookService,
            IConsoleLogger consoleLogger)
        {
            _facebookService = facebookService;
            _consoleLogger = consoleLogger;
        }

        public async Task DoFacebook()
        {
            // Get FB account
            var account = await _facebookService.GetAccountAsync(FacebookSettings.AccessToken);
            _consoleLogger.Log(account);

            // Get list of FB pages for that account
            var pages = await _facebookService.GetPagesAsync(FacebookSettings.AccessToken);

            // Get IG accounts associated with FB pages
            foreach (var page in pages)
            {
                await _facebookService.SetInstagramAccounts(page);
            }

            _consoleLogger.Log(pages);

            // Post an Image to IG (doesn't work due to FB api errors)
            foreach (var page in pages)
            {
                // await facebookService.PostImageToInstagram(page, FacebookSettings.TestImageUrl, FacebookSettings.TestCaption);
            }

            System.Console.ReadLine();
        }
    }
}