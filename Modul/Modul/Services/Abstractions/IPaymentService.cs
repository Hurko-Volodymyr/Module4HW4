using Modul.Models;

namespace Modul.Services.Abstractions
{
    public interface IPaymentService
    {
        Task<int> AddPaymentAsync(string paymentType, string allowed);
        Task<bool> UpdatePaymentAsync(int id, string paymentType, string allowed);
        Task<Payment?> GetPaymentAsync(int id);
        Task<bool> DeletePaymentAsync(int id);
    }
}