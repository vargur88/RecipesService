using RecipesService.Domain.Entities;
using RecipesService.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecipesService.Repository.InMemoryRepository
{
    public sealed class CategoriesInMemoryRepository : ICategoriesRepository
    {
        private List<Category> _categories = new();

        public Task CreateCategory(Category category, CancellationToken cancellationToken)
        {
            _categories.Add(category);
            return Task.CompletedTask;
        }

        public Task<IList<Category>> GetCategories(CancellationToken cancellationToken)
        {
            return Task.FromResult<IList<Category>>(_categories);
        }

        public Task<Category> FindCategory(string categoryName, CancellationToken cancellationToken)
        {
            return Task.FromResult(_categories.FirstOrDefault(t => t.CategoryName == categoryName));
        }
    }
}

