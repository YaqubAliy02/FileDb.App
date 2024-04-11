using FileDb.App.Models.Users;

namespace FileDb.App.Brokers.Storages
{
    internal interface IStorageBroker
    {
        User AddUser(User user);
        List<User> ReadAllUsers();
        User UpdateUser(User user);
        bool DeleteUser(int id);
    }
}
