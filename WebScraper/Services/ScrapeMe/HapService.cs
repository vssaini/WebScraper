using CsvHelper;
using HtmlAgilityPack;
using System.Globalization;
using WebScraper.Models.ScrapeMe;

namespace WebScraper.Services.ScrapeMe
{
    internal class HapService
    {
        public static void GetPokemonProductsAndExportToCSV()
        {
            Utility.WriteHeaderMessage("Scraping Pokemon products from Scrapeme.live");

            const string siteUrl = "https://scrapeme.live/shop/";

            var pokemonProducts = GetPokemonProducts(siteUrl);
            ExportProductsToCSV(pokemonProducts);
        }

        private static IEnumerable<PokemonProduct> GetPokemonProducts(string siteUrl)
        {
            var web = new HtmlWeb();
            var document = web.Load(siteUrl);

            var pokemonProducts = new List<PokemonProduct>();

            // selecting all HTML product elements from the current page 
            var productHtmlElements = document.DocumentNode.QuerySelectorAll("li.product");

            // iterating over the list of product elements 
            foreach (var prodHtmlEle in productHtmlElements)
            {
                // scraping the interesting data from the current HTML element 
                var url = HtmlEntity.DeEntitize(prodHtmlEle.QuerySelector("a").Attributes["href"].Value);
                var image = HtmlEntity.DeEntitize(prodHtmlEle.QuerySelector("img").Attributes["src"].Value);
                var name = HtmlEntity.DeEntitize(prodHtmlEle.QuerySelector("h2").InnerText);
                var price = HtmlEntity.DeEntitize(prodHtmlEle.QuerySelector(".price").InnerText);

                // instancing a new PokemonProduct object 
                var pokemonProduct = new PokemonProduct() { Url = url, Image = image, Name = name, Price = price };

                // adding the object containing the scraped data to the list 
                pokemonProducts.Add(pokemonProduct);
            }

            return pokemonProducts;
        }

        private static void ExportProductsToCSV(IEnumerable<PokemonProduct> pokemonProducts)
        {
            using (var writer = new StreamWriter("pokemon-products.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // populating the CSV file 
                csv.WriteRecords(pokemonProducts);
            }
        }
    }
}
