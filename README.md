# FileDb.App

I'm looking to clarify some concepts related to my project, `FileDb.App`. Specifically, I'm interested in understanding `dependency injection` and `singleton patterns` better. Let's dive into an explanation of my code, focusing on how these topics are applied.

using FileDb.App.Models.Users;
using FileDb.App.Brokers.Storages;

namespace FileDb.App.Services.Identities
{
    internal sealed class IdentityService : IIdentityService
    {
        private static IdentityService instance;
        private readonly IStorageBroker storageBroker;

        private IdentityService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker; 
        }

        public static IdentityService GetInstance(IStorageBroker storageBroker)
        {
            if (instance is null)
            {
                instance = new IdentityService(storageBroker);
            }
            return instance;
        }

        public int GetNewId()
        {
            List<User> users = this.storageBroker.ReadAllUsers();

                return users.Count is not 0
                ? IncrementLastUsersId(users)
                : 1;
        }

        private static int IncrementLastUsersId(List<User> users)
        {
            return users[users.Count - 1].Id + 1;
        }
    }
}
This class uses something called the singleton pattern. It's like having a special rule that ensures we always use the same user ID, even if we stop and start the program again.

In the singleton pattern, a class creates an object using the 'new' keyword only once. Then, whenever we need that object again, the class doesn't create a new one. Instead, it gives us the same one it created before.

In the code I provided, there's a method called `GetInstance` that follows this rule. When we call `instance class` for the first time, it checks if it has already created an object. If not, it creates a new one. After that, whenever we call the method again, it just gives us the same object it created before.


`public static IdentityService GetInstance(IStorageBroker storageBroker)
        {
            if (instance is null)
            {
                instance = new IdentityService(storageBroker);
            }
            return instance;
        }
`

So, because of this code, we always work with the same object throughout the program. This helps keep things organized and prevents us from accidentally creating multiple user IDs.




In our project, we've implemented dependency injection to support two database formats: .txt and .json files. We opted for dependency injection to avoid being tied to just one database format.

Dependency Injection (DI) is a design pattern that has gained immense popularity in the world of software engineering. It offers a practical solution to manage dependencies between different objects, promoting loose coupling, and enhancing the testability and maintainability of your code.
Here's an example of how we've used it:

Copy example:
public UserService(IStorageBroker storageBroker)
{
    this.loggingBroker = new LoggingBroker();
    this.storageBroker = storageBroker;
}
We've created an interface named IStorageBroker and implemented two classes, JsonStorageBroker.cs and TxtStorageBroker.cs, both of which inherit from this interface. By using the interface IStorageBroker as a parameter in the constructor of the UserService class, users can choose which storage format they prefer for saving their data without needing to change the code.

This way, our code remains flexible, allowing users to easily switch between different storage formats without causing any disruptions.



