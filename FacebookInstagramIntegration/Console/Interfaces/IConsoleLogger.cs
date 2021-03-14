using System.Collections.Generic;
using FacebookInstagramIntegration.Models;

namespace FacebookInstagramIntegration.Console.Interfaces
{
    public interface IConsoleLogger
    {
        void Log(FacebookAccount account);
        void Log(List<Page> pages);
    }
}