using System;

namespace RecipesService.Handlers.Categories.GetCategories
{
    public sealed class GetCategoriesResponse : BaseResponse
    {
        public Guid UniqueId { get; set; }

        public string CategoryName { get; set; }
    }
}
