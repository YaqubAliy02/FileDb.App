//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------

using FileDb.App.Brokers.Loggings;
using FileDb.App.Models.Users;
using FileDb.App.Brokers.Storages;

namespace FileDb.App.Services.UserServices
{
    internal class UserService : IUserService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public UserService(IStorageBroker storageBroker)
        {
            this.loggingBroker = new LoggingBroker();
            this.storageBroker = storageBroker;
        }

        public User AddUser(User user)
        {
            return user is null
                ? CreateAndLogInvalidUser()
                : ValidateAndAddUser(user);
        }

        public List<User> ShowUsers()
        {
            List<User> users = new List<User>();

            try
            {
                users = this.storageBroker.ReadAllUsers();
            }
            catch(Exception exception)
            {
                this.loggingBroker.LogError(exception.Message);
                return new List<User>();
            }

            foreach (User user in users)
            {
                this.loggingBroker.LogSuccessUser($"{user.Id}, {user.Name}");
            }

            this.loggingBroker.LogInforamation("--------End of users------------");

            return users;
        }

        private User CreateAndLogInvalidUser()
        {
            this.loggingBroker.LogError("User is invalid");
            return new User();
        }

        private User ValidateAndAddUser(User user)
        {
            if (user.Id is 0 || String.IsNullOrWhiteSpace(user.Name))
            {
                this.loggingBroker.LogError("User details missing.");
                return new User();
            }
            else
            {
                this.loggingBroker.LogInforamation("User is created successfully");
                return this.storageBroker.AddUser(user);
            }
        }
    }
}
