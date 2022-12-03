using Modul.Models;

namespace Modul.Services.Abstractions
{
    public interface IOrderDetailsService
    {
        Task<int> AddOrderDetailsAsync(int orderId, int productId, string size, string color);
        Task<OrderDetail?> GetOrderDetailsAsync(int id);
        Task<bool> UpdateOrderDetailsAsync(int orderDetailId, int orderId, int productId, string size, string color);
        Task<bool> DeleteOrderDetailsAsync(int id);
    }
}