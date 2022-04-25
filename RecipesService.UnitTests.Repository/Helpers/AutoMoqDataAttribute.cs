using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace RecipesService.UnitTests.Repository.Helpers
{
	public class AutoMoqDataAttribute : AutoDataAttribute
	{
		public AutoMoqDataAttribute()
			: base(GetFixture)
		{
		}

		private static IFixture GetFixture() => new Fixture().Customize(new AutoMoqCustomization());
	}
}
