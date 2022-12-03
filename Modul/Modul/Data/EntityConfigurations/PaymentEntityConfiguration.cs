using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul.Data.Entities;

namespace Modul.Data.EntityConfigurations
{
    public class PaymentEntityConfiguration : IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder.HasKey(h => h.PaymentID);
            builder.Property(p => p.PaymentType).IsRequired();
            builder.Property(p => p.Allowed).IsRequired();
        }
    }
}