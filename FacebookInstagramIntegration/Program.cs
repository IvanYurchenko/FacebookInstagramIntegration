using System;
using System.Threading.Tasks;
using FacebookInstagramIntegration.Web;

namespace FacebookInstagramIntegration
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var app = new FacebookConsoleApp();
            await app.DoFacebook();
        }
    }
}
