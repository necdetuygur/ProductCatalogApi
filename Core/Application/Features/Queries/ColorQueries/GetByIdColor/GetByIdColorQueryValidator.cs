using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.ColorQueries.GetByIdColor
{
    public class GetByIdColorQueryValidator : AbstractValidator<GetByIdColorQueryRequest>
    {
        public GetByIdColorQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
