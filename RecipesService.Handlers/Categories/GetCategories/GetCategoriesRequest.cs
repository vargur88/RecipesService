using MediatR;
using System.Collections.Generic;

namespace RecipesService.Handlers.Categories.GetCategories
{
    public sealed class GetCategoriesRequest : IRequest<IReadOnlyList<GetCategoriesResponse>>
    {
    }
}
