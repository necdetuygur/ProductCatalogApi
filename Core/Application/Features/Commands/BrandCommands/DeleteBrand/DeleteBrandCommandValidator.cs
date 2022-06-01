using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.BrandCommands.DeleteBrand
{
    public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommandRequest>
    {
        public DeleteBrandCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
