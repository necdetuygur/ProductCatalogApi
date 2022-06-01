using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.NecdetCommands.UpdateNecdet
{
    public class UpdateNecdetCommandValidator : AbstractValidator<UpdateNecdetCommandRequest>
    {
        public UpdateNecdetCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Col1).NotEmpty().WithMessage("Col1 is required");
            RuleFor(x => x.Col2).NotEmpty().WithMessage("Col2 is required");
            RuleFor(x => x.Col3).NotEmpty().WithMessage("Col3 is required");
        }
    }
}
