using Application.Repositories.$TABLERepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.$TABLECommands.Delete$TABLE
{
    public class Delete$TABLECommandHandler : IRequestHandler<Delete$TABLECommandRequest, Delete$TABLECommandResponse>
    {
        private readonly I$TABLEWriteRepository _$TABLEWriteRepository;
        private readonly I$TABLEReadRepository _$TABLEReadRepository;

        public Delete$TABLECommandHandler(I$TABLEWriteRepository orderWriteRepository, I$TABLEReadRepository orderReadRepository)
        {
            _$TABLEWriteRepository = orderWriteRepository;
            _$TABLEReadRepository = orderReadRepository;
        }
        public async Task<Delete$TABLECommandResponse> Handle(Delete$TABLECommandRequest request, CancellationToken cancellationToken)
        {
            var $TABLE = await _$TABLEReadRepository.GetByIdAsync(request.Id);

            if ($TABLE is null)
            {
                return new Delete$TABLECommandResponse
                {
                    Message = "$TABLE is null.",
                    Success = false
                };
            }

            _$TABLEWriteRepository.Remove($TABLE);

            var result = await _$TABLEWriteRepository.SaveAsync() == 1 ? true : false;

            return new Delete$TABLECommandResponse
            {
                Message = result == true ? "$TABLE is deleted" : "$TABLE is not deleted",
                Success = result
            };

        }
    }
}
