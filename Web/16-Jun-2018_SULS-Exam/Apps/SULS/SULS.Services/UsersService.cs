namespace SULS.Services
{
    using SULS.Data;
    using SULS.Models;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UsersService : IUsersService
    {
        private readonly SULSContext db;

        public UsersService(SULSContext db)
        {
            this.db = db;
        }

        public string CreateNewUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password),
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
            return user.Id;
        }

        //public IEnumerable<string> GetUsernames()
        //{
        //    var usernames = this.db.Users.Select(x => x.Username).ToList();
        //    return usernames;
        //}

        public User GetUserOrNull(string username, string password)
        {
            var user = this.db.Users.FirstOrDefault(
                x => x.Username == username
                && x.Password == this.HashPassword(password));
            return user;
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
