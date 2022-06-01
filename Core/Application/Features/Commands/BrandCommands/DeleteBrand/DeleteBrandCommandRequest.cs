using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.BrandCommands.DeleteBrand
{
    public class DeleteBrandCommandRequest : IRequest<DeleteBrandCommandResponse>
    {
        public string Id;
    }
}
