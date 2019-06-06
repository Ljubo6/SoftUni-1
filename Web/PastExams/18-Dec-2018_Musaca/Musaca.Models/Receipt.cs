namespace Musaca.Models
{
    using System;
    using System.Collections.Generic;

    public class Receipt
    {
        public Receipt()
        {
            this.Orders = new List<Order>();
        }
        public string Id { get; set; }
        public DateTime IssuedOn { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public User Cashier { get; set; }
    }
}
