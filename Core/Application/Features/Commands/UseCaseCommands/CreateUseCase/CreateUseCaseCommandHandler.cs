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
        private readonly IUseCaseWriteRepository _UseCaseWriteRepository;
        private readonly IUseCaseReadRepository _UseCaseReadRepository;

        public CreateUseCaseCommandHandler(IUseCaseWriteRepository UseCaseWriteRepository, IUseCaseReadRepository UseCaseReadRepository)
        {
            _UseCaseWriteRepository = UseCaseWriteRepository;
            _UseCaseReadRepository = UseCaseReadRepository;
        }
        public async Task<CreateUseCaseCommandResponse> Handle(CreateUseCaseCommandRequest request, CancellationToken cancellationToken)
        {

            var id = Guid.NewGuid();
            UseCase UseCase = new UseCase
            {
                Id = id,
                Name = request.Name
            };

            var result = await _UseCaseWriteRepository.AddAsync(UseCase);

            await _UseCaseWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateUseCaseCommandResponse { Success = result, Message = result ? "UseCase created successfully" : "UseCase creation failed" };
        }
    }
}
