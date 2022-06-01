using Application.Repositories.$TABLERepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.$TABLEQueries.GetById$TABLE
{
    public class GetById$TABLEQueryHandler : IRequestHandler<GetById$TABLEQueryRequest, GetById$TABLEQueryResponse>
    {
        private readonly I$TABLEReadRepository _$TABLEReadRepository;
        private readonly I$TABLEWriteRepository _$TABLEWriteRepository;

        public GetById$TABLEQueryHandler(I$TABLEReadRepository $TABLEReadRepository, I$TABLEWriteRepository $TABLEWriteRepository)
        {
            _$TABLEReadRepository = $TABLEReadRepository;
            _$TABLEWriteRepository = $TABLEWriteRepository;
        }
        public async Task<GetById$TABLEQueryResponse> Handle(GetById$TABLEQueryRequest request, CancellationToken cancellationToken)
        {
            var $TABLE = await _$TABLEReadRepository.Table
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            GetById$TABLEQueryResponse response = new();
            response.Id = $TABLE.Id;
            response.Col1 = $TABLE.Col1;
            response.Col2 = $TABLE.Col2;
            response.Col3 = $TABLE.Col3;

            return response;
        }
    }
}
