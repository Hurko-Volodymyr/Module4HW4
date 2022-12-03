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
            builder.Property(p => p.OrderDate).IsRequired();

            builder.HasOne(h => h.Customer)
                   .WithMany(w => w.Orders)
                   .HasForeignKey(h => h.CustomerID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(h => h.Payment)
                   .WithMany(w => w.Orders)
                   .HasForeignKey(h => h.PaymentID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(h => h.Shipper)
                   .WithMany(w => w.Orders)
                   .HasForeignKey(h => h.ShipperID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}