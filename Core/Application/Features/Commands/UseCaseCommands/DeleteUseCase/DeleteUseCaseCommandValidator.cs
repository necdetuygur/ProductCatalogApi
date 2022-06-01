using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.UseCaseCommands.DeleteUseCase
{
    public class DeleteUseCaseCommandValidator : AbstractValidator<DeleteUseCaseCommandRequest>
    {
        public DeleteUseCaseCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
