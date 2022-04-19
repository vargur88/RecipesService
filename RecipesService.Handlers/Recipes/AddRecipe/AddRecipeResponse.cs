namespace RecipesService.Handlers.Recipes.AddRecipe
{
    public sealed class AddRecipeResponse
    {
        public string Error { get; set; }

        public bool HasError() => string.IsNullOrEmpty(Error) == false;
    }
}
