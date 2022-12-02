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

        public async Task<int> AddCustomerAsync(string firstName, string lastName, string adress, string city, string postalCode, string country, string phone)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _customerRepository.AddCustomerAsync(firstName, lastName, adress, city, postalCode, country, phone);
                _loggerService.LogInformation($"Created customer with Id = {id}");
                var notifyMassage = "registration was successful";
                var notifyTo = "user@gmail.com";
                _notificationService.Notify(NotifyType.Email, notifyMassage, notifyTo);
                return id;
            });
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var result = await _customerRepository.DeleteCustomerAsync(id);

            if (!result)
            {
                _loggerService.LogWarning($"Not founded customer with Id = {id} for delete");
                return false;
            }

            _loggerService.LogInformation($"Customer with Id = {id} was deleted");
            return true;
        }

        public async Task<Customer?> GetCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerAsync(id);

            if (customer == null)
            {
                _loggerService.LogWarning($"Not founded customer with Id = {id}");
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

        public async Task<bool> UpdateAddressAsync(int id, string address)
        {
            var result = await _customerRepository.UpdateAddressAsync(id, address);

            if (!result)
            {
                _loggerService.LogWarning($"Not founded customer with Id = {id} for update");
                return false;
            }

            _loggerService.LogInformation($"Customers address with Id = {id} was updated");
            return true;
        }

        public async Task<bool> UpdateCustomerAsync(int id, string firstName, string lastName, string adress, string city, string postalCode, string country, string phone)
        {
            var result = await _customerRepository.UpdateCustomerAsync(id, firstName, lastName, adress, city, postalCode, country, phone);

            if (!result)
            {
                _loggerService.LogWarning($"Not founded customer with Id = {id} for update");
                return false;
            }

            _loggerService.LogInformation($"Customer with Id = {id} was updated");
            return true;
        }
    }
}