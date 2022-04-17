using RecipesService.Domain.Entities;
using RecipesService.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecipesService.Repository.InMemoryRepository
{
    public sealed class RecipesRepositoryInMemory : IRecipesRepository
    {
        public async Task<IReadOnlyList<Recipe>> GetRecipes(CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<Recipe>());
        }
    }
}
