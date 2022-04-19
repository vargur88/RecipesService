using MediatR;
using System.Collections.Generic;

namespace RecipesService.Handlers.Recipes.AddRecipe
{
    public sealed class AddRecipeRequest : IRequest<AddRecipeResponse>
    {
        public string Title { get; set; }

        public string Directions { get; set; }

        public List<string> Categories { get; set; }

        public List<RecipePartRequest> RecipeParts { get; set; }
    }

    public sealed class RecipePartRequest
    {
        public string PartName { get; set; }

        public List<IngredientsRequest> Ingredients { get; set; }
    }

    public sealed class IngredientsRequest
    {
        public string IngredientContent { get; set; }

        public string Quantity { get; set; }

        public string Unit { get; set; }
    }
}
