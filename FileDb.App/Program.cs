//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using FileDb.App.Brokers.Loggings;
using FileDb.App.Brokers.Storages;
using FileDb.App.Models.Users;
using FileDb.App.Services.FilesService.GetFilesName;
using FileDb.App.Services.FilesService.GetFilesSize;
using FileDb.App.Services.Identities;
using FileDb.App.Services.UserProcessing;
using FileDb.App.Services.UserServices;
using FileDB.App.Brokers.Storages;

namespace FileDb.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("-------------Welcome to our FileDb library---------------------");
            PrintMenuOfStorage();
            string userChoice = Console.ReadLine();
            int choice = Convert.ToInt32(userChoice);
            IStorageBroker jsonStorageBroker = new JsonStorageBroker();
            IStorageBroker fileStorageBroker = new FileStorageBroker();
            ILoggingBroker loggingBroker = new LoggingBroker();
            IUserService userService = null;
            IIdentityService identityService = null;
            switch (choice)
            {
                case 1:
                    identityService = IdentityService.GetInstance(fileStorageBroker);
                    userService = new UserService(fileStorageBroker);
                    break;
                case 2:
                    identityService = IdentityService.GetInstance(jsonStorageBroker);
                    userService = new UserService(jsonStorageBroker);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Existing...");
                    break;
            }

            IUserProcessingService userProcessingService = new UserProcessingService(userService, identityService);
            do
            {
                PrintMenu();
                Console.Write("Enter your choice:");
                userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Enter you name:");
                        string userName = Console.ReadLine();
                        User user = new User()
                        {
                            Name = userName,
                        };
                        userProcessingService.CreateNewUser(user);
                        break;

                    case "2":
                        {
                            Console.Clear();
                            userProcessingService.RetrieveUser();
                        }
                        break;
                    case "3":
                        {
                            Console.Clear();
                            string assetsPath = "../../../Assets";
                            DirectoryInfo directoryInfo = new DirectoryInfo(assetsPath);

                            IFilesSizeService getFilesSizeService = new FilesSizeService();
                            long fileSize = getFilesSizeService.GetFilesSize(directoryInfo);

                            loggingBroker.LogInformation($"Total your files size : {fileSize} bytes");
                            break;

                        }
                    case "4":
                        {
                            Console.Clear();
                            IFilesNameService getFilesNameService = new FilesNameService();
                            getFilesNameService.GetFilesName();
                            break;
                        }

                    case "0": break;

                    default:
                        loggingBroker.LogError("You entered wrong input, Try again");
                        break;
                }
            }
            while (userChoice != "0");

            Console.Clear();
            Console.WriteLine("The app has been finished");
        }
        private static void PrintMenu()
        {
            Console.WriteLine("1.Create User");
            Console.WriteLine("2.Display User");
            Console.WriteLine("3.Total size of files");
            Console.WriteLine("4.Files Name");
            Console.WriteLine("0.Exit");
        }
        private static void PrintMenuOfStorage()
        {
            Console.WriteLine("---------Which format of file do you want to save your data?---------");
            Console.WriteLine("1.Txt storage file");
            Console.WriteLine("2.JSON storage file");
            Console.Write("Enter you choice: ");
        }
    }
}