//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using FileDb.App.Models.Users;
using FileDb.App.Services.Identities;
using FileDb.App.Services.UserServices;

namespace FileDb.App.Services.UserProcessing
{
    internal sealed class UserProcessingService : IUserProcessingService
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
            user.Id = identityService.GetNewId();
            userService.AddUser(user);

            return user;
        }

        public List<User> DisplayUsers() =>
            userService.ShowUsers();
    }
}
