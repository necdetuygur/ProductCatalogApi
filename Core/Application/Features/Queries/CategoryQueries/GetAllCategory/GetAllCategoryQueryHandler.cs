using Application.Repositories.CategoryRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.CategoryQueries.GetAllCategories
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, List<GetAllCategoryQueryResponse>>
    {
        private readonly ICategoryReadRepository _CategoryReadRepository;

        public GetAllCategoryQueryHandler(ICategoryReadRepository CategoryReadRepository)
        {
            _CategoryReadRepository = CategoryReadRepository;
        }
        public async Task<List<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllCategoryQueryResponse> responseList = new();

            var orders = await _CategoryReadRepository.Table
                .ToListAsync()
                ;

            foreach (var p in orders)
            {
                responseList.Add(new GetAllCategoryQueryResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Slug = p.Slug
                });
            }
            return responseList;
        }
    }
}
