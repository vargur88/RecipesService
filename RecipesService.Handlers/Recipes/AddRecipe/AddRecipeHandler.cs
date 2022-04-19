using MediatR;
using RecipesService.Domain.Entities;
using RecipesService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace RecipesService.Handlers.Recipes.AddRecipe
{
    public sealed class AddRecipeHandler : IRequestHandler<AddRecipeRequest, AddRecipeResponse>
    {
        private readonly IRecipesRepository _recipesRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public AddRecipeHandler(IRecipesRepository recipesRepository, ICategoriesRepository categoriesRepository)
        {
            _recipesRepository = recipesRepository;
            _categoriesRepository = categoriesRepository;
        }

        public async Task<AddRecipeResponse> Handle(AddRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipe = await _recipesRepository.FindRecipe(request.Title, cancellationToken);
            if (recipe != null)
            {
                return await Task.FromResult(new AddRecipeResponse() { Error = "Recipe with given title already exists" });
            }

            var categories = new List<Category>();
            foreach(var next in request.Categories)
            {
                var category = await _categoriesRepository.FindCategory(next, cancellationToken);
                if (category == null)
                {
                    category = new Category() { CategoryName = next, UniqueId = Guid.NewGuid() };
                    await _categoriesRepository.CreateCategory(category, cancellationToken);
                }

                categories.Add(category);
            }

            await _recipesRepository.CreateRecipe(
                new Recipe()
                {
                    UniqueId = Guid.NewGuid(),
                    Title = request.Title,
                    Directions = request.Directions,
                    Categories = categories.Select(t => t.UniqueId).ToList(),
                    RecipeParts = request.RecipeParts
                        .Select(t => new RecipePart() 
                        { 
                            PartName = t.PartName, 
                            Ingredients = t.Ingredients
                                            .Select(k => new Ingredient()
                                            {
                                                IngredientContent = k.IngredientContent,
                                                Quantity = k.Quantity,
                                                Unit = k.Unit
                                            }).ToList()
                        }).ToList()
                }
                , cancellationToken);

            return await Task.FromResult(new AddRecipeResponse());
        }
    }
}
