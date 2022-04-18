using RecipesService.Domain.Entities;
using RecipesService.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecipesService.Repository.InMemoryRepository
{
    public sealed class RecipesInMemoryRepository : IRecipesRepository
    {
        private List<Recipe> _recipes = new();
        private HashSet<string> _uniqueRecipeName = new();

        public Task CreateRecipe(Recipe recipe, CancellationToken cancellationToken)
        {
            if (_uniqueRecipeName.Contains(recipe.Title) == false)
            {
                _recipes.Add(recipe);
                _uniqueRecipeName.Add(recipe.Title);
            }

            return Task.CompletedTask;
        }

        public Task<IList<Recipe>> GetRecipes(CancellationToken cancellationToken)
        {
            return Task.FromResult<IList<Recipe>>(_recipes);
        }
    }
}

