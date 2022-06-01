using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.NecdetQueries.GetAllNecdets
{
    public class GetAllNecdetQueryResponse
    {
        public Guid Id { get; set; }
        public int Col1 { get; set; }
        public int Col2 { get; set; }
        public int Col3 { get; set; }
    }
}
