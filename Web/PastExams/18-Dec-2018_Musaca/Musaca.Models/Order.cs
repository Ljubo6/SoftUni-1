namespace Musaca.Models
{
    using Enums;
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public Order()
        {
            this.Products = new HashSet<OrderProduct>();
        }
        public string Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime IssuedOn { get; set; }
        public ICollection<OrderProduct> Products { get; set; }
        public string CashierId { get; set; }
        public User Cashier { get; set; }
    }
}
