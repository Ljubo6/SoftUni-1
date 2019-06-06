namespace Musaca.Models
{
    using Enums;

    public class User
    {
        public User()
        {

        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
