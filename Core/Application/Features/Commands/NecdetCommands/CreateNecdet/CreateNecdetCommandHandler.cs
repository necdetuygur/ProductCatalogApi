using Application.Repositories.NecdetRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.NecdetCommands.CreateNecdet
{
    public class CreateNecdetCommandHandler : IRequestHandler<CreateNecdetCommandRequest, CreateNecdetCommandResponse>
    {
        private readonly INecdetWriteRepository _NecdetWriteRepository;
        private readonly INecdetReadRepository _NecdetReadRepository;

        public CreateNecdetCommandHandler(INecdetWriteRepository NecdetWriteRepository, INecdetReadRepository NecdetReadRepository)
        {
            _NecdetWriteRepository = NecdetWriteRepository;
            _NecdetReadRepository = NecdetReadRepository;
        }
        public async Task<CreateNecdetCommandResponse> Handle(CreateNecdetCommandRequest request, CancellationToken cancellationToken)
        {

            var id = Guid.NewGuid();
            Necdet Necdet = new Necdet
            {
                Id = id,
                Col1 = request.Col1,
                Col2 = request.Col2,
                Col3 = request.Col3
            };

            var result = await _NecdetWriteRepository.AddAsync(Necdet);

            await _NecdetWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateNecdetCommandResponse { Success = result, Message = result ? "Necdet created successfully" : "Necdet creation failed" };
        }
    }
}
