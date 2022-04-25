using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;
using RecipesService.Domain.Entities;
using RecipesService.Handlers.GetRecipes;
using RecipesService.Handlers.Recipes.GetRecipes;
using RecipesService.Repository.Interfaces;
using Xunit;

namespace RecipesService.UnitTests.Handlers
{
	public class GetRecipesHandlerTests
	{
		private readonly GetRecipesHandler _handler;
		private readonly Guid _category1Guid = Guid.NewGuid();
		private readonly Guid _category2Guid = Guid.NewGuid();
		private readonly List<Recipe> _recipes = null;

		public GetRecipesHandlerTests()
		{
			var recipesRepository = new Mock<IRecipesRepository>();
			_recipes = new List<Recipe>
			{
				new Recipe(){Title = "t1", Directions = "d1", UniqueId = Guid.NewGuid(), Yield = "y1",
					RecipeParts = new List<RecipePart>(){ new RecipePart() { PartName = "p1",
						Ingredients = new List<Ingredient>(){ new Ingredient(){ IngredientContent = "ic1", Quantity = "q1", Unit = "u1"} }} },
					Categories = new List<Guid>() { _category1Guid }},
				new Recipe(){Title = "t2", Directions = "d2", UniqueId = Guid.NewGuid(), Yield = "y2",
					RecipeParts = new List<RecipePart>(){ new RecipePart() { PartName = "p2",
						Ingredients = new List<Ingredient>(){ new Ingredient(){ IngredientContent = "ic2", Quantity = "q2", Unit = "u2"} }} },
					Categories = new List<Guid>() { _category2Guid }}
			};
			recipesRepository.Setup(x => x.GetRecipes(default)).ReturnsAsync(_recipes);

			var categoryRepository = new Mock<ICategoriesRepository>();
			var categories = new List<Category>
			{
				new Category() {UniqueId = _category1Guid, CategoryName = "c1"},
				new Category() {UniqueId = _category2Guid, CategoryName = "c2"}
			};
			categoryRepository.Setup(x => x.GetCategories(default)).ReturnsAsync(categories);

			_handler = new GetRecipesHandler(recipesRepository.Object, categoryRepository.Object);
		}

		[Fact]
		public async Task Should_return_all_data()
		{
			var request = new GetRecipesRequest();
			var response = await _handler.Handle(request, CancellationToken.None);

			response.ResponseData.Should().NotContainNulls();
			response.ResponseData.Should().HaveCount(2);
			response.ResponseData.Should().OnlyHaveUniqueItems();
		}

		[Fact]
		public async Task Should_return_by_category_data()
		{
			var request = new GetRecipesRequest() { CategoryId = _category1Guid.ToString() };
			var response = await _handler.Handle(request, CancellationToken.None);

			response.ResponseData.Should().NotContainNulls();
			response.ResponseData.Should().HaveCount(1);
			response.ResponseData.Should().ContainSingle(t => t.Title == "t1");
		}

		[Fact]
		public async Task Should_not_return_by_category_data()
		{
			var request = new GetRecipesRequest() { CategoryId = Guid.NewGuid().ToString() };
			var response = await _handler.Handle(request, CancellationToken.None);

			response.ResponseData.Should().BeNull();
		}
	}
}
