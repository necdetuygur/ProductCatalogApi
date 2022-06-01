using Application.Repositories.$TABLERepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.$TABLEQueries.GetAll$TABLEs
{
    public class GetAll$TABLEQueryHandler : IRequestHandler<GetAll$TABLEQueryRequest, List<GetAll$TABLEQueryResponse>>
    {
        private readonly I$TABLEReadRepository _$TABLEReadRepository;

        public GetAll$TABLEQueryHandler(I$TABLEReadRepository $TABLEReadRepository)
        {
            _$TABLEReadRepository = $TABLEReadRepository;
        }
        public async Task<List<GetAll$TABLEQueryResponse>> Handle(GetAll$TABLEQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAll$TABLEQueryResponse> responseList = new();

            var orders = await _$TABLEReadRepository.Table
                .ToListAsync()
                ;

            foreach (var p in orders)
            {
                responseList.Add(new GetAll$TABLEQueryResponse
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
