using MediatR;
using System.Collections.Generic;

namespace RecipesService.Handlers.Recipes.GetRecipes
{
    public sealed class GetRecipesRequest : IRequest<IReadOnlyList<GetRecipesResponse>>
    {
    }
}
