using WebScraper.Services;
using WebScraper.Services.Wesco;

try
{
    // Website - ToScrape
    //WebScrapingViaHap.GetBooksAndExportToCSV();
    //SeleniumService.GetQuotesAndExportToCSV();

    // Website - Scrapeme
    //HapService.GetPokemonProductsAndExportToCSV();
    //SeleniumService.GetPokemonProductsAndExportToCSV();

    // Website - Wesco
    WescoService.SearchProductPrice();

    Console.WriteLine("Enter any key to close the console window.");
    Console.ReadKey();
}
catch (Exception exc)
{
    Logger.LogError(exc, true);
}