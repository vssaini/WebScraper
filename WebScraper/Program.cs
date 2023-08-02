using WebScraper.Services;
using WebScraper.Services.ScrapeMe;

try
{
    //WebScrapingViaHap.GetBooksAndExportToCSV();
    //SeleniumService.GetQuotesAndExportToCSV();
    HapService.GetPokemonProductsAndExportToCSV();
}
catch (Exception exc)
{
    Logger.LogError(exc, true);
}