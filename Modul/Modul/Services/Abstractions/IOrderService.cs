using Modul.Models;

namespace Modul.Services.Abstractions
{
    public interface IOrderService
    {
        Task<bool> AddOrderAsync(int id, int orderNumber, DateTime orderTime, int customerID, int paymentID, int shipperID);
        Task<Order?> GetOrderAsync(int id);
        Task<bool> UpdateOrderAsync(int id, int orderNumber, DateTime orderTime, int customerID, int paymentID, int shipperID);
        Task<bool> DeleteOrderAsync(int id);
    }
}