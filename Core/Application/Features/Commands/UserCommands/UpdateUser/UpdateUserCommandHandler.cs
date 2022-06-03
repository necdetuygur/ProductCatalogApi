using Application.Repositories.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IUserReadRepository _UserReadRepository;
        private readonly IUserWriteRepository _UserWriteRepository;

        public UpdateUserCommandHandler(IUserWriteRepository UserWriteRepository, IUserReadRepository UserReadRepository)
        {

            _UserWriteRepository = UserWriteRepository;
            _UserReadRepository = UserReadRepository;
        }
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var User = await _UserReadRepository.GetByIdAsync(request.Id);
            if (User == null)
            {
                return new UpdateUserCommandResponse
                {
                    Success = false,
                    Message = "User not found"
                };
            }

            if (CheckRequestIsEmpty(request))
            {
                return new UpdateUserCommandResponse
                {
                    Success = false,
                    Message = "Request is empty"
                };
            }

            User.Name = request.Name ?? User.Name;
            User.Surname = request.Surname ?? User.Surname;
            User.Email = request.Email ?? User.Email;
            User.Password = request.Password ?? User.Password;

            User.Password = Helpers.Md5.Hash(User.Password);

            _UserWriteRepository.Update(User);

            await _UserWriteRepository.SaveAsync();

            return new UpdateUserCommandResponse
            {
                Success = true,
                Message = "User updated successfully"
            };
        }

        private bool CheckRequestIsEmpty(UpdateUserCommandRequest request)
        {
            if (request.Name == null &&
                request.Surname == null &&
                request.Email == null &&
                request.Password == null)
            {
                return true;
            }

            return false;
        }
    }
}
