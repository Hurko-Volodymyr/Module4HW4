using Modul.Data.Entities;

namespace Modul.Repositories.Abstractions
{
    public interface ICategoryRepository
    {
        Task<int> AddCategoryAsync(string categoryName, string description, string picture, string active);
        Task<CategoryEntity?> GetCategoryAsync(int id);
        Task<bool> UpdateCategoryAsync(int id, string categoryName, string description, string picture, string active);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
