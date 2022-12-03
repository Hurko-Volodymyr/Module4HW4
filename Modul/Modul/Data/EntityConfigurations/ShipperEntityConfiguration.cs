using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul.Data.Entities;

namespace Modul.Data.EntityConfigurations
{
    public class ShipperEntityConfiguration : IEntityTypeConfiguration<ShipperEntity>
    {
        public void Configure(EntityTypeBuilder<ShipperEntity> builder)
        {
            builder.HasKey(h => h.ShipperID);
            builder.Property(p => p.CompanyName).IsRequired();
            builder.Property(p => p.Phone).IsRequired();
        }
    }
}