using RecipesService.Domain.Entities;
using RecipesService.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecipesService.Repository.InMemoryRepository
{
    public sealed class CategoriesInMemoryRepository : ICategoriesRepository
    {
        private List<Category> _categories = new();
        private HashSet<string> _uniqueCategoryName = new();

        public Task CreateCategory(Category category, CancellationToken cancellationToken)
        {
            if (_uniqueCategoryName.Contains(category.CategoryName) == false)
            {
                _categories.Add(category);
                _uniqueCategoryName.Add(category.CategoryName);
            }

            return Task.CompletedTask;
        }

        public Task<IList<Category>> GetCategories(CancellationToken cancellationToken)
        {
            return Task.FromResult<IList<Category>>(_categories);
        }
    }
}

