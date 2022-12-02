using Modul.Data.Entities;
using Modul.Repositories.Abstractions;

namespace Modul.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public Task<int> CreateSupplierAsync(string companyName, string contactFName, string contactLName, string contactTitle, string address, string city)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSupplierAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierEntity?> GetSupplierAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSupplierAsync(string companyName, string contactFName, string contactLName, string contactTitle, string address, string city)
        {
            throw new NotImplementedException();
        }
    }
}