using Microsoft.Extensions.Logging;
using Modul.Models;
using Modul.Repositories;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Services
{
    public class ProductService : BaseDataService<ApplicationDbContext>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _loggerService;

        public ProductService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IProductRepository productRepository,
            ILogger<ProductService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _productRepository = productRepository!;
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

        public async Task<bool> DeleteProductByCategoryAsync(int categoryId)
        {
            var result = await _productRepository.DeleteProductAsync(categoryId);

            if (result == false)
            {
                _loggerService.LogWarning($"Not founded Product with Id = {categoryId}");
            }
            else
            {
                _loggerService.LogWarning($"Product with Id = {categoryId} was deleted");
            }

            return result;
        }

        public async Task<bool> DeleteProductBySupplierIdAsync(int supllierId)
        {
            var result = await _productRepository.DeleteProductAsync(supllierId);

            if (result == false)
            {
                _loggerService.LogWarning($"Not founded Product with Id = {supllierId}");
            }
            else
            {
                _loggerService.LogWarning($"Product with Id = {supllierId} was deleted");
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

        public async Task<IEnumerable<Product?>> GetProductByCategoryAsync(int categoryId)
        {
            var result = await _productRepository.GetProductByCategoryAsync(categoryId);
            var product = new Product();
            var products = new List<Product>();

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded product with Id = {categoryId}");
                return null!;
            }

            foreach (var item in result)
            {
                product.ProductID = item!.ProductID;
                product.ProductName = item!.ProductName;
                product.ProductDescription = item.ProductDescription;
                product.CategoryID = categoryId;
                product.SupplierID = item!.SupplierID;
                products.Add(product);
            }

            return products;
        }

        public async Task<IEnumerable<Product?>> GetProductBySupplierIdAsync(int supllierId)
        {
            var result = await _productRepository.GetProductBySupplierIdAsync(supllierId);
            var product = new Product();
            var products = new List<Product>();

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded product with Id = {supllierId}");
                return null!;
            }

            foreach (var item in result)
            {
                product.ProductID = item!.ProductID;
                product.ProductName = item!.ProductName;
                product.ProductDescription = item.ProductDescription;
                product.CategoryID = item.CategoryID;
                product.SupplierID = supllierId;
                products.Add(product);
            }

            return products;
        }

        public async Task<bool> UpdateProductAsync(int id, string name, string description, int categoryId, int supplierId)
        {
            var status = await _productRepository.UpdateProductAsync(id, name, description, categoryId, supplierId);
            _loggerService.LogInformation($"Updated Product with Id = {id}");
            return status;
        }
    }
}
