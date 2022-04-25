using MediatR;

namespace RecipesService.Handlers.Recipes.GetRecipes
{
    public sealed class GetRecipesRequest : IRequest<GetRecipesResponse>
    {
        public string CategoryId { get; set; } = null;

        public string SearchString { get; set; } = null;
    }
}
