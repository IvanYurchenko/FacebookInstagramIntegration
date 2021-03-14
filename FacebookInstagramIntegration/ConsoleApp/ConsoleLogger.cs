using System;
using System.Collections.Generic;
using System.Linq;
using FacebookInstagramIntegration.ConsoleApp.Interfaces;
using FacebookInstagramIntegration.Models;

namespace FacebookInstagramIntegration.ConsoleApp
{
    public class ConsoleLogger : IConsoleLogger
    {
        public void Log(FacebookAccount account)
        {
            if (account == null)
            {
                return;
            }

            Console.WriteLine($"Facebook User: ");
            Console.WriteLine($"Account ID: {account.Id}");
            Console.WriteLine($"Full Name: {account.Name}");
            Console.WriteLine("");
        }

        public void Log(List<Page> pages)
        {
            if (pages == null || !pages.Any())
            {
                return;
            }

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

        public void Log(List<InstagramMetrics> metricsList)
        {
            if (metricsList == null || !metricsList.Any())
            {
                return;
            }

            Console.WriteLine("Metrics: ");
            var metricsNumber = 1;
            foreach (var metrics in metricsList)
            {
                Console.WriteLine($"Metric {metricsNumber}:");
                Console.WriteLine($"Media ID: {metrics.MediaId}");

                Console.WriteLine($"Impressions: {metrics.Impressions}");
                Console.WriteLine($"Engagement: {metrics.Engagement}");
                Console.WriteLine($"Reach: {metrics.Reach}");
                Console.WriteLine($"Saved: {metrics.Saved}");

                Console.WriteLine();

                metricsNumber++;
            }
        }
    }
}