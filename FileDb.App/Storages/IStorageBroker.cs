using FileDb.App.Models.Users;
using System.Reflection.Metadata;

namespace FileDb.App.Storages
{
    internal interface IStorageBroker
    {
        User AddUser(User user);
        List<User> ReadAllUsers();
    }
}
