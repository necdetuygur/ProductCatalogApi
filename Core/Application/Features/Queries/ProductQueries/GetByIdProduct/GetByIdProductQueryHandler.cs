using Application.Repositories.ProductRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.ProductQueries.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductReadRepository _ProductReadRepository;
        private readonly IProductWriteRepository _ProductWriteRepository;

        public GetByIdProductQueryHandler(IProductReadRepository ProductReadRepository, IProductWriteRepository ProductWriteRepository)
        {
            _ProductReadRepository = ProductReadRepository;
            _ProductWriteRepository = ProductWriteRepository;
        }
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var Product = await _ProductReadRepository.Table
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            GetByIdProductQueryResponse response = new();
            response.Id = Product.Id;
            response.Name = Product.Name;
            response.Price = Product.Price;
            response.Picture = Product.Picture;
            response.Description = Product.Description;
            response.CategoryId = Product.CategoryId;
            response.UserId = Product.UserId;
            response.BrandId = Product.BrandId;
            response.ColorId = Product.ColorId;
            response.UseCaseId = Product.UseCaseId;
            response.IsOfferable = Product.IsOfferable;
            response.IsSold = Product.IsSold;

            return response;
        }
    }
}
