namespace Torshia.Models
{
    using Enums;
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Reports = new HashSet<Report>();
            this.Tasks = new HashSet<UserTask>();
        }
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Roles
        { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<UserTask> Tasks { get; set; }
    }
}
