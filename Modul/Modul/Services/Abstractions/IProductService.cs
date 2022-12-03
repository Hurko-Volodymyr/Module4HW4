using Modul.Data.Entities;
using Modul.Models;

namespace Modul.Services.Abstractions;

public interface IProductService
{
    Task<int> AddProductAsync(string name, string description, int categoryId, int supplierId);
    Task<Product?> GetProductAsync(int id);
    Task<IEnumerable<Product?>> GetProductByCategoryAsync(int categoryId);
    Task<IEnumerable<Product?>> GetProductBySupplierIdAsync(int supllierId);
    Task<bool> UpdateProductAsync(int id, string name, string description, int categoryId, int supplierId);
    Task<bool> DeleteProductAsync(int id);
    Task<bool> DeleteProductByCategoryAsync(int categoryId);
    Task<bool> DeleteProductBySupplierIdAsync(int supllierId);
}