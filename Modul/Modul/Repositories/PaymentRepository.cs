using Microsoft.EntityFrameworkCore;
using Modul.Data.Entities;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddPaymentAsync(string paymentType, string allowed)
        {
            var payment = await _dbContext.Payments.AddAsync(new PaymentEntity()
            {
                PaymentType = paymentType,
                Allowed = allowed
            });

            await _dbContext.SaveChangesAsync();
            return payment.Entity.PaymentID;
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var category = await _dbContext.Payments.FirstOrDefaultAsync(f => f.PaymentID == id);
            if (category == null)
            {
                return false;
            }

            _dbContext.Entry(category).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PaymentEntity?> GetPaymentAsync(int id)
        {
            return await _dbContext.Payments.FirstOrDefaultAsync(f => f.PaymentID == id);
        }

        public async Task<bool> UpdatePaymentAsync(int id, string paymentType, string allowed)
        {
            var category = await _dbContext.Payments.FirstOrDefaultAsync(f => f.PaymentID == id);
            if (category == null)
            {
                return false;
            }

            category!.PaymentType = paymentType;
            category!.Allowed = allowed;

            _dbContext.Entry(category).CurrentValues.SetValues(category);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
