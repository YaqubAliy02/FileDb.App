//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------

namespace FileDb.App.Brokers.Loggings
{
    internal interface ILoggingBroker
    {
        void LogInforamation(string message);
        void LogError(string userMessage);
        void LogSuccessUser(string message);
    }
}
