using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipesService.Handlers.Recipes.AddRecipe;
using RecipesService.Handlers.Recipes.GetRecipes;
using System.Threading;
using System.Threading.Tasks;

namespace RecipesService.Application.Controllers
{
	public class RecipesController : BaseApiController
	{
		[HttpGet]
		public async Task<IActionResult> GetRecipes([FromQuery] GetRecipesRequest request, CancellationToken cancellationToken)
		{
			var response = await Mediator.Send(request, cancellationToken);
			if (response == null)
			{
				return NoContent();
			}

			return Ok(response);
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create([FromBody] AddRecipeRequest request, CancellationToken cancellationToken)
		{
			var response = await Mediator.Send(request, cancellationToken);
			if (response.HasError())
			{
				return StatusCode(StatusCodes.Status400BadRequest, response.Error);
			}

			return StatusCode(StatusCodes.Status201Created);
		}
	}
}
