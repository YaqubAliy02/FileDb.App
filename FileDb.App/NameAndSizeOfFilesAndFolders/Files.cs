
namespace FileDb.App.NameAndSizeOfFilesAndFolders
{
    internal class Files : IFileComponent
    {
        public string Name { get;}
        public long Size { get;}

        public Files(string name, long size)
        {
          this.Name = name;
          this.Size = size;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"File: {Name}, Size: {Size} bytes");
        }
    }
}
