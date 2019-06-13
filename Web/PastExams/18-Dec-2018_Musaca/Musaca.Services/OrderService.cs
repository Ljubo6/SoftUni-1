namespace Musaca.Services
{
    using Microsoft.EntityFrameworkCore;
    using Musaca.Data;
    using Musaca.Models;
    using Musaca.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderService : IOrderService
    {
        private readonly MusacaDbContext musacaContext;

        public OrderService(MusacaDbContext context)
        {
            this.musacaContext = context;
        }

        public bool AddProductToCurrentActiveOrder(string userId, string productId)
        {
            var activeOrder = this.GetActiveOrderByUserId(userId);

            activeOrder.Products.Add(new OrderProduct
            {
                ProductId = productId,
                OrderId = activeOrder.Id
            });

            this.musacaContext.Update(activeOrder);
            this.musacaContext.SaveChanges();
            return true;
        }

        public Order GetActiveOrderByUserId(string userId)
        {
            return this.musacaContext.Orders
                .Include(order => order.Products)
                .ThenInclude(orderProduct => orderProduct.Product)
                .Include(order => order.Cashier)
                .SingleOrDefault(o => o.CashierId == userId && o.Status == OrderStatus.Active);
        }

        public bool CreateActiveOrder(string userId)
        {
            var newOrder = new Order
            {
                Status = OrderStatus.Active,
                CashierId = userId
            };

            this.musacaContext.Orders.Add(newOrder);
            this.musacaContext.SaveChanges();
            return true;
        }

        public IEnumerable<OrderProduct> GetAllProductsInActiveOrder(string userId)
        {
            return this.GetActiveOrderByUserId(userId).Products;
        }

        public bool CompleteOrder(string orderId)
        {
            this.GetOrderById(orderId).Status = OrderStatus.Completed;
            this.GetOrderById(orderId).IssuedOn = DateTime.UtcNow;
            return true;
        }

        private Order GetOrderById(string orderId)
        {
            return this.musacaContext.Orders.SingleOrDefault(o => o.Id == orderId);
        }

        public IQueryable<Order> GetCompletedOrdersByUserId(string userId)
        {
            return this.musacaContext.Orders
                .Include(order => order.Products)
                .ThenInclude(orderProduct => orderProduct.Product)
                .Include(order => order.Cashier)
                .Where(o => o.CashierId == userId && o.Status == OrderStatus.Completed);
        }
    }
}
