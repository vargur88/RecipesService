using FluentValidation;
using System;
using System.Linq;

namespace RecipesService.Handlers.Recipes.GetRecipes
{
    public sealed class GetRecipesRequestValidator : AbstractValidator<GetRecipesRequest>
    {
        public GetRecipesRequestValidator()
        {
            RuleFor(t => t.CategoryId)
                .Must(t => Guid.TryParse(t, out _) == true)
                .When(t => t.CategoryId != null && t.CategoryId != "null")
                .WithMessage("Wrong Category identifier");

            RuleFor(t => t.SearchString)
                .Must(t => t.All(Char.IsLetter))
                .When(t => string.IsNullOrEmpty(t.SearchString) == false)
                .WithMessage("SearchString allows only letters");
        }
    }
}
