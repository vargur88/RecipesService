using FluentValidation;

namespace RecipesService.Handlers.Recipes.AddRecipe
{
    public sealed class AddRecipeRequestValidator : AbstractValidator<AddRecipeRequest>
    {
        public AddRecipeRequestValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty()
                .WithMessage("Empty title");

            RuleFor(t => t.Directions)
                .NotEmpty()
                .WithMessage("Empty direction");

            RuleFor(t => t.RecipeParts)
                .NotEmpty()
                .WithMessage("Empty recipe parts");

            RuleFor(t => t.Categories)
                .NotEmpty()
                .WithMessage("Empty categories");

            RuleForEach(t => t.Categories)
                .NotEmpty()
                .Must(k => string.IsNullOrEmpty(k) == false)
                .WithMessage("One or more category is empty");

            RuleForEach(t => t.RecipeParts)
                .NotEmpty()
                .Must(t => string.IsNullOrEmpty(t.PartName) == false)
                .Must(t => t.Ingredients != null)
                .ChildRules(k =>
                    {
                        k.RuleForEach(r => r.Ingredients)
                            .NotEmpty()
                            .Must(r => string.IsNullOrEmpty(r.Quantity) == false)
                            .Must(r => string.IsNullOrEmpty(r.Unit) == false)
                            .Must(r => string.IsNullOrEmpty(r.IngredientContent) == false)
                            .WithMessage("Some of given ingrediens has missed fields");
                    })
                .WithMessage("Recipe parts has missed fiedls");
        }
    }
}
