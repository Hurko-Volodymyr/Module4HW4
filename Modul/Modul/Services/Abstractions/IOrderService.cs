using Modul.Models;

namespace Modul.Services.Abstractions
{
    public interface IOrderService
    {
        Task<int> AddOrderAsync(int orderNumber, DateTime orderTime, int customerID, int paymentID, int shipperID);
        Task<Order?> GetOrderAsync(int id);

        // Task<IEnumerable<Order>?> GetOrderByCustomerIdAsync(int id);
        Task<bool> UpdateOrderAsync(int id, int orderNumber, DateTime orderTime, int customerID, int paymentID, int shipperID);
        Task<bool> DeleteOrderAsync(int id);
    }
}