using Application.Repositories.NecdetRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.NecdetCommands.UpdateNecdet
{
    public class UpdateNecdetCommandHandler : IRequestHandler<UpdateNecdetCommandRequest, UpdateNecdetCommandResponse>
    {
        private readonly INecdetReadRepository _NecdetReadRepository;
        private readonly INecdetWriteRepository _NecdetWriteRepository;

        public UpdateNecdetCommandHandler(INecdetWriteRepository NecdetWriteRepository, INecdetReadRepository NecdetReadRepository)
        {

            _NecdetWriteRepository = NecdetWriteRepository;
            _NecdetReadRepository = NecdetReadRepository;
        }
        public async Task<UpdateNecdetCommandResponse> Handle(UpdateNecdetCommandRequest request, CancellationToken cancellationToken)
        {
            var Necdet = await _NecdetReadRepository.GetByIdAsync(request.Id);
            if (Necdet == null)
            {
                return new UpdateNecdetCommandResponse
                {
                    Success = false,
                    Message = "Necdet not found"
                };
            }

            if (CheckRequestIsEmpty(request))
            {
                return new UpdateNecdetCommandResponse
                {
                    Success = false,
                    Message = "Request is empty"
                };
            }

            Necdet.Col1 = request.Col1 ?? Necdet.Col1;
            Necdet.Col2 = request.Col2 ?? Necdet.Col2;
            Necdet.Col3 = request.Col3 ?? Necdet.Col3;

            _NecdetWriteRepository.Update(Necdet);

            await _NecdetWriteRepository.SaveAsync();

            return new UpdateNecdetCommandResponse
            {
                Success = true,
                Message = "Necdet updated successfully"
            };
        }

        private bool CheckRequestIsEmpty(UpdateNecdetCommandRequest request)
        {
            if (request.Col1 == null &&
                request.Col2 == null &&
                request.Col3 == null)
            {
                return true;
            }

            return false;
        }
    }
}
