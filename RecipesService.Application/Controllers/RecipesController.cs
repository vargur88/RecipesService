using Microsoft.AspNetCore.Mvc;
using RecipesService.Handlers.Recipes.GetRecipes;
using System.Threading.Tasks;

namespace RecipesService.Application.Controllers
{
	public class RecipesController : BaseApiController
	{
		[HttpGet]
		public async Task<IActionResult> GetRecipes(/*[FromBody]GetRecipesRequest request*/)
		{
			var response = await Mediator.Send(new GetRecipesRequest());
			if (response == null)
			{
				return NoContent();
			}

			return Ok(response);
		}
	}
}
