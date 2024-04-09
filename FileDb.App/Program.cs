using FileDb.App.Services.Identities;
using FileDb.App.Services.UserServices;
using FileDb.App.UserProcessing;

internal class Program
{
    private static void Main(string[] args)
    {
        string userChoice;
        IUserService userService = new UserService();
        IdentitiyService identitiyService= IdentitiyService.GetInstance();

        UserProcessingService userProcessingService = new UserProcessingService(
                    userService,
                    identitiyService);

        
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
                    userProcessingService.CreateNewUser(userName);
                    break;

                case "2":
                    {
                        Console.Clear();
                        userProcessingService.DisplayUsers();
                    }
                    break;

                case "3":
                    {
                        Console.Clear();
                        Console.WriteLine("Enter an id which you want to delete");
                        Console.Write("Enter id:");
                        string deleteWithIdStr = Console.ReadLine();
                        int deleteWithId = Convert.ToInt32(deleteWithIdStr);
                        userProcessingService.DeleteUser(deleteWithId);
                    }
                    break;

                case "4":
                    {
                        Console.Clear();
                        Console.WriteLine("Enter an id which you want  to edit");
                        Console.Write("Enter an id:");
                        string idStr = Console.ReadLine();
                        int id = Convert.ToInt32(idStr);
                        Console.Write("Enter name:");
                        string name = Console.ReadLine();
                        userProcessingService.UpdateUser(name);
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

    public static void PrintMenu()
    {
        Console.WriteLine("1.Create User");
        Console.WriteLine("2.Display User");
        Console.WriteLine("3.Delete User by id");
        Console.WriteLine("4.Update User by id");
        Console.WriteLine("0.Exit");
    }
}


