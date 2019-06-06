using Musaca.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musaca.Services
{
    public interface IOrderService
    {
        Order GenerateOrder(long barcode, int quantity);
        Order AddOrder(Order order);
        IEnumerable<Order> GetAllActiveOrders();
    }
}
