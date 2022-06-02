using Application.Repositories.UserRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.UserQueries.GetAllUsers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, List<GetAllUserQueryResponse>>
    {
        private readonly IUserReadRepository _UserReadRepository;

        public GetAllUserQueryHandler(IUserReadRepository UserReadRepository)
        {
            _UserReadRepository = UserReadRepository;
        }
        public async Task<List<GetAllUserQueryResponse>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllUserQueryResponse> responseList = new();

            var orders = await _UserReadRepository.Table
                .ToListAsync()
                ;

            foreach (var p in orders)
            {
                responseList.Add(new GetAllUserQueryResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Email,
                    // Password = p.Password
                });
            }
            return responseList;
        }
    }
}
