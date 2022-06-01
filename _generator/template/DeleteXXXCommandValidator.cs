using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.$TABLECommands.Delete$TABLE
{
    public class Delete$TABLECommandValidator : AbstractValidator<Delete$TABLECommandRequest>
    {
        public Delete$TABLECommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
