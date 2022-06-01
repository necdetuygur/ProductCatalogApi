using Application.Repositories.$TABLERepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.$TABLECommands.Create$TABLE
{
    public class Create$TABLECommandHandler : IRequestHandler<Create$TABLECommandRequest, Create$TABLECommandResponse>
    {
        private readonly I$TABLEWriteRepository _$TABLEWriteRepository;
        private readonly I$TABLEReadRepository _$TABLEReadRepository;

        public Create$TABLECommandHandler(I$TABLEWriteRepository $TABLEWriteRepository, I$TABLEReadRepository $TABLEReadRepository)
        {
            _$TABLEWriteRepository = $TABLEWriteRepository;
            _$TABLEReadRepository = $TABLEReadRepository;
        }
        public async Task<Create$TABLECommandResponse> Handle(Create$TABLECommandRequest request, CancellationToken cancellationToken)
        {

            var id = Guid.NewGuid();
            $TABLE $TABLE = new $TABLE
            {
                Id = id,
                Col1 = request.Col1,
                Col2 = request.Col2,
                Col3 = request.Col3
            };

            var result = await _$TABLEWriteRepository.AddAsync($TABLE);

            await _$TABLEWriteRepository.SaveAsync();//== 1 ? true : false;

            return new Create$TABLECommandResponse { Success = result, Message = result ? "$TABLE created successfully" : "$TABLE creation failed" };
        }
    }
}
