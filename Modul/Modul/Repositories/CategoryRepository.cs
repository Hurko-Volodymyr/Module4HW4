using Microsoft.EntityFrameworkCore;
using Modul.Data.Entities;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddCategoryAsync(string categoryName, string description, string picture, bool active)
        {
            var category = await _dbContext.Categories.AddAsync(new CategoryEntity()
            {
                CategoryName = categoryName,
                Description = description,
                Picture = picture,
                Active = active
            });

            await _dbContext.SaveChangesAsync();
            return category.Entity.CategoryID;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(f => f.CategoryID == id);
            if (category == null)
            {
                return false;
            }

            _dbContext.Entry(category).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CategoryEntity?> GetCategoryAsync(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(f => f.CategoryID == id);
        }

        public async Task<bool> UpdateCategoryAsync(int id, string categoryName, string description, string picture, bool active)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(f => f.CategoryID == id);
            if (category == null)
            {
                return false;
            }

            category!.CategoryName = categoryName;
            category!.Description = description;
            category!.Picture = picture;
            category!.Active = active;

            _dbContext.Entry(category).CurrentValues.SetValues(category);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
