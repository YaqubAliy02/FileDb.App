//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using FileDb.App.Models.Users;
using FileDb.App.Brokers.Storages;

namespace FileDb.App.Services.Identities
{
    internal sealed class IdentityService : IIdentityService
    {
        private static IdentityService instance;
        private readonly IStorageBroker storageBroker;

        private IdentityService(IStorageBroker storageBroker) => 
            this.storageBroker = storageBroker; 

        public static IdentityService GetInstance(IStorageBroker storageBroker)
        {
            if (instance is null)
            {
                instance = new IdentityService(storageBroker);
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

        private static int IncrementLastUsersId(List<User> users) => 
            users[users.Count - 1].Id + 1;
    }
}
