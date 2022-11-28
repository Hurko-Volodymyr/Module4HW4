using Modul.Models;

namespace Modul.Services.Abstractions
{
    public interface ICustomerService
    {
        Task<bool> AddCustomerAsync(int id, string firstName, string lastName, string adress, string city, string postalCode, string country, string phone);
        Task<Customer?> GetCustomerAsync(int id);
        Task<bool> UpdateCustomerAsync(int id, string firstName, string lastName, string adress, string city, string postalCode, string country, string phone);
        Task<bool> DeleteCustomerAsync(int id);
    }
}