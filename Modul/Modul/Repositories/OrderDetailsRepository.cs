using Microsoft.EntityFrameworkCore;
using Modul.Data.Entities;
using Modul.Models;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderDetailsRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<OrderEntity?> GetOrderAsync(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(f => f.OrderID == id);
        }

        public async Task<IEnumerable<OrderEntity>?> GetOrderByCustomerIdAsync(int id)
        {
            return await _dbContext.Orders.Include(i => i.Products).Where(w => w.CustomerID == id).ToListAsync();
        }

        public async Task<bool> UpdateOrderAsync(int id, int orderNumber, DateTime orderTime, int customerID, int paymentID, int shipperID)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(f => f.OrderID == id);
            if (order == null)
            {
                return false;
            }

            order!.OrderNumber = orderNumber;
            order!.OrderDate = orderTime;
            order!.CustomerID = customerID;
            order!.PaymentID = paymentID;
            order!.ShipperID = shipperID;

            _dbContext.Entry(order).CurrentValues.SetValues(order);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> AddOrderDetailsAsync(int orderId, int productId, string size, string color)
        {
            var orderDetails = new OrderDetailEntity()
            {
                OrderID = orderId,
                ProductID = productId,
                Size = size,
                Color = color
            };

            var result = await _dbContext.OrderDetails.AddAsync(orderDetails);
            await _dbContext.SaveChangesAsync();

            return result.Entity.OrderDetailID;
        }

        public async Task<bool> DeleteOrderDetailsAsync(int id)
        {
        var entity = await _dbContext.OrderDetails.FirstOrDefaultAsync(f => f.OrderDetailID == id);
        if (entity == null)
        {
            return false;
        }

        _dbContext.Entry(entity).State = EntityState.Deleted;
        await _dbContext.SaveChangesAsync();

        return true;
    }

        public async Task<OrderDetailEntity?> GetOrderDetailsAsync(int id)
        {
            return await _dbContext.OrderDetails.FirstOrDefaultAsync(f => f.OrderDetailID == id);
        }

        public async Task<bool> UpdateOrderDetailsAsync(int orderDetailId, int orderId, int productId, string size, string color)
        {
            var orderDetails = await _dbContext.OrderDetails.FirstOrDefaultAsync(f => f.OrderDetailID == orderDetailId);
            if (orderDetails == null)
            {
                return false;
            }

            orderDetails!.OrderDetailID = orderDetailId;
            orderDetails!.OrderID = orderId;
            orderDetails!.ProductID = productId;
            orderDetails!.Size = size;
            orderDetails!.Color = color;

            _dbContext.Entry(orderDetails).CurrentValues.SetValues(orderDetails);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
