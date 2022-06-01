using Application.Repositories.ColorRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ColorCommands.CreateColor
{
    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommandRequest, CreateColorCommandResponse>
    {
        private readonly IColorWriteRepository _ColorWriteRepository;
        private readonly IColorReadRepository _ColorReadRepository;

        public CreateColorCommandHandler(IColorWriteRepository ColorWriteRepository, IColorReadRepository ColorReadRepository)
        {
            _ColorWriteRepository = ColorWriteRepository;
            _ColorReadRepository = ColorReadRepository;
        }
        public async Task<CreateColorCommandResponse> Handle(CreateColorCommandRequest request, CancellationToken cancellationToken)
        {

            var id = Guid.NewGuid();
            Color Color = new Color
            {
                Id = id,
                Name = request.Name
            };

            var result = await _ColorWriteRepository.AddAsync(Color);

            await _ColorWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateColorCommandResponse { Success = result, Message = result ? "Color created successfully" : "Color creation failed" };
        }
    }
}
