using FacebookInstagramIntegration.Models;
using FacebookInstagramIntegration.Web.Interfaces;

namespace FacebookInstagramIntegration.Web
{
    public class ModelMapper : IModelMapper
    {
        public Page GetPage(dynamic obj)
        {
            var page = new Page
            {
                AccessToken = obj.access_token,
                Id = obj.id,
                Name = obj.name
            };

            return page;
        }

        public FacebookAccount GetFacebookAccount(dynamic obj)
        {
            var account = new FacebookAccount
            {
                Id = obj.id,
                Name = obj.name,
                FirstName = obj.first_name,
                LastName = obj.last_name
            };

            return account;
        }

        public InstagramAccount GetInstagramAccount(dynamic obj)
        {
            var instagramAccount = new InstagramAccount
            {
                Id = obj.id
            };

            return instagramAccount;
        }

        public InstagramMetrics GetInstagramMetrics(dynamic obj, string instagramMediaId)
        {
            var instagramAccount = new InstagramMetrics
            {
                MediaId = instagramMediaId,
                Impressions = TryParseOrNull(obj.engagement),
                Engagement = TryParseOrNull(obj.engagement),
                Reach = TryParseOrNull(obj.engagement),
                Saved = TryParseOrNull(obj.engagement),
            };

            return instagramAccount;
        }

        private int? TryParseOrNull(string str)
        {
            if (int.TryParse(str, out var result))
            {
                return result;
            }

            return null;
        }
    }
}