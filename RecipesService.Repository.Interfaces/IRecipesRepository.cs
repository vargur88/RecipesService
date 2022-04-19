using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RecipesService.Domain.Entities;

namespace RecipesService.Repository.Interfaces
{
	public interface IRecipesRepository
	{
		Task<IList<Recipe>> GetRecipes(CancellationToken cancellationToken);
		Task CreateRecipe(Recipe recipe, CancellationToken cancellationToken);
		Task<Recipe> FindRecipe(string title, CancellationToken cancellationToken);
	}
}
