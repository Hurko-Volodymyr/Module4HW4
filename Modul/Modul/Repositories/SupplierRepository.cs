using Microsoft.EntityFrameworkCore;
using Modul.Data.Entities;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SupplierRepository(
               IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddSupplierAsync(string companyName, string contactFName, string contactLName, string contactTitle, string address, string city, int customerId)
        {
            var supplier = await _dbContext.Suppliers.AddAsync(new SupplierEntity()
            {
                CompanyName = companyName,
                ContactFName = contactFName,
                ContactLName = contactLName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                CustomerID = customerId
            });

            await _dbContext.SaveChangesAsync();
            return supplier.Entity.SupplierID;
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var supplier = await _dbContext.Suppliers.FirstOrDefaultAsync(f => f.SupplierID == id);
            if (supplier == null)
            {
                return false;
            }

            _dbContext.Entry(supplier).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<SupplierEntity?> GetSupplierAsync(int id)
        {
            return await _dbContext.Suppliers.FirstOrDefaultAsync(f => f.SupplierID == id);
        }

        public async Task<bool> UpdateSupplierAsync(int id, string companyName, string contactFName, string contactLName, string contactTitle, string address, string city, int customerId)
        {
            var shipper = await _dbContext.Suppliers.FirstOrDefaultAsync(f => f.SupplierID == id);
            if (shipper == null)
            {
                return false;
            }

            shipper!.CompanyName = companyName;
            shipper.ContactFName = contactFName;
            shipper.ContactLName = contactLName;
            shipper.ContactTitle = contactTitle;
            shipper.Address = address;
            shipper.City = city;
            shipper.CustomerID = customerId;
            _dbContext.Entry(shipper).CurrentValues.SetValues(shipper);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}