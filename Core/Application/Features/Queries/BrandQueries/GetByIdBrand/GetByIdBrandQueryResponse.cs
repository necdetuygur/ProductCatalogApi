using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.BrandQueries.GetByIdBrand
{
    public class GetByIdBrandQueryResponse
    {
        public Guid Id;
        public string Name { get; set; }
    }
}
