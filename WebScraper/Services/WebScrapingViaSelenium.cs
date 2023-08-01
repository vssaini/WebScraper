using CsvHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Globalization;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebScraper.Models;

namespace WebScraper.Services
{
    internal class WebScrapingViaSelenium
    {
        public static void GetQuotesAndExportToCSV()
        {
            // setting up the driver
            new DriverManager().SetUpDriver(new ChromeConfig());

            var driver = new ChromeDriver();
            // load the webpage
            driver.Navigate().GoToUrl("http://quotes.toscrape.com/js/");

            var quotes = new List<Quote>();
            var quoteContainers = driver.FindElements(By.CssSelector("div.quote"));
            foreach (var item in quoteContainers)
            {
                Quote quote = new()
                {
                    Text = item.FindElement(By.CssSelector("span.text")).Text,
                    Author = item.FindElement(By.CssSelector(".author")).Text
                };
                quotes.Add(quote);
                Console.WriteLine(quote.ToString());
            }


            using (var writer = new StreamWriter("./quotes.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(quotes);
            }

            // closing the browser 
            driver.Quit();
        }
    }
}
