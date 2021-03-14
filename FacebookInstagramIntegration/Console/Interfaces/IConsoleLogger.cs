using System.Collections.Generic;
using FacebookInstagramIntegration.Models;

namespace FacebookInstagramIntegration.Console.Interfaces
{
    public interface IConsoleLogger
    {
        void Log(Account account);
        void Log(List<Page> pages);
    }
}