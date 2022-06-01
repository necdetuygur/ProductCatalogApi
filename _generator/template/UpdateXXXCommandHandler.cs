using Application.Repositories.$TABLERepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.$TABLECommands.Update$TABLE
{
    public class Update$TABLECommandHandler : IRequestHandler<Update$TABLECommandRequest, Update$TABLECommandResponse>
    {
        private readonly I$TABLEReadRepository _$TABLEReadRepository;
        private readonly I$TABLEWriteRepository _$TABLEWriteRepository;

        public Update$TABLECommandHandler(I$TABLEWriteRepository $TABLEWriteRepository, I$TABLEReadRepository $TABLEReadRepository)
        {

            _$TABLEWriteRepository = $TABLEWriteRepository;
            _$TABLEReadRepository = $TABLEReadRepository;
        }
        public async Task<Update$TABLECommandResponse> Handle(Update$TABLECommandRequest request, CancellationToken cancellationToken)
        {
            var $TABLE = await _$TABLEReadRepository.GetByIdAsync(request.Id);
            if ($TABLE == null)
            {
                return new Update$TABLECommandResponse
                {
                    Success = false,
                    Message = "$TABLE not found"
                };
            }

            if (CheckRequestIsEmpty(request))
            {
                return new Update$TABLECommandResponse
                {
                    Success = false,
                    Message = "Request is empty"
                };
            }

            $TABLE.Col1 = request.Col1 ?? $TABLE.Col1;
            $TABLE.Col2 = request.Col2 ?? $TABLE.Col2;
            $TABLE.Col3 = request.Col3 ?? $TABLE.Col3;

            _$TABLEWriteRepository.Update($TABLE);

            await _$TABLEWriteRepository.SaveAsync();

            return new Update$TABLECommandResponse
            {
                Success = true,
                Message = "$TABLE updated successfully"
            };
        }

        private bool CheckRequestIsEmpty(Update$TABLECommandRequest request)
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
