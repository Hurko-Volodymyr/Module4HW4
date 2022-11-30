using Microsoft.EntityFrameworkCore;
using Modul.Data.Entities;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<bool> AddCustomerAsync(int id, string firstName, string lastName, string adress, string city, string postalCode, string country, string phone)
        {
            var customer = new CustomerEntity()
            {
                CustomerID = id,
                FirstName = firstName,
                LastName = lastName,
                Address = adress,
                City = city,
                PostalCode = postalCode,
                Country = country,
                Phone = phone
            };

            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var entity = await _dbContext.Customers.FirstOrDefaultAsync(f => f.CustomerID == id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CustomerEntity?> GetCustomerAsync(int id)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(f => f.CustomerID == id);
        }

        public async Task<bool> UpdateAddressAsync(int id, string address)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(f => f.CustomerID == id);
            if (customer == null)
            {
                return false;
            }

            customer!.Address = address;
            _dbContext.Entry(customer).CurrentValues.SetValues(customer);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateCustomerAsync(int id, string firstName, string lastName, string adress, string city, string postalCode, string country, string phone)
        {
            var customer = await GetCustomerAsync(id);
            var result = await DeleteCustomerAsync(customer!.CustomerID);
            await AddCustomerAsync(id, firstName, lastName, adress, city, postalCode, country, phone);
            return result;
        }
    }
}