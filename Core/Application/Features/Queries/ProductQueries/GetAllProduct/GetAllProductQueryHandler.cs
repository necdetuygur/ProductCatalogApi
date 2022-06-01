﻿using Application.Repositories.ProductRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.ProductQueries.GetAllProducts
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private readonly IProductReadRepository _ProductReadRepository;

        public GetAllProductQueryHandler(IProductReadRepository ProductReadRepository)
        {
            _ProductReadRepository = ProductReadRepository;
        }
        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllProductQueryResponse> responseList = new();

            var orders = await _ProductReadRepository.Table
                .ToListAsync()
                ;

            foreach (var p in orders)
            {
                responseList.Add(new GetAllProductQueryResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Picture = p.Picture,
                    Description = p.Description,
                    CategoryId = p.CategoryId,
                    BrandId = p.BrandId,
                    ColorId = p.ColorId,
                    UseCaseId = p.UseCaseId,
                    IsOfferable = p.IsOfferable,
                    IsSold = p.IsSold
                });
            }
            return responseList;
        }
    }
}
