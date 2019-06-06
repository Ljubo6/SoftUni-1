using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Musaca.Data;
using Musaca.Models;
using Musaca.Models.Enums;

namespace Musaca.Services
{
    public class OrderService : IOrderService
    {
        private readonly MusacaDbContext musacaContext;

        public OrderService(MusacaDbContext context)
        {
            this.musacaContext = context;
        }

        public Order AddOrder(Order order)
        {
            order = this.musacaContext.Orders.Add(order).Entity;
            this.musacaContext.SaveChanges();
            return order;
        }

        public Order GenerateOrder(long barcode, int quantity)
        {
            var orderedProduct = this.musacaContext.Products
                .SingleOrDefault(product => product.Barcode == barcode);

            var order = new Order()
            {
                Product = orderedProduct,
                Quantity = quantity,
                Status = OrderStatus.Active
            };

            return order;
        }
        public IEnumerable<Order> GetAllActiveOrders()
        {
            return this.musacaContext.Orders
                .Where(order => order.Status == OrderStatus.Active)
                .Select(order => new Order
                {
                    Product = order.Product,
                    Quantity = order.Quantity
                })
                .ToList();
        }
    }
}
