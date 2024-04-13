using FileDb.App.Brokers.Storages;
using FileDb.App.Models.Users;
using FileDb.App.Services.Identities;
using FileDb.App.Services.UserServices;
using FileDb.App.UserProcessing;
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