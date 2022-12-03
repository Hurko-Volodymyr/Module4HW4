using Microsoft.Extensions.Logging;
using Modul.Models;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Services
{
    public class ShipperService : BaseDataService<ApplicationDbContext>, IShipperService
    {
        private readonly IShipperRepository _shipperRepository;
        private readonly ILogger<ShipperService> _loggerService;

        public ShipperService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IShipperRepository shipperRepository,
        ILogger<ShipperService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _shipperRepository = shipperRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddShipperAsync(string companyName, string phone)
        {
            var id = await _shipperRepository.AddShipperAsync(companyName, phone);
            _loggerService.LogInformation($"Created Shipper with Id = {id}");
            return id;
        }

        public async Task<bool> DeleteShipperAsync(int id)
        {
            var result = await _shipperRepository.DeleteShipperAsync(id);

            if (result == false)
            {
                _loggerService.LogWarning($"Not founded Shipper with Id = {id}");
            }
            else
            {
                _loggerService.LogWarning($"Shipper with Id = {id} was deleted");
            }

            return result;
        }

        public async Task<Shipper?> GetShipperAsync(int id)
        {
            var shipper = await _shipperRepository.GetShipperAsync(id);

            if (shipper == null)
            {
                _loggerService.LogWarning($"Not founded Shipper with Id = {id}");
                return null!;
            }

            return new Shipper()
            {
                ShipperID = id,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone,
            };
        }

        public async Task<bool> UpdateShipperAsync(int id, string companyName, string phone)
        {
            var status = await _shipperRepository.UpdateShipperAsync(id, companyName, phone);
            _loggerService.LogInformation($"Updated Shipper with Id = {id}");
            return status;
        }
    }
}