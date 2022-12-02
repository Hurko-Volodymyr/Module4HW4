using Modul.Data.Entities;

namespace Modul.Repositories.Abstractions;

public interface IProductRepository
{
    Task<int> AddProductAsync(string name, string description, List<OrderDetailEntity> items);
    Task<ProductEntity?> GetProductAsync(int id);
    Task<IEnumerable<ProductEntity?>> GetProductByCategoryAsync(string category);
    Task<bool> UpdateProductAsync(int id, string name, string description);
    Task<bool> DeleteProductAsync(int id);
}