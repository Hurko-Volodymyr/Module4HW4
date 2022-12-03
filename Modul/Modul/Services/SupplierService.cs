using Microsoft.Extensions.Logging;
using Modul.Models;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Services
{
    public class SupplierService : BaseDataService<ApplicationDbContext>, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ILogger<SupplierService> _loggerService;

        public SupplierService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ISupplierRepository supplierRepository,
        ILogger<SupplierService> loggerService)
                    : base(dbContextWrapper, logger)
        {
            _supplierRepository = supplierRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddSupplierAsync(string companyName, string contactFName, string contactLName, string contactTitle, string address, string city, int customerId)
        {
            var id = await _supplierRepository.AddSupplierAsync(companyName, contactFName, contactLName, contactTitle, address, city, customerId);
            _loggerService.LogInformation($"Created Supplier with Id = {id}");
            return id;
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var result = await _supplierRepository.DeleteSupplierAsync(id);

            if (result == false)
            {
                _loggerService.LogWarning($"Not founded Supplier with Id = {id}");
            }
            else
            {
                _loggerService.LogWarning($"Supplier with Id = {id} was deleted");
            }

            return result;
        }

        public async Task<Supplier?> GetSupplierAsync(int id)
        {
            var supplier = await _supplierRepository.GetSupplierAsync(id);

            if (supplier == null)
            {
                _loggerService.LogWarning($"Not founded Supplier with Id = {id}");
                return null!;
            }

            return new Supplier()
            {
                SupplierID = id,
                CompanyName = supplier!.CompanyName,
                ContactFName = supplier!.ContactFName,
                ContactLName = supplier!.ContactLName,
                ContactTitle = supplier!.ContactTitle,
                City = supplier!.City,
                Address = supplier!.Address,

                // CustomerID = supplier!.CustomerID
            };
        }

        public async Task<bool> UpdateSupplierAsync(int id, string companyName, string contactFName, string contactLName, string contactTitle, string address, string city, int customerId)
        {
            var status = await _supplierRepository.UpdateSupplierAsync(id, companyName, contactFName, contactLName, contactTitle, address, city, customerId);
            _loggerService.LogInformation($"Updated Supplier with Id = {id}");
            return status;
        }
    }
}
