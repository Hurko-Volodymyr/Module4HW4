using Microsoft.EntityFrameworkCore;
using Modul.Data.Entities;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ShipperRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddShipperAsync(string companyName, string phone)
        {
            var shipper = await _dbContext.Shippers.AddAsync(new ShipperEntity()
            {
                CompanyName = companyName,
                Phone = phone
            });

            await _dbContext.SaveChangesAsync();
            return shipper.Entity.ShipperID;
        }

        public async Task<bool> DeleteShipperAsync(int id)
        {
            var shipper = await _dbContext.Shippers.FirstOrDefaultAsync(f => f.ShipperID == id);
            if (shipper == null)
            {
                return false;
            }

            _dbContext.Entry(shipper).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ShipperEntity?> GetShipperAsync(int id)
        {
            return await _dbContext.Shippers.FirstOrDefaultAsync(f => f.ShipperID == id);
        }

        public async Task<bool> UpdateShipperAsync(int id, string companyName, string phone)
        {
            var shipper = await _dbContext.Shippers.FirstOrDefaultAsync(f => f.ShipperID == id);
            if (shipper == null)
            {
                return false;
            }

            shipper!.CompanyName = companyName;
            shipper!.Phone = phone;

            _dbContext.Entry(shipper).CurrentValues.SetValues(shipper);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}