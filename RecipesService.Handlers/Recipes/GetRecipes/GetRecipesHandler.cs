using MediatR;
using RecipesService.Handlers.Recipes.GetRecipes;
using RecipesService.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace RecipesService.Handlers.GetRecipes
{
    public sealed class GetRecipesHandler : IRequestHandler<GetRecipesRequest, IReadOnlyList<GetRecipesResponse>>
    {
        private readonly IRecipesRepository _recipesRepository;

        public GetRecipesHandler(IRecipesRepository recipesRepository)
        {
            _recipesRepository = recipesRepository;
        }

        public async Task<IReadOnlyList<GetRecipesResponse>> Handle(GetRecipesRequest request, CancellationToken cancellationToken)
        {
            var recipes = await _recipesRepository.GetRecipes(cancellationToken);
            var categories = await _recipesRepository.GetCategory(cancellationToken);

            return recipes.Select(t => new GetRecipesResponse()
            {
                UniqueId = t.UniqueId,
                Title = t.Title,
                Directions = t.Directions,
                RecipeParts = t.RecipeParts,
                Categories = categories.Where(k => t.Categories.Any(r => r == k.UniqueId)).Select(t => t.CategoryName).ToList()
            }).ToList();
        }
    }
}
