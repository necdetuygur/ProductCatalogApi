using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.$TABLEQueries.GetById$TABLE
{
    public class GetById$TABLEQueryValidator : AbstractValidator<GetById$TABLEQueryRequest>
    {
        public GetById$TABLEQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
