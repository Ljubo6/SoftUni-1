using System;
using System.ComponentModel.DataAnnotations;

namespace Panda.Models
{
    public class Receipt
    {
        public string Id { get; set; }
        public decimal Fee { get; set; }
        public DateTime IssuedOn { get; set; }
        public string RecipientId { get; set; }
        public User Recipient { get; set; }
        [Required]
        public string PackageId { get; set; }
        public Package Package { get; set; }
    }
}