using System.Collections.Generic;
using FacebookInstagramIntegration.Models;

namespace FacebookInstagramIntegration.ConsoleApp.Interfaces
{
    public interface IConsoleLogger
    {
        void Log(FacebookAccount account);
        void Log(List<Page> pages);
    }
}