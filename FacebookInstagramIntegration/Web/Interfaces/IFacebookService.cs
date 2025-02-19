﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookInstagramIntegration.Models;

namespace FacebookInstagramIntegration.Web.Interfaces
{
    public interface IFacebookService
    {
        Task<FacebookAccount> GetAccountAsync(string accessToken);
        Task<List<Page>> GetPagesAsync(string accessToken);
        Task SetInstagramAccounts(Page page);
        Task<string> PostImageToInstagram(Page page, string imageUrl, string caption);
        Task<InstagramMetrics> GetInstagramMetrics(string accessToken, string instagramMediaId);
    }

}