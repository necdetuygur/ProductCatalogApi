using Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductReadRepository _ProductReadRepository;
        private readonly IProductWriteRepository _ProductWriteRepository;

        public UpdateProductCommandHandler(IProductWriteRepository ProductWriteRepository, IProductReadRepository ProductReadRepository)
        {

            _ProductWriteRepository = ProductWriteRepository;
            _ProductReadRepository = ProductReadRepository;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var Product = await _ProductReadRepository.GetByIdAsync(request.Id);
            if (Product == null)
            {
                return new UpdateProductCommandResponse
                {
                    Success = false,
                    Message = "Product not found"
                };
            }

            if (CheckRequestIsEmpty(request))
            {
                return new UpdateProductCommandResponse
                {
                    Success = false,
                    Message = "Request is empty"
                };
            }

            Product.Name = request.Name ?? Product.Name;
            Product.Price = request.Price ?? Product.Price;
            Product.Picture = request.Picture ?? Product.Picture;
            Product.Description = request.Description ?? Product.Description;
            Product.CategoryId = request.CategoryId ?? Product.CategoryId;
            Product.BrandId = request.BrandId ?? Product.BrandId;
            Product.ColorId = request.ColorId ?? Product.ColorId;
            Product.UseCaseId = request.UseCaseId ?? Product.UseCaseId;
            Product.IsOfferable = request.IsOfferable ?? Product.IsOfferable;
            Product.IsSold = request.IsSold ?? Product.IsSold;

            _ProductWriteRepository.Update(Product);

            await _ProductWriteRepository.SaveAsync();

            return new UpdateProductCommandResponse
            {
                Success = true,
                Message = "Product updated successfully"
            };
        }

        private bool CheckRequestIsEmpty(UpdateProductCommandRequest request)
        {
            if (request.Name == null &&
                request.Price == null &&
                request.Picture == null &&
                request.Description == null &&
                request.CategoryId == null &&
                request.BrandId == null &&
                request.ColorId == null &&
                request.UseCaseId == null &&
                request.IsOfferable == null &&
                request.IsSold == null)
            {
                return true;
            }

            return false;
        }
    }
}
