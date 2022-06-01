using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.NecdetCommands.UpdateNecdet
{
    public class UpdateNecdetCommandRequest : IRequest<UpdateNecdetCommandResponse>
    {
        public string Id { get; set; }
        public int? Col1 { get; set; }
        public int? Col2 { get; set; }
        public int? Col3 { get; set; }
    }
}
