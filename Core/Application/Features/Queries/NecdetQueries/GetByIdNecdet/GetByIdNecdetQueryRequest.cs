using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.NecdetQueries.GetByIdNecdet
{
    public class GetByIdNecdetQueryRequest : IRequest<GetByIdNecdetQueryResponse>
    {
        public string Id { get; set; }
    }
}
