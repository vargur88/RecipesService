using MediatR;
using RecipesService.Domain.Entities;
using RecipesService.Handlers.Recipes.GetRecipes;
using RecipesService.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecipesService.Handlers.GetRecipes
{
    public sealed class GetRecipesHandler : IRequestHandler<GetRecipesRequest, IReadOnlyList<Recipe>>
    {
        private readonly IRecipesRepository _recipesRepository;

        public GetRecipesHandler(IRecipesRepository recipesRepository)
        {
            _recipesRepository = recipesRepository;
        }

        public async Task<IReadOnlyList<Recipe>> Handle(GetRecipesRequest request, CancellationToken cancellationToken)
        {
            return await _recipesRepository.GetRecipes(cancellationToken);
        }
    }
}
