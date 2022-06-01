using Application.Repositories.ProductRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _ProductWriteRepository;
        private readonly IProductReadRepository _ProductReadRepository;

        public CreateProductCommandHandler(IProductWriteRepository ProductWriteRepository, IProductReadRepository ProductReadRepository)
        {
            _ProductWriteRepository = ProductWriteRepository;
            _ProductReadRepository = ProductReadRepository;
        }
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            var id = Guid.NewGuid();
            Product Product = new Product
            {
                Id = id,
                Name = request.Name,
                Price = request.Price,
                Picture = request.Picture,
                Description = request.Description,
                CategoryId = request.CategoryId,
                BrandId = request.BrandId,
                ColorId = request.ColorId,
                UseCaseId = request.UseCaseId,
                IsOfferable = request.IsOfferable,
                IsSold = request.IsSold
            };

            var result = await _ProductWriteRepository.AddAsync(Product);

            await _ProductWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateProductCommandResponse { Success = result, Message = result ? "Product created successfully" : "Product creation failed" };
        }
    }
}
