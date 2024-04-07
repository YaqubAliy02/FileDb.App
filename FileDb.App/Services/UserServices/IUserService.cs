using FileDb.App.Models.Users;

namespace FileDb.App.Services.UserServices
{
    internal interface IUserService
    {
        User AddUser(User contact);
        void ShowUsers();
        void Update(User contact);
        void Delete(int id);
    }
}
