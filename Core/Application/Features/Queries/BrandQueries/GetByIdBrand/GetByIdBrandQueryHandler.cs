using Application.Repositories.BrandRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.BrandQueries.GetByIdBrand
{
    public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQueryRequest, GetByIdBrandQueryResponse>
    {
        private readonly IBrandReadRepository _BrandReadRepository;
        private readonly IBrandWriteRepository _BrandWriteRepository;

        public GetByIdBrandQueryHandler(IBrandReadRepository BrandReadRepository, IBrandWriteRepository BrandWriteRepository)
        {
            _BrandReadRepository = BrandReadRepository;
            _BrandWriteRepository = BrandWriteRepository;
        }
        public async Task<GetByIdBrandQueryResponse> Handle(GetByIdBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var Brand = await _BrandReadRepository.Table
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            GetByIdBrandQueryResponse response = new();
            response.Id = Brand.Id;
            response.Name = Brand.Name;

            return response;
        }
    }
}
