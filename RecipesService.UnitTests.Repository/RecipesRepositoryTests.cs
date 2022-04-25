using FluentAssertions;
using Xunit;
using RecipesService.UnitTests.Repository.Helpers;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using RecipesService.Domain.Entities;
using RecipesService.Repository.InMemoryRepository;

namespace RecipesService.UnitTests.Repository
{
	public class RecipesRepositoryTests
	{
		[Theory, AutoMoqData]
		public async Task Should_add_data_correctly(RecipesInMemoryRepository repository)
		{
			var expectedCollection = new List<Recipe>
			{
				new Recipe(){Title = "t1", Directions = "d1", UniqueId = Guid.NewGuid(), Yield = "y1",
					RecipeParts = new List<RecipePart>(){ new RecipePart() { PartName = "p1",
						Ingredients = new List<Ingredient>(){ new Ingredient(){ IngredientContent = "ic1", Quantity = "q1", Unit = "u1"} }} },
					Categories = new List<Guid>() { Guid.NewGuid() }},
				new Recipe(){Title = "t2", Directions = "d2", UniqueId = Guid.NewGuid(), Yield = "y2",
					RecipeParts = new List<RecipePart>(){ new RecipePart() { PartName = "p2",
						Ingredients = new List<Ingredient>(){ new Ingredient(){ IngredientContent = "ic2", Quantity = "q2", Unit = "u2"} }} },
					Categories = new List<Guid>() { Guid.NewGuid() }}
			};

			foreach(var next in expectedCollection)
			{
				await repository.CreateRecipe(next, CancellationToken.None);
			}

			var actualCollection = await repository.GetRecipes(CancellationToken.None);

			actualCollection.Should().BeEquivalentTo(expectedCollection);
		}

		[Theory, AutoMoqData]
		public async Task Should_find_data_correctly(RecipesInMemoryRepository repository)
		{
			var recipe = new Recipe()
			{
				Title = "t1",
				Directions = "d1",
				UniqueId = Guid.NewGuid(),
				Yield = "y1",
				RecipeParts = new List<RecipePart>(){ new RecipePart() { PartName = "p1",
						Ingredients = new List<Ingredient>(){ new Ingredient(){ IngredientContent = "ic1", Quantity = "q1", Unit = "u1"} }} },
				Categories = new List<Guid>() { Guid.NewGuid() }
			};

			await repository.CreateRecipe(recipe, CancellationToken.None);

			var actualRecipe = await repository.FindRecipe(recipe.Title, CancellationToken.None);

			actualRecipe.Should().BeEquivalentTo(recipe);
		}
	}
}
