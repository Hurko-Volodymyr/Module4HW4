using Modul.Models;
using Modul.Services.Abstractions;

namespace Modul.Services
{
    public class OrderDetailsServices : IOrderDetailsService
    {
        public Task<int> AddOrderDetailsAsync(int orderId, int productId, string size, string color)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail?> GetOrderDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderDetailsAsync(int orderId, int productId, string size, string color)
        {
            throw new NotImplementedException();
        }
    }
}