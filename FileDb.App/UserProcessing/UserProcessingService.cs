using FileDb.App.Models.Users;
using FileDb.App.Services.Identities;
using FileDb.App.Services.UserServices;

namespace FileDb.App.UserProcessing
{
    internal sealed class UserProcessingService
    {
        private readonly IUserService userService;
        private readonly IIdentityService identityService;

        public UserProcessingService(IUserService userService, IIdentityService identityService)
        {
            this.userService = userService;
            this.identityService = identityService;
        }
        public User CreateNewUser(User user)
        {
            user.Id = this.identityService.GetNewId();
            this.userService.AddUser(user);

            return user;
        }

        public void DisplayUsers() =>
            this.userService.ShowUsers();

    }
}
