using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required").MaximumLength(500);
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Picture).NotEmpty().WithMessage("Picture is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("CategoryId is required");
            //RuleFor(x => x.BrandId).NotEmpty().WithMessage("BrandId is required");
            //RuleFor(x => x.ColorId).NotEmpty().WithMessage("ColorId is required");
            RuleFor(x => x.UseCaseId).NotEmpty().WithMessage("UseCaseId is required");
            // RuleFor(x => x.IsOfferable).NotEmpty().WithMessage("IsOfferable is required");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
       
        }
    }
}
