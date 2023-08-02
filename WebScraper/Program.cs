using WebScraper.Services;
using WebScraper.Services.ScrapeMe;

try
{
    // Website - ToScrape
    //WebScrapingViaHap.GetBooksAndExportToCSV();
    //SeleniumService.GetQuotesAndExportToCSV();

    // Website - Scrapeme
    //HapService.GetPokemonProductsAndExportToCSV();
    SeleniumService.GetPokemonProductsAndExportToCSV();
}
catch (Exception exc)
{
    Logger.LogError(exc, true);
}