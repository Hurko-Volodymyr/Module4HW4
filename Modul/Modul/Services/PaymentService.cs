using Microsoft.Extensions.Logging;
using Modul.Models;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Services
{
    public class PaymentService : BaseDataService<ApplicationDbContext>, IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ILogger<PaymentService> _loggerService;

        public PaymentService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IPaymentRepository paymentRepository,
            ILogger<PaymentService> loggerService)
                : base(dbContextWrapper, logger)
        {
            _paymentRepository = paymentRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddPaymentAsync(string paymentType, string allowed)
        {
            var id = await _paymentRepository.AddPaymentAsync(paymentType, allowed);
            _loggerService.LogInformation($"Created payment with Id = {id}");
            return id;
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var result = await _paymentRepository.DeletePaymentAsync(id);

            if (result == false)
            {
                _loggerService.LogWarning($"Not founded Payment with Id = {id}");
            }
            else
            {
                _loggerService.LogWarning($"Payment with Id = {id} was deleted");
            }

            return result;
        }

        public async Task<Payment?> GetPaymentAsync(int id)
        {
            var category = await _paymentRepository.GetPaymentAsync(id);

            if (category == null)
            {
                _loggerService.LogWarning($"Not founded Category with Id = {id}");
                return null!;
            }

            return new Payment()
            {
                PaymentID = id,
                PaymentType = category.PaymentType,
                Allowed = category.Allowed
            };
        }

        public async Task<bool> UpdatePaymentAsync(int id, string paymentType, string allowed)
        {
            var status = await _paymentRepository.UpdatePaymentAsync(id, paymentType, allowed);
            _loggerService.LogInformation($"Updated Payment with Id = {id}");
            return status;
        }
    }
}