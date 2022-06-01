using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.CategoryQueries.GetAllCategorys
{
    public class GetAllCategoryQueryRequest : IRequest<List<GetAllCategoryQueryResponse>>
    {
    }
}
