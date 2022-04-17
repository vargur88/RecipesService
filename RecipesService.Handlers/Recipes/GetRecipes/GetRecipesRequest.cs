using MediatR;
using System.Collections.Generic;
using RecipesService.Domain.Entities;

namespace RecipesService.Handlers.Recipes.GetRecipes
{
    public sealed class GetRecipesRequest : IRequest<IReadOnlyList<Recipe>>
    {
    }
}
