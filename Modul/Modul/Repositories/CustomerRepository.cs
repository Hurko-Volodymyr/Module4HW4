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

        public async Task<int> AddCustomerAsync(string firstName, string lastName, string adress, string city, string postalCode, string country, string phone)
        {
            var customer = new CustomerEntity()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = adress,
                City = city,
                PostalCode = postalCode,
                Country = country,
                Phone = phone
            };

            var result = await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return result.Entity.CustomerID;
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

        public async Task<bool> UpdateCustomerAsync(int id, string firstName, string lastName, string address, string city, string postalCode, string country, string phone)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(f => f.CustomerID == id);
            if (customer == null)
            {
                return false;
            }

            customer!.FirstName = firstName;
            customer!.LastName = lastName;
            customer!.Address = address;
            customer!.City = city;
            customer!.PostalCode = postalCode;
            customer!.Country = country;
            customer!.Phone = phone;

            _dbContext.Entry(customer).CurrentValues.SetValues(customer);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}