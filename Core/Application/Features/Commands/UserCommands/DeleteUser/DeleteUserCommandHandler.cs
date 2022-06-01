using Application.Repositories.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.UserCommands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        private readonly IUserWriteRepository _UserWriteRepository;
        private readonly IUserReadRepository _UserReadRepository;

        public DeleteUserCommandHandler(IUserWriteRepository orderWriteRepository, IUserReadRepository orderReadRepository)
        {
            _UserWriteRepository = orderWriteRepository;
            _UserReadRepository = orderReadRepository;
        }
        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var User = await _UserReadRepository.GetByIdAsync(request.Id);

            if (User is null)
            {
                return new DeleteUserCommandResponse
                {
                    Message = "User is null.",
                    Success = false
                };
            }

            _UserWriteRepository.Remove(User);

            var result = await _UserWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteUserCommandResponse
            {
                Message = result == true ? "User is deleted" : "User is not deleted",
                Success = result
            };

        }
    }
}
