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
            var entity = await _dbContext.Orders.FirstOrDefaultAsync(f => f.OrderID == id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();

            return true;
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
    }
}