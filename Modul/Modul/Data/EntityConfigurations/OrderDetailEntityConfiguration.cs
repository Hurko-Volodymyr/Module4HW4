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
            builder.Property(p => p.Size).IsRequired();
            builder.Property(p => p.Color).IsRequired();

            builder.HasOne(h => h.Order)
                   .WithMany(w => w.Products)
                   .HasForeignKey(h => h.OrderID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(h => h.Product)
                   .WithMany(w => w.Products)
                   .HasForeignKey(h => h.ProductID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}