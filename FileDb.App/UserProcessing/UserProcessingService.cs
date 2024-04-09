using FileDb.App.Models.Users;
using FileDb.App.Services.Identities;
using FileDb.App.Services.UserServices;

namespace FileDb.App.UserProcessing
{
    internal class UserProcessingService
    {
        private readonly IUserService userService;
        private readonly IdentitiyService identityService;

        public UserProcessingService(IUserService userService,
                    IdentitiyService identitiyService)
        {
            this.userService = userService;
            this.identityService =  identitiyService;
        }

        public void CreateNewUser(string name)
        {
            User user = new User();
            user.Id = this.identityService.GetNewId();
            user.Name = name;
            this.userService.AddUser(user);
        }

        public void DisplayUsers() =>
            this.userService.ShowUsers();

        public void DeleteUser(int id) =>
            this.userService.Delete(id);

        public void UpdateUser(string name)
        {
            User user = new User();
            user.Name = name;
            this.userService.Update(user);
        }
    }
}
