namespace Musaca.Services
{
    using Musaca.Data;
    using Musaca.Models;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UserService : IUserService
    {
        private readonly MusacaDbContext musacaContext;
        private readonly IOrderService orderService;

        public UserService(MusacaDbContext context, IOrderService orderService)
        {
            this.musacaContext = context;
            this.orderService = orderService;
        }
        public User AddNewUserToDb(string username, string password, string email)
        {
            User user = new User
            {
                Username = username,
                Password = this.HashPassword(password),
                Email = email
            };

            this.musacaContext.Add(user);
            this.musacaContext.SaveChanges();

            this.orderService.CreateActiveOrder(user.Id);

            return user;    
        }

        public User GetUserByUsername(string username)
        {
            return this.musacaContext.Users
                .SingleOrDefault(user => user.Username == username);
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.musacaContext.Users
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
