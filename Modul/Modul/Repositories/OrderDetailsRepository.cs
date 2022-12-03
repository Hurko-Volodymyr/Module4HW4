using Modul.Data.Entities;
using Modul.Repositories.Abstractions;

namespace Modul.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        public Task<int> AddOrderDetailsAsync(int orderId, int productId, string size, string color)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetailEntity?> GetOrderDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderDetailsAsync(int orderId, int productId, string size, string color)
        {
            throw new NotImplementedException();
        }
    }
}
