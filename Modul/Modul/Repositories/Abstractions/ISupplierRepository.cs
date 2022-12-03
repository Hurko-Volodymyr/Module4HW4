using Modul.Data.Entities;

namespace Modul.Repositories.Abstractions
{
    public interface ISupplierRepository
    {
        Task<int> AddSupplierAsync(string companyName, string contactFName, string contactLName, string contactTitle, string address, string city, int customerId);
        Task<bool> UpdateSupplierAsync(int id, string companyName, string contactFName, string contactLName, string contactTitle, string address, string city, int customerId);
        Task<SupplierEntity?> GetSupplierAsync(int id);
        Task<bool> DeleteSupplierAsync(int id);
    }
}
