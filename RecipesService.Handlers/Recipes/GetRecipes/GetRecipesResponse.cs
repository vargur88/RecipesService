using RecipesService.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RecipesService.Handlers.Recipes.GetRecipes
{
    public sealed class GetRecipesResponse
    {
        public Guid UniqueId { get; set; }

        public string Title { get; set; }

        public string Directions { get; set; }

        public string Yield { get; set; }

        public IList<string> Categories { get; set; }

        public IList<RecipePart> RecipeParts { get; set; }
    }
}
