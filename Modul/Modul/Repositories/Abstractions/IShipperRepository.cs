using Modul.Data.Entities;

namespace Modul.Repositories.Abstractions
{
    public interface IShipperRepository
    {
        Task<int> CreateShipperAsync(string companyName, string phone);
        Task<bool> UpdateShipperAsync(int id, string companyName, string phone);
        Task<ShipperEntity?> GetShipperAsync(int id);
        Task<bool> DeleteShipperAsync(int id);
    }
}
