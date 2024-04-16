//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------

using FileDb.App.Brokers.Loggings;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;

namespace FileDb.App.Services.FilesService.GetFilesName
{
    internal class GetFilesNameService : IGetFilesNameService
    {
        private readonly string FilePath = "../../../Assets";

        private readonly ILoggingBroker loggingBroker;
        public GetFilesNameService()
        {
            this.loggingBroker = new LoggingBroker();
        }
        public void GetFilesName()
        {
            string[] dirs = Directory.GetDirectories(FilePath, "*", SearchOption.AllDirectories);
            foreach (string dir in dirs)
            {
                this.loggingBroker.LogInformation($"{Path.GetFileName(dir)}");
            }

            var files = Directory.GetFiles(FilePath, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                this.loggingBroker.LogInformation($"{Path.GetFileName(file)}");
            }

        }
    }
}
