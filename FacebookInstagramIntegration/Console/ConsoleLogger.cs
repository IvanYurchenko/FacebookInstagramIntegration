using System.Collections.Generic;
using FacebookInstagramIntegration.Console.Interfaces;
using FacebookInstagramIntegration.Models;

namespace FacebookInstagramIntegration.Console
{
    public class ConsoleLogger : IConsoleLogger
    {
        public void Log(FacebookAccount account)
        {
            System.Console.WriteLine($"{account.Id} {account.Name}");
            System.Console.WriteLine($"");
        }

        public void Log(List<Page> pages)
        {
            System.Console.WriteLine("Pages: ");
            var pageNumber = 1;
            foreach (var page in pages)
            {
                System.Console.WriteLine($"Page {pageNumber}:");
                System.Console.WriteLine($"Name: {page.Name}");
                System.Console.WriteLine($"Id: {page.Id}");
                System.Console.WriteLine($"AccessToken: {page.AccessToken}");
                System.Console.WriteLine();

                pageNumber++;
            }
        }
}
}