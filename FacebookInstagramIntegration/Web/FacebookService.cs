using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacebookInstagramIntegration.Models;
using FacebookInstagramIntegration.Web.Interfaces;

namespace FacebookInstagramIntegration.Web
{
    public class FacebookService : IFacebookService
    {
        private readonly IFacebookClient _facebookClient;
        private readonly IModelMapper _modelMapper;

        public FacebookService(
            IFacebookClient facebookClient,
            IModelMapper modelMapper)
        {
            _facebookClient = facebookClient;
            _modelMapper = modelMapper;
        }

        public async Task<FacebookAccount> GetAccountAsync(string accessToken)
        {
            var response = await _facebookClient.GetAsync<dynamic>(
                accessToken, "me", "fields=id,name,first_name,last_name");

            if (response == null)
            {
                throw new Exception("FacebookAccount not found. ");
            }

            FacebookAccount facebookAccount = _modelMapper.GetFacebookAccount(response);
            return facebookAccount;
        }

        public async Task<List<Page>> GetPagesAsync(string accessToken)
        {
            var response = await _facebookClient.GetAsync<dynamic>(accessToken, "me/accounts");

            if (response == null || response.data == null)
            {
                throw new Exception("Page not found. ");
            }

            var pages = new List<Page>();

            foreach (var pageDynamic in response.data)
            {
                Page page = _modelMapper.GetPage(pageDynamic);
                pages.Add(page);
            }

            return pages;
        }

        public async Task SetInstagramAccounts(Page page)
        {
            var response = await _facebookClient.GetAsync<dynamic>(page.AccessToken, $"{page.Id}/instagram_accounts");

            if (response == null || response.data == null)
            {
                throw new Exception("Page not found. ");
            }

            var instagramAccounts = new List<InstagramAccount>();

            foreach (var instagramAccountDynamic in response.data)
            {
                InstagramAccount instagramAccount = _modelMapper.GetInstagramAccount(instagramAccountDynamic);
                instagramAccounts.Add(instagramAccount);
            }

            page.InstagramAccounts = instagramAccounts;
        }

        public async Task PostImageToInstagram(Page page, string imageUrl, string caption)
        {
            var igAccount = page.InstagramAccounts.FirstOrDefault();

            if (igAccount == null)
            {
                throw new Exception("Instagram account is missing. ");
            }

            var objectToPost = new object();
            var argsString = $"image_url={imageUrl}&caption={caption}";

            var response = await _facebookClient.PostAsync(page.AccessToken, $"{igAccount.Id}/media", objectToPost, argsString);

            if (response == null || !response.IsSuccessStatusCode)
            {
                throw new Exception("Invalid response. ");
            }

        }
    }
}