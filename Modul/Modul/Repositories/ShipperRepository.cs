using Modul.Data.Entities;
using Modul.Repositories.Abstractions;

namespace Modul.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        public Task<int> CreateShipperAsync(string companyName, string phone)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteShipperAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ShipperEntity?> GetShipperAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateShipperAsync(int id, string companyName, string phone)
        {
            throw new NotImplementedException();
        }
    }
}
