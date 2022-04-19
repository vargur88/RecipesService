using System;

namespace RecipesService.Handlers.Categories.GetCategories
{
    public sealed class GetCategoriesResponse
    {
        public Guid UniqueId { get; set; }

        public string CategoryName { get; set; }
    }
}
