using Application.Repositories.CategoryRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.CategoryQueries.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly ICategoryReadRepository _CategoryReadRepository;
        private readonly ICategoryWriteRepository _CategoryWriteRepository;

        public GetByIdCategoryQueryHandler(ICategoryReadRepository CategoryReadRepository, ICategoryWriteRepository CategoryWriteRepository)
        {
            _CategoryReadRepository = CategoryReadRepository;
            _CategoryWriteRepository = CategoryWriteRepository;
        }
        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var Category = await _CategoryReadRepository.Table
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            GetByIdCategoryQueryResponse response = new();
            response.Id = Category.Id;
            response.Name = Category.Name;
            response.Description = Category.Description;
            response.Slug = Category.Slug;

            return response;
        }
    }
}
