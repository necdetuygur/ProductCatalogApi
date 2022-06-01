﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Picture).NotEmpty().WithMessage("Picture is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("CategoryId is required");
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("BrandId is required");
            RuleFor(x => x.ColorId).NotEmpty().WithMessage("ColorId is required");
            RuleFor(x => x.UseCaseId).NotEmpty().WithMessage("UseCaseId is required");
            RuleFor(x => x.IsOfferable).NotEmpty().WithMessage("IsOfferable is required");
            // RuleFor(x => x.IsSold).NotEmpty().WithMessage("IsSold is required");
        }
    }
}