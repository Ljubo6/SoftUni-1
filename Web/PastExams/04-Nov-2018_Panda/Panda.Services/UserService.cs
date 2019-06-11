namespace Panda.Services
{
    using Panda.Data;
    using Panda.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UserService : IUserService
    {
        private readonly PandaDbContext context;

        public UserService(PandaDbContext context)
        {
            this.context = context;
        }
        public void AddUser(string username, string email, string password)
        {
            var user = new User()
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password)
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.context.Users
                .SingleOrDefault(user => user.Username == username && user.Password == this.HashPassword(password));
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

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
