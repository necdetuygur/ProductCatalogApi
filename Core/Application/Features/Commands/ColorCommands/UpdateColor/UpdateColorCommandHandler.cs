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
        private readonly IColorReadRepository _ColorReadRepository;
        private readonly IColorWriteRepository _ColorWriteRepository;

        public UpdateColorCommandHandler(IColorWriteRepository ColorWriteRepository, IColorReadRepository ColorReadRepository)
        {

            _ColorWriteRepository = ColorWriteRepository;
            _ColorReadRepository = ColorReadRepository;
        }
        public async Task<UpdateColorCommandResponse> Handle(UpdateColorCommandRequest request, CancellationToken cancellationToken)
        {
            var Color = await _ColorReadRepository.GetByIdAsync(request.Id);
            if (Color == null)
            {
                return new UpdateColorCommandResponse
                {
                    Success = false,
                    Message = "Color not found"
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

            Color.Name = request.Name ?? Color.Name;

            _ColorWriteRepository.Update(Color);

            await _ColorWriteRepository.SaveAsync();

            return new UpdateColorCommandResponse
            {
                Success = true,
                Message = "Color updated successfully"
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
