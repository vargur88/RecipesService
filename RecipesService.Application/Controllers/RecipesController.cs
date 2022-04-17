using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RecipesService.Application.Controllers
{
	public class RecipesController : BaseApiController
	{
		[HttpGet]
		public async Task<IActionResult> GetRecipes()
		{
			return Ok();
		}
	}
}
