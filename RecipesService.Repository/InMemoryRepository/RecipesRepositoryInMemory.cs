using System;
using RecipesService.Domain.Entities;
using RecipesService.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace RecipesService.Repository.InMemoryRepository
{
    public sealed class RecipesRepositoryInMemory : IRecipesRepository
    {
        private List<Category> _allCategories = new List<Category>
        {
            new Category() {UniqueId = Guid.NewGuid(), CategoryName = "Main dish"},
            new Category() {UniqueId = Guid.NewGuid(), CategoryName = "Chili"}
        };

        private List<Recipe> _recipes;

        public RecipesRepositoryInMemory()
        {
            _recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    UniqueId = Guid.NewGuid(),
                    Title = "30 Minute Chili",
                    Directions = "text_of_directions_steps",
                    Categories = new List<Guid>()
                    {
                        _allCategories.FirstOrDefault(x => x.CategoryName == "Main dish").UniqueId,
                        _allCategories.FirstOrDefault(x => x.CategoryName == "Chili").UniqueId
                    },
                    RecipeParts = new List<RecipePart>()
                    {
                        new RecipePart()
                        {
                            PartNmae = "",
                            Ingredients = new List<Ingredient>
                            {
                                new Ingredient()
                                {
                                    IngredientContent = "Ground chuck or lean ground; beef",
                                    Quantity = "1",
                                    Unit = "pound"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Onion; large, chopped",
                                    Quantity = "1",
                                    Unit = string.Empty
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Kidney beans; (12 oz)",
                                    Quantity = "1",
                                    Unit = "can"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Tomato soup; undiluted",
                                    Quantity = "1",
                                    Unit = "can"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Salt",
                                    Quantity = "1",
                                    Unit = "teaspoon"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Chili powder; (or to taste)",
                                    Quantity = "1",
                                    Unit = "tablespoon"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Hot pepper sauce; to taste",
                                    Quantity = string.Empty,
                                    Unit = string.Empty
                                }
                            }
                        }
                    }
                }
            };
        }

        public async Task<IReadOnlyList<Category>> GetCategory(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_allCategories.AsReadOnly());
        }

        public async Task<IReadOnlyList<Recipe>> GetRecipes(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_recipes.AsReadOnly());
        }
    }
}

