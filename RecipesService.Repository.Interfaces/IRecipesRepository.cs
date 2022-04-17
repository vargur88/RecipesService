using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RecipesService.Domain.Entities;

namespace RecipesService.Repository.Interfaces
{
	public interface IRecipesRepository
	{
		Task<IReadOnlyList<Recipe>> GetRecipes(CancellationToken cancellationToken);
	}
}
