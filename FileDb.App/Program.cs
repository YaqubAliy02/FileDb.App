//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------

using FileDb.App.Brokers.Storages;
using FileDb.App.Models.Users;
using FileDb.App.NameAndSizeOfFilesAndFolders;
using FileDb.App.Services.Identities;
using FileDb.App.Services.UserServices;
using FileDb.App.UserProcessing;
using FileDB.App.Brokers.Storages;
using System.IO;

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
            IStorageBroker jsonstorageBroker = new JsonStorageBroker();
            IStorageBroker txtstrorageBroker = new FileStorageBroker();
            IUserService userService = null;
            IIdentityService identityService = IdentityService.GetInstance(txtstrorageBroker);

            switch (choice)
            {
                case 1:
                    userService = new UserService(txtstrorageBroker);
                    break;
                case 2:
                    userService = new UserService(jsonstorageBroker);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Existing...");
                    break;
            }

            UserProcessingService userProcessingService = new UserProcessingService(userService, identityService);
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
                            userProcessingService.DisplayUsers();
                        }
                        break;

                    case "0": break;

                    default:
                        Console.WriteLine("You entered wrong input, Try again");
                        break;
                }
            }
            while (userChoice != "0");

            Console.Clear();
            Console.WriteLine("The app has been finished");

            // Information about files and folders : Name and Size. Auther: YaqubAliy
            Console.WriteLine("Hello");
            string assetsPath = "../../../Assets";

            Folders rootFolder = new Folders(assetsPath);
            PopulateFolder(rootFolder, assetsPath);
            rootFolder.PrintInfo();


        }
        static void PopulateFolder(Folders folder, string foldersPath)
        {
            try
            {
                foreach(string filePath in Directory.GetFiles(foldersPath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    folder.Add(new Files(fileInfo.Name, fileInfo.Length));
                }

                foreach(string subFolderPath in Directory.GetDirectories(foldersPath))
                {
                    Folders subFolders = new Folders(Path.GetFileName(subFolderPath));
                    PopulateFolder(subFolders, subFolderPath);
                    folder.Add(subFolders);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine($"Error in PopulateFolder: {foldersPath}, {exception.Message}");
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1.Create User");
            Console.WriteLine("2.Display User");
            Console.WriteLine("0.Exit");
        }
        private static void PrintMenuOfStorage()
        {
            Console.WriteLine("---------Which format of file do you want to save your data?----------");
            Console.WriteLine("1.Txt storage file");
            Console.WriteLine("2.JSON storage file");
            Console.Write("Enter you choice: ");
        }
    }
}