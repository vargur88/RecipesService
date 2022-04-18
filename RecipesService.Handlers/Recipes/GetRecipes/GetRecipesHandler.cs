﻿using MediatR;
using RecipesService.Handlers.Recipes.GetRecipes;
using RecipesService.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using RecipesService.Domain.Entities;
using System;

namespace RecipesService.Handlers.GetRecipes
{
    public sealed class GetRecipesHandler : IRequestHandler<GetRecipesRequest, IReadOnlyList<GetRecipesResponse>>
    {
        private readonly IRecipesRepository _recipesRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public GetRecipesHandler(IRecipesRepository recipesRepository, ICategoriesRepository categoriesRepository)
        {
            _recipesRepository = recipesRepository;
            _categoriesRepository = categoriesRepository;
        }

        public async Task<IReadOnlyList<GetRecipesResponse>> Handle(GetRecipesRequest request, CancellationToken cancellationToken)
        {
            var recipes = await _recipesRepository.GetRecipes(cancellationToken);
            var categories = await _categoriesRepository.GetCategories(cancellationToken);

            if (request.CategoryId.HasValue)
            {
                var searchCategory = categories.SingleOrDefault(t => t.UniqueId == request.CategoryId);
                return ToResponse(recipes.Where(t => t.Categories.Any(k => k == searchCategory.UniqueId)), categories);
            }

            if (string.IsNullOrEmpty(request.SearchString) == false)
            {
                recipes = ApplySearchString(recipes, categories, request.SearchString.ToLower());
                return ToResponse(recipes, categories);
            }

            return ToResponse(recipes, categories);
        }

        private IReadOnlyList<GetRecipesResponse> ToResponse(IEnumerable<Recipe> recipes, IList<Category> categories)
        {
            return recipes.Select(t => new GetRecipesResponse()
            {
                UniqueId = t.UniqueId,
                Title = t.Title,
                Directions = t.Directions,
                RecipeParts = t.RecipeParts,
                Categories = categories.Where(k => t.Categories.Any(r => r == k.UniqueId)).Select(t => t.CategoryName).ToList()
            }).ToList();
        }

        private IList<Recipe> ApplySearchString(IList<Recipe> recipes, IList<Category> categories, string searchString)
        {
            var result = new List<Recipe>();

            foreach(var recipe in recipes)
            {
                if (recipe.Title.ToLower().Contains(searchString))
                {
                    result.Add(recipe);
                    continue;
                }

                foreach(var categoryId in recipe.Categories)
                {
                    if (categories.FirstOrDefault(t => t.UniqueId == categoryId).CategoryName.ToLower().Contains(searchString))
                    {
                        result.Add(recipe);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
