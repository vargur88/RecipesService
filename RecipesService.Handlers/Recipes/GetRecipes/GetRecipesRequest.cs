using MediatR;
using System;
using System.Collections.Generic;

namespace RecipesService.Handlers.Recipes.GetRecipes
{
    public sealed class GetRecipesRequest : IRequest<IReadOnlyList<GetRecipesResponse>>
    {
        public Guid? CategoryId { get; set; }

        public string SearchString { get; set; } = null;
    }
}
