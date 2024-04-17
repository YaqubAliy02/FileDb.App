//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
namespace FileDb.App.Services.FilesService.GetFilesSize
{
    internal interface IGetFilesSizeService
    {
        long GetFilesSize(DirectoryInfo directoryInfo);
    }
}
