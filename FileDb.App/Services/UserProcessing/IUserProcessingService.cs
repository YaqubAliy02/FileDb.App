//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using FileDb.App.Models.Users;

namespace FileDb.App.Services.UserProcessing
{
    internal interface IUserProcessingService
    {
        User CreateNewUser(User user);
        List<User> RetrieveUser();
    }
}
