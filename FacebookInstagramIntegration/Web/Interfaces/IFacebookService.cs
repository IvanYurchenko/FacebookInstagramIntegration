using System.Threading.Tasks;
using FacebookInstagramIntegration.Models;

namespace FacebookInstagramIntegration.Web.Interfaces
{
    public interface IFacebookService
    {
        Task<Account> GetAccountAsync(string accessToken);
    }

}