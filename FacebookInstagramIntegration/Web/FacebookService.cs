using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookInstagramIntegration.Models;
using FacebookInstagramIntegration.Web.Interfaces;

namespace FacebookInstagramIntegration.Web
{
    public class FacebookService : IFacebookService
    {
        private readonly IFacebookClient _facebookClient;

        public FacebookService(IFacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }

        public async Task<FacebookAccount> GetAccountAsync(string accessToken)
        {
            var result = await _facebookClient.GetAsync<dynamic>(
                accessToken, "me", "fields=id,name,email,first_name,last_name,age_range,birthday,gender,locale");

            if (result == null)
            {
                throw new Exception("FacebookAccount not found. ");
            }

            var account = new FacebookAccount
            {
                Id = result.id,
                Email = result.email,
                Name = result.name,
                UserName = result.username,
                FirstName = result.first_name,
                LastName = result.last_name,
                Locale = result.locale
            };

            return account;
        }

        public async Task<List<Page>> GetPagesAsync(string accessToken)
        {
            var response = await _facebookClient.GetAsync<dynamic>(accessToken, "me/accounts");

            if (response == null || response.data == null)
            {
                throw new Exception("Page Not found. ");
            }

            var list = new List<Page>();

            foreach (var page in response.data)
            {
                var pageToAdd = new Page
                {
                    AccessToken = page.access_token,
                    Id = page.id,
                    Name = page.name
                };
                
                list.Add(pageToAdd);
            }

            return list;
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
                var instagramAccount = new InstagramAccount
                {
                    Id = instagramAccountDynamic.id
                };
                instagramAccounts.Add(instagramAccount);
            }

            page.InstagramAccounts = instagramAccounts;
        }
    }
}