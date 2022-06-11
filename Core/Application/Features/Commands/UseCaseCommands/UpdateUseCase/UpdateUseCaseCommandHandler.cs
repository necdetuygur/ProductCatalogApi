using Application.Repositories.UseCaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.UseCaseCommands.UpdateUseCase
{
    public class UpdateUseCaseCommandHandler : IRequestHandler<UpdateUseCaseCommandRequest, UpdateUseCaseCommandResponse>
    {
        private readonly IUseCaseReadRepository _useCaseReadRepository;
        private readonly IUseCaseWriteRepository _useCaseWriteRepository;

        public UpdateUseCaseCommandHandler(IUseCaseWriteRepository useCaseWriteRepository, IUseCaseReadRepository useCaseReadRepository)
        {

            _useCaseWriteRepository = useCaseWriteRepository;
            _useCaseReadRepository = useCaseReadRepository;
        }
        public async Task<UpdateUseCaseCommandResponse> Handle(UpdateUseCaseCommandRequest request, CancellationToken cancellationToken)
        {
            var useCase = await _useCaseReadRepository.GetByIdAsync(request.Id);
            if (useCase == null)
            {
                return new UpdateUseCaseCommandResponse
                {
                    Success = false,
                    Message = "UseCase is not found"
                };
            }

            if (CheckRequestIsEmpty(request))
            {
                return new UpdateUseCaseCommandResponse
                {
                    Success = false,
                    Message = "Request is empty"
                };
            }

            useCase.Name = request.Name ?? useCase.Name;

            _useCaseWriteRepository.Update(useCase);

            await _useCaseWriteRepository.SaveAsync();

            return new UpdateUseCaseCommandResponse
            {
                Success = true,
                Message = "UseCase is updated successfully"
            };
        }

        private bool CheckRequestIsEmpty(UpdateUseCaseCommandRequest request)
        {
            if (request.Name == null)
            {
                return true;
            }

            return false;
        }
    }
}
