using FileDb.App.Models.Users;
using FileDb.App.Storages;

namespace FileDb.App.Services.Identities
{
    internal class IdentitiyService
    {
        private static IdentitiyService instance;
        private static int id;
        private readonly IStorageBroker storageBroker;

        private IdentitiyService()
        {
            this.storageBroker = new FileStorageBroker();
        }

        public static IdentitiyService GetInstance()
        {
            if (instance is null)
            {
                instance = new IdentitiyService();
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
