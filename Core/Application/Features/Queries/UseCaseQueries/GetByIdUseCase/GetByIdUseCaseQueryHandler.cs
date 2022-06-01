using Application.Repositories.UseCaseRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.UseCaseQueries.GetByIdUseCase
{
    public class GetByIdUseCaseQueryHandler : IRequestHandler<GetByIdUseCaseQueryRequest, GetByIdUseCaseQueryResponse>
    {
        private readonly IUseCaseReadRepository _UseCaseReadRepository;
        private readonly IUseCaseWriteRepository _UseCaseWriteRepository;

        public GetByIdUseCaseQueryHandler(IUseCaseReadRepository UseCaseReadRepository, IUseCaseWriteRepository UseCaseWriteRepository)
        {
            _UseCaseReadRepository = UseCaseReadRepository;
            _UseCaseWriteRepository = UseCaseWriteRepository;
        }
        public async Task<GetByIdUseCaseQueryResponse> Handle(GetByIdUseCaseQueryRequest request, CancellationToken cancellationToken)
        {
            var UseCase = await _UseCaseReadRepository.Table
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            GetByIdUseCaseQueryResponse response = new();
            response.Id = UseCase.Id;
            response.Name = UseCase.Name;

            return response;
        }
    }
}
