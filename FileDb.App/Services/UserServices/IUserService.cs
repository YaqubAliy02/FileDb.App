//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using FileDb.App.Models.Users;

namespace FileDb.App.Services.UserServices
{
    internal interface IUserService
    {
      
        List<User> ReadUsers();
    }
}

