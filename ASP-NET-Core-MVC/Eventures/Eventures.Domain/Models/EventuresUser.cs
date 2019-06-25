namespace Eventures.Domain.Models
{
    using Microsoft.AspNetCore.Identity;

    public class EventuresUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UCN { get; set; }
        public string Role { get; set; }
    }
}
