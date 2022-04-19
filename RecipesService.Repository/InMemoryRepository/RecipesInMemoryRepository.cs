using RecipesService.Domain.Entities;
using RecipesService.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecipesService.Repository.InMemoryRepository
{
    public sealed class RecipesInMemoryRepository : IRecipesRepository
    {
        private List<Recipe> _recipes = new();

        public Task CreateRecipe(Recipe recipe, CancellationToken cancellationToken)
        {
            _recipes.Add(recipe);
            return Task.CompletedTask;
        }

        public Task<IList<Recipe>> GetRecipes(CancellationToken cancellationToken)
        {
            return Task.FromResult<IList<Recipe>>(_recipes);
        }

        public Task<Recipe> FindRecipe(string title, CancellationToken cancellationToken)
        {
            return Task.FromResult(_recipes.FirstOrDefault(t => t.Title == title));
        }
    }
}

