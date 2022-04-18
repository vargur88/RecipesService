using Microsoft.Extensions.DependencyInjection;
using RecipesService.Domain.Entities;
using RecipesService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipesService.Application.Extensions
{
    public static class InitDataExtension
    {
        public static IServiceCollection InitData(this IServiceCollection services)
        {
            var recipesRepo = services
                .BuildServiceProvider()
                .GetRequiredService<IRecipesRepository>();

            var categoriesRepo = services
                .BuildServiceProvider()
                .GetRequiredService<ICategoriesRepository>();

            categoriesRepo.CreateCategory(
                new Category()
                {
                    CategoryName = "Main dish",
                    UniqueId = Guid.NewGuid()
                }, System.Threading.CancellationToken.None);

            categoriesRepo.CreateCategory(
                new Category()
                {
                    CategoryName = "Chili",
                    UniqueId = Guid.NewGuid()
                }, System.Threading.CancellationToken.None);

            var allCategories = categoriesRepo.GetCategories(System.Threading.CancellationToken.None).Result;

            recipesRepo.CreateRecipe(
                new Recipe()
                {
                    UniqueId = Guid.NewGuid(),
                    Title = "30 Minute Chili",
                    Directions = "text_of_directions_steps",
                    Categories = new List<Guid>()
                    {
                        allCategories.Single(t => t.CategoryName == "Main dish").UniqueId,
                        allCategories.Single(t => t.CategoryName == "Chili").UniqueId
                    },
                    RecipeParts = new List<RecipePart>()
                    {
                        new RecipePart()
                        {
                            PartName = "",
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
                }, System.Threading.CancellationToken.None);

            services.Remove(services.FirstOrDefault(t => t.ServiceType == typeof(IRecipesRepository)));
            services.AddSingleton(recipesRepo);

            services.Remove(services.FirstOrDefault(t => t.ServiceType == typeof(ICategoriesRepository)));
            services.AddSingleton(categoriesRepo);

            return services;
        }
    }
}
