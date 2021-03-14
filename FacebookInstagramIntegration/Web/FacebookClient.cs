using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FacebookInstagramIntegration.Web.Interfaces;
using Newtonsoft.Json;

namespace FacebookInstagramIntegration.Web
{
    public class FacebookClient : IFacebookClient
    {
        private readonly HttpClient _httpClient;

        public FacebookClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com/v9.0/")
            };
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null)
        {
            var argsString = string.Empty;
            if (args != null)
            {
                argsString = $"&{args}";
            }

            var accessTokenString = $"?access_token={accessToken}";

            var response = await _httpClient.GetAsync($"{endpoint}{accessTokenString}{argsString}");
            if (!response.IsSuccessStatusCode)
            {
                return default(T);
            }

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<HttpResponseMessage> PostAsync(string accessToken, string endpoint, object data, string args = null)
        {
            var payload = GetPayload(data);
            var result = await _httpClient.PostAsync($"{endpoint}?access_token={accessToken}&{args}", payload);
            return result;
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}