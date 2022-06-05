using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ColorCommands.CreateColor
{
    public class CreateColorCommandRequest : IRequest<CreateColorCommandResponse>
    {
        public string Name { get; set; }
    }
}
