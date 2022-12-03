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

        public async Task<int> AddProductAsync(string name, string description, int categoryId, int supllierId)
        {
            var product = await _dbContext.Products.AddAsync(new ProductEntity()
            {
                ProductName = name,
                ProductDescription = description,
                CategoryID = categoryId,
                SupplierID = supllierId
            });

            await _dbContext.SaveChangesAsync();

            return product.Entity.ProductID;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var entity = await _dbContext.Products.FirstOrDefaultAsync(f => f.ProductID == id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ProductEntity?>> GetProductByCategoryAsync(string category)
        {
            return await _dbContext.Products.Where(w => w.Category!.CategoryName == category).ToListAsync();
        }

        public async Task<ProductEntity?> GetProductAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(f => f.ProductID == id);
        }

        public async Task<bool> UpdateProductAsync(int id, string name, string description, int categoryId, int supllierId)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(f => f.ProductID == id);
            if (product == null)
            {
                return false;
            }

            product!.ProductName = name;
            product!.ProductDescription = description;

            _dbContext.Entry(product).CurrentValues.SetValues(product);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
