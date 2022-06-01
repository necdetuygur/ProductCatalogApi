using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.$TABLEQueries.GetById$TABLE
{
    public class GetById$TABLEQueryRequest : IRequest<GetById$TABLEQueryResponse>
    {
        public string Id { get; set; }
    }
}
