using FileDb.App.Models.Users;

namespace FileDb.App.Services.UserServices
{
    internal interface IUserService
    {
        User AddUser(User user);
        List<User> ShowUsers();
    }
}
