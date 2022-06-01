using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.$TABLECommands.Update$TABLE
{
    public class Update$TABLECommandRequest : IRequest<Update$TABLECommandResponse>
    {
        public string Id { get; set; }
        public int? Col1 { get; set; }
        public int? Col2 { get; set; }
        public int? Col3 { get; set; }
    }
}
