using Microsoft.Extensions.Logging;
using Modul.Models;
using Modul.Repositories.Abstractions;
using Modul.Services.Abstractions;

namespace Modul.Services
{
    public class CategoryService : BaseDataService<ApplicationDbContext>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _loggerService;

        public CategoryService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICategoryRepository categoryRepository,
            ILogger<CategoryService> loggerService)
                : base(dbContextWrapper, logger)
        {
            _categoryRepository = categoryRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddCategoryAsync(string categoryName, string description, string picture, string active)
        {
            var id = await _categoryRepository.AddCategoryAsync(categoryName, description, picture, active);
            _loggerService.LogInformation($"Created category with Id = {id}");
            return id;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var result = await _categoryRepository.DeleteCategoryAsync(id);

            if (result == false)
            {
                _loggerService.LogWarning($"Not founded Category with Id = {id}");
            }
            else
            {
                _loggerService.LogWarning($"Category with Id = {id} was deleted");
            }

            return result;
        }

        public async Task<Category?> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);

            if (category == null)
            {
                _loggerService.LogWarning($"Not founded Category with Id = {id}");
                return null!;
            }

            return new Category()
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture,
                Active = category.Active
            };
        }

        public async Task<bool> UpdateCategoryAsync(int id, string categoryName, string description, string picture, string active)
        {
            var status = await _categoryRepository.UpdateCategoryAsync(id, categoryName, description, picture, active);
            _loggerService.LogInformation($"Updated category with Id = {id}");
            return status;
        }
    }
}