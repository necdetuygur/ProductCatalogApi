using Application.Repositories.NecdetRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.NecdetCommands.DeleteNecdet
{
    public class DeleteNecdetCommandHandler : IRequestHandler<DeleteNecdetCommandRequest, DeleteNecdetCommandResponse>
    {
        private readonly INecdetWriteRepository _NecdetWriteRepository;
        private readonly INecdetReadRepository _NecdetReadRepository;

        public DeleteNecdetCommandHandler(INecdetWriteRepository orderWriteRepository, INecdetReadRepository orderReadRepository)
        {
            _NecdetWriteRepository = orderWriteRepository;
            _NecdetReadRepository = orderReadRepository;
        }
        public async Task<DeleteNecdetCommandResponse> Handle(DeleteNecdetCommandRequest request, CancellationToken cancellationToken)
        {
            var Necdet = await _NecdetReadRepository.GetByIdAsync(request.Id);

            if (Necdet is null)
            {
                return new DeleteNecdetCommandResponse
                {
                    Message = "Necdet is null.",
                    Success = false
                };
            }

            _NecdetWriteRepository.Remove(Necdet);

            var result = await _NecdetWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteNecdetCommandResponse
            {
                Message = result == true ? "Necdet is deleted" : "Necdet is not deleted",
                Success = result
            };

        }
    }
}
