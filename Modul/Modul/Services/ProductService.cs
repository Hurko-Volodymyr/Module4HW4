using Microsoft.Extensions.Logging;
using Modul.Models;
using Modul.Repositories;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Services
{
    public class ProductService : BaseDataService<ApplicationDbContext>, IProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly ILogger<CustomerService> _loggerService;

        public ProductService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IProductRepository productRepository,
            ILogger<CustomerService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _productRepository = (ProductRepository?)productRepository!;
            _loggerService = loggerService!;
        }

        public async Task<int> AddProductAsync(string name, string description)
        {
            var id = await _productRepository.AddProductAsync(name, description);
            _loggerService.LogInformation($"Created product with Id = {id}");
            return id;
        }

        public Task<bool> DeleteProductAsync(int id)
        {
            return ((IProductService)_productRepository).DeleteProductAsync(id);
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            var result = await _productRepository.GetProductAsync(id);

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded product with Id = {id}");
                return null!;
            }

            return new Product()
            {
                ProductID = result.ProductID,
                ProductName = result.ProductName,
                ProductDescription = result.ProductDescription
            };
        }

        public Task<bool> UpdateProductAsync(int id, string name, string description)
        {
            return ((IProductService)_productRepository).UpdateProductAsync(id, name, description);
        }
    }
}
