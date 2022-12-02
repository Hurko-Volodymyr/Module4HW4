using Modul.Models;

namespace Modul.Services.Abstractions;

public interface IProductService
{
    Task<int> AddProductAsync(string name, string description, int categoryId, int supplierId);
    Task<Product?> GetProductAsync(int id);
    Task<bool> UpdateProductAsync(int id, string name, string description, int categoryId, int supplierId);
    Task<bool> DeleteProductAsync(int id);
}