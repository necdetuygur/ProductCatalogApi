using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.NecdetQueries.GetByIdNecdet
{
    public class GetByIdNecdetQueryValidator : AbstractValidator<GetByIdNecdetQueryRequest>
    {
        public GetByIdNecdetQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
