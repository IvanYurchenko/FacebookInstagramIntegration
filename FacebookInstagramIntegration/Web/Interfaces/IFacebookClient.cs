using System.Net.Http;
using System.Threading.Tasks;

namespace FacebookInstagramIntegration.Web.Interfaces
{
    public interface IFacebookClient
    {
        Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null);
        Task<HttpResponseMessage> PostAsync(string accessToken, string endpoint, object data, string args = null);
    }

}