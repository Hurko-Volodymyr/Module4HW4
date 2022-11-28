using Modul.Models;
using Modul.Services.Abstractions;

namespace Modul.Services
{
    public class OrderService : IOrderService
    {
        public Task<bool> AddOrderAsync(int id, int orderNumber, DateTime orderTime, int customerID, int paymentID, int shipperID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderAsync(int id, int orderNumber, DateTime orderTime, int customerID, int paymentID, int shipperID)
        {
            throw new NotImplementedException();
        }
    }
}