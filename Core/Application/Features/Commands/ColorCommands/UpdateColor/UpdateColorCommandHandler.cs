using Application.Repositories.ColorRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ColorCommands.UpdateColor
{
    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommandRequest, UpdateColorCommandResponse>
    {
        private readonly IColorReadRepository _colorReadRepository;
        private readonly IColorWriteRepository _colorWriteRepository;

        public UpdateColorCommandHandler(IColorWriteRepository colorWriteRepository, IColorReadRepository colorReadRepository)
        {

            _colorWriteRepository = colorWriteRepository;
            _colorReadRepository = colorReadRepository;
        }
        public async Task<UpdateColorCommandResponse> Handle(UpdateColorCommandRequest request, CancellationToken cancellationToken)
        {
            var color = await _colorReadRepository.GetByIdAsync(request.Id);
            if (color == null)
            {
                return new UpdateColorCommandResponse
                {
                    Success = false,
                    Message = "Color is not found"
                };
            }

            if (CheckRequestIsEmpty(request))
            {
                return new UpdateColorCommandResponse
                {
                    Success = false,
                    Message = "Request is empty"
                };
            }

            color.Name = request.Name ?? color.Name;

            _colorWriteRepository.Update(color);

            await _colorWriteRepository.SaveAsync();

            return new UpdateColorCommandResponse
            {
                Success = true,
                Message = "Color is updated successfully"
            };
        }

        private bool CheckRequestIsEmpty(UpdateColorCommandRequest request)
        {
            if (request.Name == null)
            {
                return true;
            }

            return false;
        }
    }
}
