namespace Panda.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Packages = new HashSet<Package>();
            this.Receipts = new HashSet<Receipt>();
        }
        public string Id { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string Username { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<Package> Packages { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
    }
}
