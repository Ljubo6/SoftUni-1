namespace Panda.Services
{
    using Panda.Data;
    using Panda.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly PandaDbContext context;

        public UserService(PandaDbContext context)
        {
            this.context = context;
        }
        public User AddUser(User user)
        {
            user = this.context.Users.Add(user).Entity;
            this.context.SaveChanges();
            return user;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.context.Users
                .SingleOrDefault(user => user.Username == username && user.Password == password);
        }

        public IList<User> GetAllUsers()
        {
            return this.context.Users.ToList();
        }

        public string GetUserIdByUsername(string username)
        {
            return this.context.Users.SingleOrDefault(user => user.Username == username).Id;
        }

        public string GetUsernameById(string id)
        {
            return this.context.Users.SingleOrDefault(u => u.Id == id).Username;
        }
    }
}
