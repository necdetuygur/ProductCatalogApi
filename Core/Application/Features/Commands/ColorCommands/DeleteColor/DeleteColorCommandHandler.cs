using Application.Repositories.ColorRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ColorCommands.DeleteColor
{
    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommandRequest, DeleteColorCommandResponse>
    {
        private readonly IColorWriteRepository _colorWriteRepository;
        private readonly IColorReadRepository _colorReadRepository;

        public DeleteColorCommandHandler(IColorWriteRepository colorWriteRepository, IColorReadRepository colorReadRepository)
        {
            _colorWriteRepository = colorWriteRepository;
            _colorReadRepository = colorReadRepository;
        }
        public async Task<DeleteColorCommandResponse> Handle(DeleteColorCommandRequest request, CancellationToken cancellationToken)
        {
            var color = await _colorReadRepository.GetByIdAsync(request.Id);

            if (color is null)
            {
                return new DeleteColorCommandResponse
                {
                    Message = "Color is null.",
                    Success = false
                };
            }

            _colorWriteRepository.Remove(color);

            var result = await _colorWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteColorCommandResponse
            {
                Message = result == true ? "Color is deleted" : "Color is not deleted",
                Success = result
            };

        }
    }
}
