using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.UseCaseCommands.CreateUseCase
{
    public class CreateUseCaseCommandValidator : AbstractValidator<CreateUseCaseCommandRequest>
    {
        public CreateUseCaseCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
