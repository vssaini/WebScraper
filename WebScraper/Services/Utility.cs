namespace WebScraper.Services
{
    internal class Utility
    {
        public static void WriteHeaderMessage(string message)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(message);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(Environment.NewLine);
        }
    }
}
