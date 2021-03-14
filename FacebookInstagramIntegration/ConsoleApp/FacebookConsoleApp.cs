using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookInstagramIntegration.ConsoleApp.Interfaces;
using FacebookInstagramIntegration.Models;
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

            // Post an Image to IG
            // TODO: Doesn't work due to FB api errors
            var postedMediaIds = new List<string>();
            foreach (var page in pages)
            {
                var mediaId = await _facebookService.PostImageToInstagram(page, FacebookSettings.TestImageUrl, FacebookSettings.TestCaption);
                postedMediaIds.Add(mediaId);
            }

            // Get impressions by IG media ID
            // TODO: Doesn't work due to FB api errors
            var metricsList = new List<InstagramMetrics>();
            foreach (var mediaId in postedMediaIds)
            {
                var metrics = await _facebookService.GetInstagramMetrics(FacebookSettings.AccessToken, mediaId);
                metricsList.Add(metrics);
            }

            _consoleLogger.Log(metricsList);

            System.Console.ReadLine();
        }
    }
}