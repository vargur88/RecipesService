using System;

namespace RecipesService.Domain.Entities
{
    public sealed class Category
    {
        public Guid UniqueId { get; set; }

        public string CategoryName { get; set; }
    }
}
