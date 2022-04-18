using Microsoft.AspNetCore.Mvc;
using RecipesService.Handlers.Recipes.GetRecipes;
using System.Threading.Tasks;

namespace RecipesService.Application.Controllers
{
	public class RecipesController : BaseApiController
	{
		[HttpGet]
		public async Task<IActionResult> GetRecipes([FromQuery] GetRecipesRequest request)
		{
			var response = await Mediator.Send(request);
			if (response == null)
			{
				return NoContent();
			}

			return Ok(response);
		}
	}
}
