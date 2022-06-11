using Application.Repositories.UseCaseRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.UseCaseCommands.CreateUseCase
{
    public class CreateUseCaseCommandHandler : IRequestHandler<CreateUseCaseCommandRequest, CreateUseCaseCommandResponse>
    {
        private readonly IUseCaseWriteRepository _useCaseWriteRepository;
        private readonly IUseCaseReadRepository _useCaseReadRepository;

        public CreateUseCaseCommandHandler(IUseCaseWriteRepository useCaseWriteRepository, IUseCaseReadRepository useCaseReadRepository)
        {
            _useCaseWriteRepository = useCaseWriteRepository;
            _useCaseReadRepository = useCaseReadRepository;
        }
        public async Task<CreateUseCaseCommandResponse> Handle(CreateUseCaseCommandRequest request, CancellationToken cancellationToken)
        {

            var id = Guid.NewGuid();
            UseCase useCase = new UseCase
            {
                Id = id,
                Name = request.Name
            };

            var result = await _useCaseWriteRepository.AddAsync(useCase);

            await _useCaseWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateUseCaseCommandResponse { Success = result, Message = result ? "UseCase  is created successfully" : "UseCase creation is failed" };
        }
    }
}
