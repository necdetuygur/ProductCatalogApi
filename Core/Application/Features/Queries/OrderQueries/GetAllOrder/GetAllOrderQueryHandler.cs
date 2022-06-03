using Application.Repositories.OrderRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, List<GetAllOrderQueryResponse>>
    {
        private readonly IOrderReadRepository _OrderReadRepository;

        public GetAllOrderQueryHandler(IOrderReadRepository OrderReadRepository)
        {
            _OrderReadRepository = OrderReadRepository;
        }
        public async Task<List<GetAllOrderQueryResponse>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllOrderQueryResponse> responseList = new();

            var orders = await _OrderReadRepository.Table
                .ToListAsync()
                ;

            foreach (var p in orders)
            {
                responseList.Add(new GetAllOrderQueryResponse
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
