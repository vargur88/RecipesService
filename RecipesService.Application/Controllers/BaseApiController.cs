using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace RecipesService.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : Controller
    {
        private ISender _mediatr;

        protected ISender Mediator => _mediatr ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
