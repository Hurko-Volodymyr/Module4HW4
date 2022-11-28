using Microsoft.EntityFrameworkCore;
using Modul.Data.Entities;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<bool> AddOrderAsync(int id, int orderNumber, DateTime orderTime, int customerID, int paymentID, int shipperID)
        {
            var order = new OrderEntity()
            {
                OrderID = id,
                OrderNumber = orderNumber,
                OrderDate = orderTime,
                CustomerID = customerID,
                PaymentID = paymentID,
                ShipperID = shipperID
            };

            var result = await _dbContext.Orders.AddAsync(order);
            var status = false;
            await _dbContext.SaveChangesAsync();
            if (result.Entity.OrderID.Equals(id))
            {
                status = true;
            }

            return status;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await GetOrderAsync(id);
            _dbContext.Orders.Remove(order!);
            await _dbContext.SaveChangesAsync();
            if (order != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<OrderEntity?> GetOrderAsync(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(f => f.OrderID == id);
        }

        public async Task<bool> UpdateOrderAsync(int id, int orderNumber, DateTime orderTime, int customerID, int paymentID, int shipperID)
        {
            var order = await GetOrderAsync(id);
            var result = await DeleteOrderAsync(order!.OrderID);
            await AddOrderAsync(id, orderNumber, orderTime, customerID, paymentID, shipperID);
            return result;
        }
    }
}