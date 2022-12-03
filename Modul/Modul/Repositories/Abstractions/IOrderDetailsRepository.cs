using Modul.Data.Entities;

namespace Modul.Repositories.Abstractions
{
    public interface IOrderDetailsRepository
    {
        Task<int> AddOrderDetailsAsync(int orderId, int productId, string size, string color);
        Task<OrderDetailEntity?> GetOrderDetailsAsync(int id);
        Task<bool> UpdateOrderDetailsAsync(int orderDetailId, int orderId, int productId, string size, string color);
        Task<bool> DeleteOrderDetailsAsync(int id);
    }
}
