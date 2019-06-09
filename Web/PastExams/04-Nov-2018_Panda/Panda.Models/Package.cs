namespace Panda.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Package
    {
        public string Id { get; set; }
        [StringLength(20, MinimumLength = 5)]
        public string Description { get; set; }
        public double Weight { get; set; }
        public string ShippingAddress { get; set; }
        public Status Status { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        [Required]
        public string RecipientId { get; set; }
        public User Recipient { get; set; }
    }
}