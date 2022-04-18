using System.Collections.Generic;

namespace RecipesService.Domain.Entities
{
    public sealed class RecipePart
    {
        public string PartName { get; set; }

        public IList<Ingredient> Ingredients { get; set; }
    }
}
