using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Musaca.Data;
using Musaca.Models;

namespace Musaca.Services
{
    public class UserService : IUserService
    {
        private readonly MusacaDbContext musacaContext;
        public UserService(MusacaDbContext context)
        {
            this.musacaContext = context;
        }
        public User AddUser(User user)
        {
            user = this.musacaContext.Users.Add(user).Entity;
            this.musacaContext.SaveChanges();
            return user;    
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.musacaContext.Users
                .SingleOrDefault(user => user.Username == username && user.Password == password);
        }
    }
}
