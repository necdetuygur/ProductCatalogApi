using Application.Repositories.UserRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.UserQueries.GetByIdUser
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, GetByIdUserQueryResponse>
    {
        private readonly IUserReadRepository _UserReadRepository;
        private readonly IUserWriteRepository _UserWriteRepository;

        public GetByIdUserQueryHandler(IUserReadRepository UserReadRepository, IUserWriteRepository UserWriteRepository)
        {
            _UserReadRepository = UserReadRepository;
            _UserWriteRepository = UserWriteRepository;
        }
        public async Task<GetByIdUserQueryResponse> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
            var User = await _UserReadRepository.Table
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            GetByIdUserQueryResponse response = new();
            response.Id = User.Id;
            response.Name = User.Name;
            response.Surname = User.Surname;
            response.Email = User.Email;
            // response.Password = User.Password;

            return response;
        }
    }
}
