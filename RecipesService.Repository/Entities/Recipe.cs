using System;
using System.Collections.Generic;

namespace RecipesService.Repository.Entities
{
    public sealed class Recipe
    {
        public Guid UniqueId { get; set; }

        public string Title { get; set; }

        public string Directions { get; set; }

        public IList<Category> Categories { get; set; }

        public IList<RecipePart> RecipeParts { get; set; }
    }
}
