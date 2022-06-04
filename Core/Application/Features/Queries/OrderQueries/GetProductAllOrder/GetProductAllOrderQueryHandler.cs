﻿using Application.Repositories.OrderRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.OrderQueries.GetProductAllOrder
{
    public class GetProductAllOrderQueryHandler : IRequestHandler<GetProductAllOrderQueryRequest, List<GetProductAllOrderQueryResponse>>
    {
        private readonly IOrderReadRepository _OrderReadRepository;

        public GetProductAllOrderQueryHandler(IOrderReadRepository OrderReadRepository)
        {
            _OrderReadRepository = OrderReadRepository;
        }
        public async Task<List<GetProductAllOrderQueryResponse>> Handle(GetProductAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetProductAllOrderQueryResponse> responseList = new();

            var orders = await _OrderReadRepository.Table.Where(p => p.ProductId == Guid.Parse(request.ProductId)).ToListAsync();

            foreach (var p in orders)
            {
                responseList.Add(new GetProductAllOrderQueryResponse
                {
                    Id = p.Id,
                    Price = p.Price,
                    ProductId = p.ProductId,
                    UserId = p.UserId,
                    StatusId = p.StatusId
                });
            }
            return responseList;
        }
    }
}
