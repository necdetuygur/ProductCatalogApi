using Application.Repositories.NecdetRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.NecdetQueries.GetByIdNecdet
{
    public class GetByIdNecdetQueryHandler : IRequestHandler<GetByIdNecdetQueryRequest, GetByIdNecdetQueryResponse>
    {
        private readonly INecdetReadRepository _NecdetReadRepository;
        private readonly INecdetWriteRepository _NecdetWriteRepository;

        public GetByIdNecdetQueryHandler(INecdetReadRepository NecdetReadRepository, INecdetWriteRepository NecdetWriteRepository)
        {
            _NecdetReadRepository = NecdetReadRepository;
            _NecdetWriteRepository = NecdetWriteRepository;
        }
        public async Task<GetByIdNecdetQueryResponse> Handle(GetByIdNecdetQueryRequest request, CancellationToken cancellationToken)
        {
            var Necdet = await _NecdetReadRepository.Table
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            GetByIdNecdetQueryResponse response = new();
            response.Id = Necdet.Id;
            response.Col1 = Necdet.Col1;
            response.Col2 = Necdet.Col2;
            response.Col3 = Necdet.Col3;

            return response;
        }
    }
}
