//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------

using FileDb.App.Brokers.Loggings;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;

namespace FileDb.App.Services.FilesService.GetFilesName
{
    internal class FilesNameService : IFilesNameService
    {
        private readonly string filePath = "../../../Assets";

        private readonly ILoggingBroker loggingBroker;
        public FilesNameService()
        {
            this.loggingBroker = new LoggingBroker();
        }
        public void GetFilesName()
        {
            string[] directories = Directory.GetDirectories(filePath, "*", SearchOption.AllDirectories);
            foreach (string directory in directories)
            {
                this.loggingBroker.LogInformation($"{Path.GetFileName(directory)}");
            }

            var files = Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                this.loggingBroker.LogInformation($"{Path.GetFileName(file)}");
            }

        }
    }
}
