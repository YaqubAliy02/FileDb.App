//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
namespace FileDb.App.Services.FilesService.GetFilesSize
{
    internal class FilesSizeService : IFilesSizeService
    {
        public long GetFilesSize(DirectoryInfo directoryInfo)
        {
            long totalSize = 0;

            FileInfo[] filesInfo = directoryInfo.GetFiles();
            foreach (FileInfo fileInfo in filesInfo)
            {
                totalSize += fileInfo.Length;
            }

            DirectoryInfo[] subfolders = directoryInfo.GetDirectories();
            foreach(DirectoryInfo dirInfo in subfolders)
            {
                totalSize += GetFilesSize(dirInfo);
            }

            return totalSize;
        }
    }
}
