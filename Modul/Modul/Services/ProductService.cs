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

        public async Task<int> AddProductAsync(string name, string description, int categoryId, int supplierId)
        {
            var id = await _productRepository.AddProductAsync(name, description, categoryId, supplierId);
            _loggerService.LogInformation($"Created product with Id = {id}");
            return id;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var result = await _productRepository.DeleteProductAsync(id);

            if (result == false)
            {
                _loggerService.LogWarning($"Not founded Product with Id = {id}");
            }
            else
            {
                _loggerService.LogWarning($"Product with Id = {id} was deleted");
            }

            return result;
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

        public async Task<bool> UpdateProductAsync(int id, string name, string description, int categoryId, int supplierId)
        {
            var status = await _productRepository.UpdateProductAsync(id, name, description, categoryId, supplierId);
            _loggerService.LogInformation($"Updated Product with Id = {id}");
            return status;
        }
    }
}
