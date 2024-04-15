namespace FileDb.App.NameAndSizeOfFilesAndFolders
{
    internal interface IFileComponent
    {
        public string Name { get;}
        public long Size { get; }
        void PrintInfo();
    }
}
