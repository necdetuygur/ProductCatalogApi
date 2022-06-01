using Application.Repositories.ColorRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.ColorQueries.GetAllColors
{
    public class GetAllColorQueryHandler : IRequestHandler<GetAllColorQueryRequest, List<GetAllColorQueryResponse>>
    {
        private readonly IColorReadRepository _ColorReadRepository;

        public GetAllColorQueryHandler(IColorReadRepository ColorReadRepository)
        {
            _ColorReadRepository = ColorReadRepository;
        }
        public async Task<List<GetAllColorQueryResponse>> Handle(GetAllColorQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllColorQueryResponse> responseList = new();

            var orders = await _ColorReadRepository.Table
                .ToListAsync()
                ;

            foreach (var p in orders)
            {
                responseList.Add(new GetAllColorQueryResponse
                {
                    Id = p.Id,
                    Name = p.Name
                });
            }
            return responseList;
        }
    }
}
