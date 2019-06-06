namespace Musaca.Models
{
    using Enums;

    public class Order
    {
        public string Id { get; set; }
        public OrderStatus Status { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public User Cashier { get; set; }
    }
}
