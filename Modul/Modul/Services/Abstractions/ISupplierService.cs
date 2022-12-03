using Modul.Models;

namespace Modul.Services.Abstractions
{
    public interface ISupplierService
    {
        Task<int> AddSupplierAsync(string companyName, string contactFName, string contactLName, string contactTitle, string address, string city, int customerId);
        Task<bool> UpdateSupplierAsync(int id, string companyName, string contactFName, string contactLName, string contactTitle, string address, string city, int customerId);
        Task<Supplier?> GetSupplierAsync(int id);
        Task<bool> DeleteSupplierAsync(int id);
    }
}