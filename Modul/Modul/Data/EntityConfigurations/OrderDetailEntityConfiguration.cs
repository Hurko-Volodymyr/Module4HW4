using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul.Data.Entities;

namespace Modul.Data.EntityConfigurations
{
    public class OrderDetailEntityConfiguration : IEntityTypeConfiguration<OrderDetailEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {
            builder.HasKey(h => h.OrderDetailID);
            builder.Property(p => p.OrderID).IsRequired();
            builder.Property(p => p.ProductID).IsRequired();
            builder.Property(p => p.Size).IsRequired();
            builder.Property(p => p.Color).IsRequired();
        }
    }
}