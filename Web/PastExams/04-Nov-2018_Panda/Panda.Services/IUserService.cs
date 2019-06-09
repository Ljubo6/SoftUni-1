using Panda.Models;
using System;
using System.Collections.Generic;

namespace Panda.Services
{
    public interface IUserService
    {
        User AddUser(User user);
        User GetUserByUsernameAndPassword(string username, string password);
        IList<User> GetAllUsers();
        string GetUserIdByUsername(string username);
        string GetUsernameById(string id);
    }
}
