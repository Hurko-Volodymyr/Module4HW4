using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul.Data.Entities;

namespace Modul.Data.EntityConfigurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(h => h.ProductID);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.ProductDescription).IsRequired();
            builder.Property(p => p.CategoryID).IsRequired();
            builder.Property(p => p.SupplierID).IsRequired();

            builder.HasOne(h => h.Category)
                   .WithMany(w => w.Products)
                   .HasForeignKey(h => h.CategoryID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(h => h.Supplier)
                   .WithMany(w => w.Products)
                   .HasForeignKey(h => h.SupplierID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}