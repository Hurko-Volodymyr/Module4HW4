using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul.Data.Entities;

namespace Modul.Data.EntityConfigurations
{
    internal class SupplierEntityConfiguration : IEntityTypeConfiguration<SupplierEntity>
    {
        public void Configure(EntityTypeBuilder<SupplierEntity> builder)
        {
            builder.HasKey(h => h.SupplierID);
            builder.Property(p => p.CompanyName).IsRequired();
            builder.Property(p => p.ContactFName).IsRequired();
            builder.Property(p => p.ContactLName).IsRequired();
            builder.Property(p => p.ContactTitle).IsRequired();
            builder.Property(p => p.Address).IsRequired();
            builder.Property(p => p.City).IsRequired();
        }
    }
}