using Modul.Data.Entities;

namespace Modul.Repositories.Abstractions
{
    public interface ISupplierRepository
    {
        Task<int> CreateSupplierAsync(string companyName, string contactFName, string contactLName, string contactTitle, string address, string city);
        Task<bool> UpdateSupplierAsync(string companyName, string contactFName, string contactLName, string contactTitle, string address, string city);
        Task<SupplierEntity?> GetSupplierAsync(int id);
        Task<bool> DeleteSupplierAsync(int id);
    }
}
