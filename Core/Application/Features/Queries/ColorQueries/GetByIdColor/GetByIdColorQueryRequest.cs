using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.ColorQueries.GetByIdColor
{
    public class GetByIdColorQueryRequest : IRequest<GetByIdColorQueryResponse>
    {
        public string Id { get; set; }
    }
}
