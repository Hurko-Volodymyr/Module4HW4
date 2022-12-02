using Modul.Models;

namespace Modul.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<int> AddCategoryAsync(string categoryName, string description, string picture, string active);
        Task<Category?> GetCategoryAsync(int id);
        Task<bool> UpdateCategoryAsync(int id, string categoryName, string description, string picture, string active);
        Task<bool> DeleteCategoryAsync(int id);
    }
}