using Application.Repositories.NecdetRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.NecdetQueries.GetAllNecdets
{
    public class GetAllNecdetQueryHandler : IRequestHandler<GetAllNecdetQueryRequest, List<GetAllNecdetQueryResponse>>
    {
        private readonly INecdetReadRepository _NecdetReadRepository;

        public GetAllNecdetQueryHandler(INecdetReadRepository NecdetReadRepository)
        {
            _NecdetReadRepository = NecdetReadRepository;
        }
        public async Task<List<GetAllNecdetQueryResponse>> Handle(GetAllNecdetQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllNecdetQueryResponse> responseList = new();

            var orders = await _NecdetReadRepository.Table
                .ToListAsync()
                ;

            foreach (var p in orders)
            {
                responseList.Add(new GetAllNecdetQueryResponse
                {
                    Id = p.Id,
                    Col1 = p.Col1,
                    Col2 = p.Col2,
                    Col3 = p.Col3
                });
            }
            return responseList;
        }
    }
}
