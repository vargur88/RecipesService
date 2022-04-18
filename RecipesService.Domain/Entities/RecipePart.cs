using System.Collections.Generic;

namespace RecipesService.Domain.Entities
{
    public sealed class RecipePart
    {
        public string PartNmae { get; set; }

        public IList<Ingredient> Ingredients { get; set; }
    }
}
