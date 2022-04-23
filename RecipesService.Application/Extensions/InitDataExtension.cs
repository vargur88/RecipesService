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

            categoriesRepo.CreateCategory(
                new Category()
                {
                    CategoryName = "Microwave",
                    UniqueId = Guid.NewGuid()
                }, System.Threading.CancellationToken.None);

            categoriesRepo.CreateCategory(
                new Category()
                {
                    CategoryName = "Vegetables",
                    UniqueId = Guid.NewGuid()
                }, System.Threading.CancellationToken.None);

            categoriesRepo.CreateCategory(
                new Category()
                {
                    CategoryName = "Liquor",
                    UniqueId = Guid.NewGuid()
                }, System.Threading.CancellationToken.None);

            categoriesRepo.CreateCategory(
                new Category()
                {
                    CategoryName = "Cakes",
                    UniqueId = Guid.NewGuid()
                }, System.Threading.CancellationToken.None);

            categoriesRepo.CreateCategory(
                new Category()
                {
                    CategoryName = "Cake mixes",
                    UniqueId = Guid.NewGuid()
                }, System.Threading.CancellationToken.None);

            var allCategories = categoriesRepo.GetCategories(System.Threading.CancellationToken.None).Result;

            recipesRepo.CreateRecipe(
                new Recipe()
                {
                    UniqueId = Guid.NewGuid(),
                    Title = "30 Minute Chili",
                    Directions = "text_of_directions_steps",
                    Yield = "6",
                    Categories = new List<Guid>()
                    {
                        allCategories.Single(t => t.CategoryName == "Main dish").UniqueId,
                        allCategories.Single(t => t.CategoryName == "Chili").UniqueId
                    },
                    RecipeParts = new List<RecipePart>()
                    {
                        new RecipePart()
                        {
                            PartName = "Main dish",
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

            recipesRepo.CreateRecipe(
                new Recipe()
                {
                    UniqueId = Guid.NewGuid(),
                    Title = "Amaretto Cake",
                    Directions = "text_of_directions_steps",
                    Yield = "1",
                    Categories = new List<Guid>()
                    {
                        allCategories.Single(t => t.CategoryName == "Liquor").UniqueId,
                        allCategories.Single(t => t.CategoryName == "Cakes").UniqueId,
                        allCategories.Single(t => t.CategoryName == "Cake mixes").UniqueId
                    },
                    RecipeParts = new List<RecipePart>()
                    {
                        new RecipePart()
                        {
                            PartName = "Main dish",
                            Ingredients = new List<Ingredient>
                            {
                                new Ingredient()
                                {
                                    IngredientContent = "Toasted Almonds; chopped",
                                    Quantity = "1 1/2",
                                    Unit = "cups"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Yellow cake mix; no pudding",
                                    Quantity = "1",
                                    Unit = "package"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Vanilla instant pudding",
                                    Quantity = "1",
                                    Unit = "package"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Eggs",
                                    Quantity = "4",
                                    Unit = string.Empty
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Vegetable oil",
                                    Quantity = "1/2",
                                    Unit = "cups"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Water",
                                    Quantity = "1/2",
                                    Unit = "cups"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Amaretto",
                                    Quantity = "1/2",
                                    Unit = "cups"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Almond extract",
                                    Quantity = "1",
                                    Unit = "teaspoon"
                                }
                            }
                        },
                        new RecipePart()
                        {
                            PartName = "Glaze",
                            Ingredients = new List<Ingredient>
                            {
                                new Ingredient()
                                {
                                    IngredientContent = "Sugar",
                                    Quantity = "1/2",
                                    Unit = "cups"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Water",
                                    Quantity = "1/4",
                                    Unit = "cups"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Butter",
                                    Quantity = "2",
                                    Unit = "tablespoons"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Amaretto",
                                    Quantity = "1/4",
                                    Unit = "cups"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Almond extract",
                                    Quantity = "1/2",
                                    Unit = "teaspoons"
                                }
                            }
                        }
                    }
                }, System.Threading.CancellationToken.None);

            recipesRepo.CreateRecipe(
                new Recipe()
                {
                    UniqueId = Guid.NewGuid(),
                    Title = "Another Zucchini Dish",
                    Directions = "text_of_directions_steps",
                    Yield = "6",
                    Categories = new List<Guid>()
                    {
                        allCategories.Single(t => t.CategoryName == "Microwave").UniqueId,
                        allCategories.Single(t => t.CategoryName == "Vegetables").UniqueId
                    },
                    RecipeParts = new List<RecipePart>()
                    {
                        new RecipePart()
                        {
                            PartName = "Main dish",
                            Ingredients = new List<Ingredient>
                            {
                                new Ingredient()
                                {
                                    IngredientContent = "Zucchini; cubed 1/2",
                                    Quantity = "1",
                                    Unit = "pound"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Butter or margarine",
                                    Quantity = "3",
                                    Unit = "tablespoons"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Eggs; beaten",
                                    Quantity = "3",
                                    Unit = string.Empty
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Jar pimentos; 2 1/2 oz, diced",
                                    Quantity = "1",
                                    Unit = string.Empty
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "Cheddar cheese; shredded",
                                    Quantity = "1",
                                    Unit = "cup"
                                },
                                new Ingredient()
                                {
                                    IngredientContent = "French fried onion rings 3 oz.",
                                    Quantity = "1",
                                    Unit = "can"
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
