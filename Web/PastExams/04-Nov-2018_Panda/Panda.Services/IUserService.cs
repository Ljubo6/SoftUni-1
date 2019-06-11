using Panda.Models;
using System;
using System.Collections.Generic;

namespace Panda.Services
{
    public interface IUserService
    {
        void AddUser(string username, string email, string password);
        User GetUserByUsernameAndPassword(string username, string password);
        IList<User> GetAllUsers();
        string GetUserIdByUsername(string username);
        string GetUsernameById(string id);
    }
}
