using System;
using System.Collections.Generic;
using FacebookInstagramIntegration.ConsoleApp.Interfaces;
using FacebookInstagramIntegration.Models;

namespace FacebookInstagramIntegration.ConsoleApp
{
    public class ConsoleLogger : IConsoleLogger
    {
        public void Log(FacebookAccount account)
        {
            Console.WriteLine($"{account.Id} {account.Name}");
            Console.WriteLine("");
        }

        public void Log(List<Page> pages)
        {
            Console.WriteLine("Pages: ");
            var pageNumber = 1;
            foreach (var page in pages)
            {
                Console.WriteLine($"Page {pageNumber}:");
                Console.WriteLine($"Name: {page.Name}");
                Console.WriteLine($"Id: {page.Id}");
                Console.WriteLine($"AccessToken: {page.AccessToken}");
                Console.WriteLine("Instagram accounts: ");

                foreach (var instagramAccount in page.InstagramAccounts)
                {
                    Console.WriteLine($"{instagramAccount.Id}");
                }

                Console.WriteLine();

                pageNumber++;
            }
        }
}
}