using Microsoft.EntityFrameworkCore;
using Modul.Data.Entities;
using Modul.Data.EntityConfigurations;

namespace Modul;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CategoryEntity> Categories { get; set; } = null!;
    public DbSet<SupplierEntity> Suppliers { get; set; } = null!;
    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    public DbSet<OrderDetailEntity> OrderDetails { get; set; } = null!;
    public DbSet<OrderEntity> Orders { get; set; } = null!;
    public DbSet<PaymentEntity> Payments { get; set; } = null!;
    public DbSet<ProductEntity> Products { get; set; } = null!;
    public DbSet<ShipperEntity> Shippers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ShipperEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailEntityConfiguration());
        modelBuilder.UseHiLo();
    }
}