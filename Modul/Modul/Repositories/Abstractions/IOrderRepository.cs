using Modul.Data.Entities;

namespace Modul.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        Task<bool> AddOrderAsync(int id, int orderNumber, DateTime orderTime, int customerID, int paymentID, int shipperID);
        Task<OrderEntity?> GetOrderAsync(int id);
        Task<bool> UpdateOrderAsync(int id, int orderNumber, DateTime orderTime, int customerID, int paymentID, int shipperID);
        Task<bool> DeleteOrderAsync(int id);
    }
}