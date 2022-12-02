using Modul.Data.Entities;

namespace Modul.Repositories.Abstractions
{
    public interface IPaymentRepository
    {
        Task<int> CreatePaymentAsync(string paymentType, string allowed);
        Task<PaymentEntity> UpdatePaymentAsync(int id, string paymentType, string allowed);
        Task<PaymentEntity?> GetPaymentAsync(int id);
        Task<bool> DeletePaymentAsync(int id);
    }
}
