using System.Collections.Generic;

namespace FacebookInstagramIntegration.Models
{
    public class Page
    {
        public string AccessToken { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public List<InstagramAccount> InstagramAccounts { get; set; }
    }
}