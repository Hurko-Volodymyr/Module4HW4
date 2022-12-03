using Modul.Data.Entities;

namespace Modul.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomerAsync(string firstName, string lastName, string adress, string city, string postalCode, string country, string phone);
        Task<CustomerEntity?> GetCustomerAsync(int id);
        Task<bool> UpdateCustomerAsync(int id, string firstName, string lastName, string adress, string city, string postalCode, string country, string phone);
        Task<bool> UpdateAddressAsync(int id, string adress);
        Task<bool> DeleteCustomerAsync(int id);
    }
}