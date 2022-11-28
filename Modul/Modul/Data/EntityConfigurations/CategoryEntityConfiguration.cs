using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul.Data.Entities;

namespace Modul.Data.EntityConfigurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(h => h.CategoryID);
            builder.Property(p => p.CategoryName).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Picture).IsRequired();
            builder.Property(p => p.Active).IsRequired();
        }
    }
}