using FileDb.App.Brokers.Loggings;
using FileDb.App.Models.Users;
using FileDb.App.Services.Identities;
using FileDb.App.Services.UserServices;
using System.Runtime.CompilerServices;

namespace FileDb.App.UserProcessing
{
    internal class UserProcessingService
    {
        private readonly IUserService userService;
        private readonly IdentitiyService identityService;
        private readonly ILoggingBroker loggingBroker;

        public UserProcessingService()
        {
            this.userService = new UserService();
            this.identityService =  IdentitiyService.GetInstance();
            this.loggingBroker = new LoggingBroker();
        }

        public void CreateNewUser(string name)
        {
            User user = new User();
            user.Id = this.identityService.GetNewId();
            user.Name = name;
            this.userService.AddUser(user);
        }
        public void DisplayUsers()
        {
            this.userService.ShowUsers();
        }
        public void DeleteUser(int id)
        {
            this.userService.Delete(id);
        }
        public void UpdateUser(string name)
        {
            User user = new User();
            user.Name = name;
            this.userService.Update(user);
        }

       
    }
}
