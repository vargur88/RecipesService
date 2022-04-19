using Microsoft.AspNetCore.Mvc;
using RecipesService.Handlers.Categories.GetCategories;
using System.Threading;
using System.Threading.Tasks;

namespace RecipesService.Application.Controllers
{
    public class CategoriesController : BaseApiController
    {
		[HttpGet]
		public async Task<IActionResult> GetRecipes([FromQuery] GetCategoriesRequest request, CancellationToken cancellationToken)
		{
			var response = await Mediator.Send(request, cancellationToken);
			if (response == null)
			{
				return NoContent();
			}

			return Ok(response);
		}
	}
}
