using Application.Repositories.UseCaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.UseCaseCommands.DeleteUseCase
{
    public class DeleteUseCaseCommandHandler : IRequestHandler<DeleteUseCaseCommandRequest, DeleteUseCaseCommandResponse>
    {
        private readonly IUseCaseWriteRepository _UseCaseWriteRepository;
        private readonly IUseCaseReadRepository _UseCaseReadRepository;

        public DeleteUseCaseCommandHandler(IUseCaseWriteRepository orderWriteRepository, IUseCaseReadRepository orderReadRepository)
        {
            _UseCaseWriteRepository = orderWriteRepository;
            _UseCaseReadRepository = orderReadRepository;
        }
        public async Task<DeleteUseCaseCommandResponse> Handle(DeleteUseCaseCommandRequest request, CancellationToken cancellationToken)
        {
            var UseCase = await _UseCaseReadRepository.GetByIdAsync(request.Id);

            if (UseCase is null)
            {
                return new DeleteUseCaseCommandResponse
                {
                    Message = "UseCase is null.",
                    Success = false
                };
            }

            _UseCaseWriteRepository.Remove(UseCase);

            var result = await _UseCaseWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteUseCaseCommandResponse
            {
                Message = result == true ? "UseCase is deleted" : "UseCase is not deleted",
                Success = result
            };

        }
    }
}
