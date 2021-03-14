using FacebookInstagramIntegration.Models;

namespace FacebookInstagramIntegration.Web.Interfaces
{
    public interface IModelMapper
    {
        Page GetPage(dynamic obj);
        FacebookAccount GetFacebookAccount(dynamic obj);
        InstagramAccount GetInstagramAccount(dynamic obj);
    }
}