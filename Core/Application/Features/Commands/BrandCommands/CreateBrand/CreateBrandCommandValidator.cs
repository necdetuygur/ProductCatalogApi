using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.BrandCommands.CreateBrand
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommandRequest>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
