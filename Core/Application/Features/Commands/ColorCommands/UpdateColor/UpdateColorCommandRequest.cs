using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ColorCommands.UpdateColor
{
    public class UpdateColorCommandRequest : IRequest<UpdateColorCommandResponse>
    {
        public string Id { get; set; }
        public string? Name { get; set; }
    }
}
