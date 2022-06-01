using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.ColorQueries.GetAllColors
{
    public class GetAllColorQueryRequest : IRequest<List<GetAllColorQueryResponse>>
    {
    }
}
