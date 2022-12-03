using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Services.Abstractions;
using Module.Services;
using Modul.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Modul.Services.Abstractions;
using Modul.Services;
using Modul.Repositories.Abstractions;
using Modul.Repositories;

namespace Modul
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);
            var provider = serviceCollection.BuildServiceProvider();

            var app = provider.GetService<App>();
            await app!.Start();
        }

        private static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<LoggerOptions>().Bind(configuration.GetSection("Logger"));

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            serviceCollection.AddDbContextFactory<ApplicationDbContext>(opts
                => opts.UseNpgsql(connectionString));
            serviceCollection.AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>();

            serviceCollection
                .AddTransient<ICustomerService, CustomerService>()
                .AddLogging(configure => configure.AddConsole())
                .AddTransient<INotificationService, NotificationService>()
                .AddTransient<ICustomerRepository, CustomerRepository>()
                .AddTransient<IOrderRepository, OrderRepository>()
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<IOrderDetailsRepository, OrderDetailsRepository>()
                .AddTransient<IPaymentRepository, PaymentRepository>()
                .AddTransient<IShipperRepository, ShipperRepository>()
                .AddTransient<ISupplierRepository, SupplierRepository>()
                .AddTransient<IOrderService, OrderService>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<ICustomerService, CustomerService>()
                .AddTransient<IOrderDetailsService, OrderDetailsServices>()
                .AddTransient<IPaymentService, PaymentService>()
                .AddTransient<IShipperService, ShipperService>()
                .AddTransient<ISupplierService, SupplierService>()
                .AddTransient<App>();
        }
    }
}