namespace cocktails.Interfaces{
    using cocktails.Models;
    using System.Collections.Generic;
    public interface IOrderService{
        List<OrderView> GetOrders();
        List<OrderView> GetOrdersByUser(string username);
    } 
}