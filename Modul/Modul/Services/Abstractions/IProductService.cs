using Modul.Models;

namespace Modul.Services.Abstractions;

public interface IProductService
{
    Task<bool> AddProductAsync(int id, string name, string description);
    Task<Product?> GetProductAsync(int id);
    Task<bool> UpdateProductAsync(int id, string name, string description);
    Task<bool> DeleteProductAsync(int id);
}