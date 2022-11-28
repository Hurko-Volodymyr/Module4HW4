using Modul.Data.Entities;

namespace Modul.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        Task<bool> AddCustomerAsync(int id, string firstName, string lastName, string adress, string city, string postalCode, string country, string phone);
        Task<CustomerEntity?> GetCustomerAsync(int id);
        Task<bool> UpdateCustomerAsync(int id, string firstName, string lastName, string adress, string city, string postalCode, string country, string phone);
        Task<bool> DeleteCustomerAsync(int id);
    }
}