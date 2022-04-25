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
    public class CategoriesRepositoryTests
	{
		[Theory, AutoMoqData]
		public async Task Should_add_data_correctly(CategoriesInMemoryRepository repository)
		{
			var expectedCollection = new List<Category>
			{
				new Category { UniqueId = Guid.NewGuid(), CategoryName = "cat1" },
				new Category { UniqueId = Guid.NewGuid(), CategoryName = "cat2" },
				new Category { UniqueId = Guid.NewGuid(), CategoryName = "cat3" }
			};

			foreach (var next in expectedCollection)
			{
				await repository.CreateCategory(next, CancellationToken.None);
			}
			var actualCollection = await repository.GetCategories(CancellationToken.None);

			actualCollection.Should().BeEquivalentTo(expectedCollection);
		}

		[Theory, AutoMoqData]
		public async Task Should_find_data_correctly(CategoriesInMemoryRepository repository)
		{
			var category = new Category() { UniqueId = Guid.NewGuid(), CategoryName = "cat1" };
			await repository.CreateCategory(category, CancellationToken.None);

			var actualCategory = await repository.FindCategory(category.CategoryName, CancellationToken.None);

			actualCategory.Should().BeEquivalentTo(category);
		}
	}
}
