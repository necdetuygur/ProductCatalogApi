using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.NecdetCommands.DeleteNecdet
{
    public class DeleteNecdetCommandValidator : AbstractValidator<DeleteNecdetCommandRequest>
    {
        public DeleteNecdetCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
