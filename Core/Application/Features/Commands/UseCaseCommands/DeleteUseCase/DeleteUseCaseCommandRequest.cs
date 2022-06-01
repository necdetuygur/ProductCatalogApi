using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.UseCaseCommands.DeleteUseCase
{
    public class DeleteUseCaseCommandRequest : IRequest<DeleteUseCaseCommandResponse>
    {
        public string Id;
    }
}
