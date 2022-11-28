using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul.Data.Entities;

namespace Modul.Data.EntityConfigurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(h => h.OrderID);
            builder.Property(p => p.OrderNumber).IsRequired();
            builder.Property(p => p.CustomerID).IsRequired();
            builder.Property(p => p.PaymentID).IsRequired();
            builder.Property(p => p.ShipperID).IsRequired();
            builder.Property(p => p.OrderDate).IsRequired();
        }
    }
}