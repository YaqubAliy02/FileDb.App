namespace FileDb.App.NameAndSizeOfFilesAndFolders
{
    internal class Folders : IFileComponent
    {
        private readonly List<IFileComponent> fileComponents = new List<IFileComponent>();

        public string Name { get; }
        public long Size 
        { 
            get
            {
                long totalSize = 0;
                foreach(var component in fileComponents)
                {
                    totalSize += component.Size;
                }
                return totalSize;
            } 
        }

        public Folders(string name)
        {
            this.Name = name;
           
        }

        public void Add(IFileComponent component)
        {
            this.fileComponents.Add(component);
        }
        public void Remove(IFileComponent component)
        {
            this.fileComponents.Remove(component);
        }
        public void PrintInfo()
        {
            Console.WriteLine($"File: {Name}, Size: {Size} bytes");
            foreach(var component in fileComponents)
            {
                component.PrintInfo();
            }

        }
    }
}
