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
        private readonly IUseCaseReadRepository _UseCaseReadRepository;
        private readonly IUseCaseWriteRepository _UseCaseWriteRepository;

        public UpdateUseCaseCommandHandler(IUseCaseWriteRepository UseCaseWriteRepository, IUseCaseReadRepository UseCaseReadRepository)
        {

            _UseCaseWriteRepository = UseCaseWriteRepository;
            _UseCaseReadRepository = UseCaseReadRepository;
        }
        public async Task<UpdateUseCaseCommandResponse> Handle(UpdateUseCaseCommandRequest request, CancellationToken cancellationToken)
        {
            var UseCase = await _UseCaseReadRepository.GetByIdAsync(request.Id);
            if (UseCase == null)
            {
                return new UpdateUseCaseCommandResponse
                {
                    Success = false,
                    Message = "UseCase not found"
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

            UseCase.Name = request.Name ?? UseCase.Name;

            _UseCaseWriteRepository.Update(UseCase);

            await _UseCaseWriteRepository.SaveAsync();

            return new UpdateUseCaseCommandResponse
            {
                Success = true,
                Message = "UseCase updated successfully"
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
