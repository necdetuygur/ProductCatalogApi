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
        private readonly IColorWriteRepository _colorWriteRepository;
        private readonly IColorReadRepository _colorReadRepository;

        public CreateColorCommandHandler(IColorWriteRepository colorWriteRepository, IColorReadRepository colorReadRepository)
        {
            _colorWriteRepository = colorWriteRepository;
            _colorReadRepository = colorReadRepository;
        }
        public async Task<CreateColorCommandResponse> Handle(CreateColorCommandRequest request, CancellationToken cancellationToken)
        {

            var id = Guid.NewGuid();
            Color color = new Color
            {
                Id = id,
                Name = request.Name
            };

            var result = await _colorWriteRepository.AddAsync(color);

            await _colorWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateColorCommandResponse { Success = result, Message = result ? "Color is created successfully" : "Color creation is failed" };
        }
    }
}
