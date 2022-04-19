using MediatR;
using RecipesService.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecipesService.Handlers.Categories.GetCategories
{
    public sealed class GetCategoriesHandler : IRequestHandler<GetCategoriesRequest, IReadOnlyList<GetCategoriesResponse>>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public GetCategoriesHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<IReadOnlyList<GetCategoriesResponse>> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoriesRepository.GetCategories(cancellationToken);

            return categories.Select(t => new GetCategoriesResponse()
            {
                UniqueId = t.UniqueId,
                CategoryName = t.CategoryName
            }).ToList();
        }
    }
}
