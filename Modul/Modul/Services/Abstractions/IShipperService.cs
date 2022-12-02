using Modul.Models;

namespace Modul.Services.Abstractions
{
    public interface IShipperService
    {
        Task<int> AddShipperAsync(string companyName, string phone);
        Task<bool> UpdateShipperAsync(int id, string companyName, string phone);
        Task<Shipper?> GetShipperAsync(int id);
        Task<bool> DeleteShipperAsync(int id);
    }
}