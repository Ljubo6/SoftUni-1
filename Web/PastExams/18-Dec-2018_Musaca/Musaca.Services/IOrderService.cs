namespace Musaca.Services
{
    using Musaca.Models;
    using System.Collections.Generic;
    using System.Linq;

    public interface IOrderService
    {
        bool AddProductToCurrentActiveOrder(string userId, string productId);
        bool CreateActiveOrder(string userId);
        IEnumerable<OrderProduct> GetAllProductsInActiveOrder(string userId);
        Order GetActiveOrderByUserId(string userId);
        IQueryable<Order> GetCompletedOrdersByUserId(string userId);
        bool CompleteOrder(string orderId);
    }
}
