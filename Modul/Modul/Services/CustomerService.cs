using Microsoft.Extensions.Logging;
using Modul.Models;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;
using Module.Models;
using Module.Services.Abstractions;

namespace Modul.Services
{
    public class CustomerService : BaseDataService<ApplicationDbContext>,  ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly INotificationService _notificationService;
        private readonly ILogger<CustomerService> _loggerService;

        public CustomerService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICustomerRepository customerRepository,
            INotificationService notificationService,
            ILogger<CustomerService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _customerRepository = customerRepository;
            _notificationService = notificationService;
            _loggerService = loggerService;
        }

        public async Task<bool> AddCustomerAsync(int id, string firstName, string lastName, string adress, string city, string postalCode, string country, string phone)
        {
            return await ExecuteSafeAsync(async () =>
            {
                bool status = await _customerRepository.AddCustomerAsync(id, firstName, lastName, adress, city, postalCode, country, phone);
                _loggerService.LogInformation($"Created user with Id = {id}");
                var notifyMassage = "registration was successful";
                var notifyTo = "user@gmail.com";
                _notificationService.Notify(NotifyType.Email, notifyMassage, notifyTo);
                return status;
            });
        }

        public Task<bool> DeleteCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer?> GetCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerAsync(id);

            if (customer == null)
            {
                _loggerService.LogWarning($"Not founded user with Id = {id}");
                return null!;
            }

            return new Customer()
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                Address = customer.Address,
                Country = customer.Country
            };
        }

        public Task<bool> UpdateCustomerAsync(int id, string firstName, string lastName, string adress, string city, string postalCode, string country, string phone)
        {
            throw new NotImplementedException();
        }
    }
}