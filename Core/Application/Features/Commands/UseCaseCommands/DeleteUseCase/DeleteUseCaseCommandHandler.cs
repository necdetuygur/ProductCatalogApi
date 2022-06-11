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
        private readonly IUseCaseWriteRepository _useCaseWriteRepository;
        private readonly IUseCaseReadRepository _useCaseReadRepository;

        public DeleteUseCaseCommandHandler(IUseCaseWriteRepository useCaseWriteRepository, IUseCaseReadRepository useCaseReadRepository)
        {
            _useCaseWriteRepository = useCaseWriteRepository;
            _useCaseReadRepository = useCaseReadRepository;
        }
        public async Task<DeleteUseCaseCommandResponse> Handle(DeleteUseCaseCommandRequest request, CancellationToken cancellationToken)
        {
            var useCase = await _useCaseReadRepository.GetByIdAsync(request.Id);

            if (useCase is null)
            {
                return new DeleteUseCaseCommandResponse
                {
                    Message = "UseCase is null.",
                    Success = false
                };
            }

            _useCaseWriteRepository.Remove(useCase);

            var result = await _useCaseWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteUseCaseCommandResponse
            {
                Message = result == true ? "UseCase is deleted" : "UseCase is not deleted",
                Success = result
            };

        }
    }
}
