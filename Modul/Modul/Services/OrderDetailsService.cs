using Microsoft.Extensions.Logging;
using Modul.Models;
using Modul.Repositories;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Services
{
    public class OrderDetailsService : BaseDataService<ApplicationDbContext>, IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly ILogger<OrderDetailsService> _loggerService;

        public OrderDetailsService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IOrderDetailsRepository orderDetailRepository,
            ILogger<OrderDetailsService> loggerService)
                : base(dbContextWrapper, logger)
        {
            _orderDetailsRepository = orderDetailRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddOrderDetailsAsync(int orderId, int productId, string size, string color)
        {
            var id = await _orderDetailsRepository.AddOrderDetailsAsync(orderId, productId, size, color);
            _loggerService.LogInformation($"Created orderDetails with Id = {id}");
            return id;
        }

        public async Task<bool> DeleteOrderDetailsAsync(int id)
        {
            var result = await _orderDetailsRepository.DeleteOrderDetailsAsync(id);

            if (result == false)
            {
                _loggerService.LogWarning($"Not founded orderDetails with Id = {id}");
            }
            else
            {
                _loggerService.LogWarning($"OrderDetails with Id = {id} was deleted");
            }

            return result;
        }

        public async Task<OrderDetail?> GetOrderDetailsAsync(int id)
        {
            var result = await _orderDetailsRepository.GetOrderDetailsAsync(id);

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded orderDetails with Id = {id}");
                return null!;
            }

            return new OrderDetail
            {
                OrderDetailID = id,
                OrderID = result.OrderDetailID,
                ProductID = result.ProductID,
                Color = result!.Color,
                Size = result!.Size
            };
        }

        public async Task<bool> UpdateOrderDetailsAsync(int orderDetailId, int orderId, int productId, string size, string color)
        {
            var status = await _orderDetailsRepository.UpdateOrderDetailsAsync(orderDetailId, orderId, productId, size, color);
            _loggerService.LogInformation($"Updated orderDetails with Id = {orderDetailId}");
            return status;
        }
    }
}