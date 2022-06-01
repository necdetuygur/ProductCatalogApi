using Application.Repositories.ColorRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.ColorQueries.GetByIdColor
{
    public class GetByIdColorQueryHandler : IRequestHandler<GetByIdColorQueryRequest, GetByIdColorQueryResponse>
    {
        private readonly IColorReadRepository _ColorReadRepository;
        private readonly IColorWriteRepository _ColorWriteRepository;

        public GetByIdColorQueryHandler(IColorReadRepository ColorReadRepository, IColorWriteRepository ColorWriteRepository)
        {
            _ColorReadRepository = ColorReadRepository;
            _ColorWriteRepository = ColorWriteRepository;
        }
        public async Task<GetByIdColorQueryResponse> Handle(GetByIdColorQueryRequest request, CancellationToken cancellationToken)
        {
            var Color = await _ColorReadRepository.Table
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            GetByIdColorQueryResponse response = new();
            response.Id = Color.Id;
            response.Name = Color.Name;

            return response;
        }
    }
}
