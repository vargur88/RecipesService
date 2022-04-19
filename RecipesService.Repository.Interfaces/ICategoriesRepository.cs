using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RecipesService.Domain.Entities;

namespace RecipesService.Repository.Interfaces
{
	public interface ICategoriesRepository
	{
		Task<IList<Category>> GetCategories(CancellationToken cancellationToken);
		Task CreateCategory(Category category, CancellationToken cancellationToken);
		Task<Category> FindCategory(string categoryName, CancellationToken cancellationToken);
	}
}
