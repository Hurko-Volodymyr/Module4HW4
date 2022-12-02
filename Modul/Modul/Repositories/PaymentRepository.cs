using Modul.Data.Entities;
using Modul.Repositories.Abstractions;

namespace Modul.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public Task<int> CreatePaymentAsync(string paymentType, string allowed)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePaymentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentEntity?> GetPaymentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentEntity> UpdatePaymentAsync(int id, string paymentType, string allowed)
        {
            throw new NotImplementedException();
        }
    }
}
