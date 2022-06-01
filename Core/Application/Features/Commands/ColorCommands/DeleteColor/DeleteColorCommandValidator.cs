using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ColorCommands.DeleteColor
{
    public class DeleteColorCommandValidator : AbstractValidator<DeleteColorCommandRequest>
    {
        public DeleteColorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
