namespace Torshia.Services
{
    using Torshia.Data;
    using Torshia.Models;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using Torshia.Models.Enums;

    public class UserService : IUserService
    {
        private readonly TorshiaDbContext torshiaContext;

        public UserService(TorshiaDbContext context)
        {
            this.torshiaContext = context;
        }
        public User AddNewUserToDb(string username, string password, string email)
        {
            UserRole role;

            if (this.torshiaContext.Users.Count() == 0)
            {
                role = UserRole.Admin;
            }
            else
            {
                role = UserRole.User;
            }

            User user = new User
            {
                Username = username,
                Password = this.HashPassword(password),
                Email = email,
                Roles = role
            };

            this.torshiaContext.Add(user);
            this.torshiaContext.SaveChanges();

            return user;    
        }

        public User GetUserByUsername(string username)
        {
            return this.torshiaContext.Users
                .SingleOrDefault(user => user.Username == username);
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.torshiaContext.Users
                .SingleOrDefault(user => user.Username == username && user.Password == this.HashPassword(password));
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
