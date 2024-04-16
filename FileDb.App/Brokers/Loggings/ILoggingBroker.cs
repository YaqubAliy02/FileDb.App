//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------

namespace FileDb.App.Brokers.Loggings
{
    internal interface ILoggingBroker
    {
        void LogInformation(string message);
        void LogError(string userMessage);
        void LogSuccess(string userMessage);
    }
}
