using Application.Repositories.UseCaseRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.UseCaseQueries.GetAllUseCases
{
    public class GetAllUseCaseQueryHandler : IRequestHandler<GetAllUseCaseQueryRequest, List<GetAllUseCaseQueryResponse>>
    {
        private readonly IUseCaseReadRepository _UseCaseReadRepository;

        public GetAllUseCaseQueryHandler(IUseCaseReadRepository UseCaseReadRepository)
        {
            _UseCaseReadRepository = UseCaseReadRepository;
        }
        public async Task<List<GetAllUseCaseQueryResponse>> Handle(GetAllUseCaseQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllUseCaseQueryResponse> responseList = new();

            var orders = await _UseCaseReadRepository.Table
                .ToListAsync()
                ;

            foreach (var p in orders)
            {
                responseList.Add(new GetAllUseCaseQueryResponse
                {
                    Id = p.Id,
                    Name = p.Name
                });
            }
            return responseList;
        }
    }
}
