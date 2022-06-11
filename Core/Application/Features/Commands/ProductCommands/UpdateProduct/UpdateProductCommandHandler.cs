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
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {

            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                return new UpdateProductCommandResponse
                {
                    Success = false,
                    Message = "Product is not found"
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

            product.Name = request.Name ?? product.Name;
            product.Price = request.Price ?? product.Price;
            product.Picture = request.Picture ?? product.Picture;
            product.Description = request.Description ?? product.Description;
            product.CategoryId = request.CategoryId ?? product.CategoryId;
            product.BrandId = request.BrandId ?? product.BrandId;
            product.ColorId = request.ColorId ?? product.ColorId;
            product.UseCaseId = request.UseCaseId ?? product.UseCaseId;
            product.IsOfferable = request.IsOfferable ?? product.IsOfferable;
            product.IsSold = request.IsSold ?? product.IsSold;
            product.UserId = request.UserId ?? product.UserId;

            _productWriteRepository.Update(product);

            await _productWriteRepository.SaveAsync();

            return new UpdateProductCommandResponse
            {
                Success = true,
                Message = "Product is updated successfully"
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
