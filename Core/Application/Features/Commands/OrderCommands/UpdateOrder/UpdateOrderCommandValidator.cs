using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.OrderCommands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommandRequest>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            //RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            //RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required");
            //RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
            //RuleFor(x => x.StatusId).NotEmpty().WithMessage("StatusId is required");
        }
    }
}
