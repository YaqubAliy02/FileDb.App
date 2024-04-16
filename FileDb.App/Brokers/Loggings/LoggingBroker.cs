//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
namespace FileDb.App.Brokers.Loggings
{
    internal class LoggingBroker : ILoggingBroker
    {
        public void LogSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void LogError(string userMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(userMessage);
            Console.ResetColor();
        }

        public void LogInformation(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
