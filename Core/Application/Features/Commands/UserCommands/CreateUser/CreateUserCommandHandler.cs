using Application.Repositories.UserRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserWriteRepository _UserWriteRepository;
        private readonly IUserReadRepository _UserReadRepository;

        public CreateUserCommandHandler(IUserWriteRepository UserWriteRepository, IUserReadRepository UserReadRepository)
        {
            _UserWriteRepository = UserWriteRepository;
            _UserReadRepository = UserReadRepository;
        }
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var email = await _UserReadRepository.GetSingleAsync(p => p.Email == request.Email);

            if (email is not null)
            {
                return new CreateUserCommandResponse()
                {
                    Success = false,
                    Message = "Email is already exists"
                };
            }

            var id = Guid.NewGuid();
            User User = new User
            {
                Id = id,
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Password = Helpers.Md5.Hash(request.Password)
            };

            var result = await _UserWriteRepository.AddAsync(User);

            await _UserWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateUserCommandResponse { Success = result, Message = result ? "User created successfully" : "User creation failed" };
        }
    }
}
