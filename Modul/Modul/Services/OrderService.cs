using Microsoft.Extensions.Logging;
using Modul.Models;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Services
{
    public class OrderService : BaseDataService<ApplicationDbContext>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _loggerService;

        public OrderService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IOrderRepository orderRepository,
            ILogger<OrderService> loggerService)
                : base(dbContextWrapper, logger)
        {
            _orderRepository = orderRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddOrderAsync(int orderNumber, DateTime orderTime, int customerID, int paymentID, int shipperID)
        {
            var id = await _orderRepository.AddOrderAsync(orderNumber, orderTime, customerID, paymentID, shipperID);
            _loggerService.LogInformation($"Created order with Id = {id}");
            return id;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var result = await _orderRepository.DeleteOrderAsync(id);

            if (result == false)
            {
                _loggerService.LogWarning($"Not founded order with Id = {id}");
            }
            else
            {
                _loggerService.LogWarning($"Order with Id = {id} was deleted");
            }

            return result;
        }

        public async Task<Order?> GetOrderAsync(int id)
        {
            var result = await _orderRepository.GetOrderAsync(id);

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded order with Id = {id}");
                return null!;
            }

            return new Order
            {
                OrderID = result.OrderID,
                CustomerID = result.CustomerID,
                OrderNumber = result.OrderNumber,
                OrderDate = result.OrderDate
            };
        }

        public async Task<IEnumerable<Order>?> GetOrderByCustomerIdAsync(int id)
        {
            var result = await _orderRepository.GetOrderByCustomerIdAsync(id);

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded order with Id = {id}");
                return null!;
            }

            return result.Select(r => new Order()
            {
                OrderID = r.OrderID,
                Products = (List<Product>)r.Products.Select(s => new Product()
                {
                    ProductID = s.ProductID,
                })
            }).ToList();
        }

        public async Task<bool> UpdateOrderAsync(int id, int orderNumber, DateTime orderTime, int customerID, int paymentID, int shipperID)
        {
            var status = await _orderRepository.UpdateOrderAsync(id, orderNumber, orderTime, customerID, paymentID, shipperID);
            _loggerService.LogInformation($"Updated order with Id = {id}");
            return status;
        }
    }
}