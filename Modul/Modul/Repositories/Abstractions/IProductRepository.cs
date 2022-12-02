using Modul.Data.Entities;

namespace Modul.Repositories.Abstractions;

public interface IProductRepository
{
    Task<int> AddProductAsync(string name, string description, int categoryId, int supplierId);
    Task<ProductEntity?> GetProductAsync(int id);
    Task<IEnumerable<ProductEntity?>> GetProductByCategoryAsync(string category);
    Task<bool> UpdateProductAsync(int id, string name, string description, int categoryId, int supplierId);
    Task<bool> DeleteProductAsync(int id);
}