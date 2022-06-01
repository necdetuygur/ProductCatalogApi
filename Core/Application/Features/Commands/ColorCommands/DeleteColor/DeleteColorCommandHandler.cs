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
        private readonly IColorWriteRepository _ColorWriteRepository;
        private readonly IColorReadRepository _ColorReadRepository;

        public DeleteColorCommandHandler(IColorWriteRepository orderWriteRepository, IColorReadRepository orderReadRepository)
        {
            _ColorWriteRepository = orderWriteRepository;
            _ColorReadRepository = orderReadRepository;
        }
        public async Task<DeleteColorCommandResponse> Handle(DeleteColorCommandRequest request, CancellationToken cancellationToken)
        {
            var Color = await _ColorReadRepository.GetByIdAsync(request.Id);

            if (Color is null)
            {
                return new DeleteColorCommandResponse
                {
                    Message = "Color is null.",
                    Success = false
                };
            }

            _ColorWriteRepository.Remove(Color);

            var result = await _ColorWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteColorCommandResponse
            {
                Message = result == true ? "Color is deleted" : "Color is not deleted",
                Success = result
            };

        }
    }
}
