using Application.Repositories.BrandRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.BrandQueries.GetAllBrands
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQueryRequest, List<GetAllBrandQueryResponse>>
    {
        private readonly IBrandReadRepository _BrandReadRepository;

        public GetAllBrandQueryHandler(IBrandReadRepository BrandReadRepository)
        {
            _BrandReadRepository = BrandReadRepository;
        }
        public async Task<List<GetAllBrandQueryResponse>> Handle(GetAllBrandQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllBrandQueryResponse> responseList = new();

            var orders = await _BrandReadRepository.Table
                .ToListAsync()
                ;

            foreach (var p in orders)
            {
                responseList.Add(new GetAllBrandQueryResponse
                {
                    Id = p.Id,
                    Name = p.Name
                });
            }
            return responseList;
        }
    }
}
