namespace WebScraper.Services
{
    internal class Logger
    {
        public static void LogHeader(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("======================================================================================");
            Console.WriteLine(message);
            Console.WriteLine("======================================================================================");
            Console.WriteLine(Environment.NewLine);

            Console.ResetColor();
        }

        public static void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"INFO: {message}");
            Console.WriteLine(Environment.NewLine);
            Console.ResetColor();
        }

        public static void LogError(Exception exc)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {exc.Message}");
            Console.ResetColor();
        }

        public static void LogError(Exception exc, bool showStackTrace)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            if (showStackTrace)
            {
                Console.WriteLine($"ERROR: {exc}");
                return;
            }

            LogError(exc);
        }

        public static void LogSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"SUCCESS: {message}");
            Console.ResetColor();
        }
    }
}
