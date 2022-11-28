using Microsoft.EntityFrameworkCore;
using Modul.Data.Entities;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<bool> AddProductAsync(int id, string name, string description)
        {
            var product = new ProductEntity()
            {
                ProductName = name,
                ProductDescription = description
            };

            var result = await _dbContext.Products.AddAsync(product);
            var status = false;
            await _dbContext.SaveChangesAsync();
            if (result.Entity.ProductID.Equals(id))
            {
                status = true;
            }

            return status;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await GetProductAsync(id);
            _dbContext.Products.Remove(product!);
            await _dbContext.SaveChangesAsync();
            if (product != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<ProductEntity?> GetProductAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(f => f.ProductID == id);
        }

        public async Task<bool> UpdateProductAsync(int id, string name, string description)
        {
            var product = await GetProductAsync(id);
            var result = await DeleteProductAsync(product!.ProductID);
            await AddProductAsync(id, name, description);
            return result;
        }
    }
}
