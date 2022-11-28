using Modul.Data.Entities;

namespace Modul.Repositories.Abstractions;

public interface IProductRepository
{
    Task<bool> AddProductAsync(int id, string name, string description);
    Task<ProductEntity?> GetProductAsync(int id);
    Task<bool> UpdateProductAsync(int id, string name, string description);
    Task<bool> DeleteProductAsync(int id);
}