using Application.Repositories.OrderRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.OrderQueries.GetByIdOrder
{
    public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQueryRequest, GetByIdOrderQueryResponse>
    {
        private readonly IOrderReadRepository _OrderReadRepository;
        private readonly IOrderWriteRepository _OrderWriteRepository;

        public GetByIdOrderQueryHandler(IOrderReadRepository OrderReadRepository, IOrderWriteRepository OrderWriteRepository)
        {
            _OrderReadRepository = OrderReadRepository;
            _OrderWriteRepository = OrderWriteRepository;
        }
        public async Task<GetByIdOrderQueryResponse> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var Order = await _OrderReadRepository.Table
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            GetByIdOrderQueryResponse response = new();
            response.Id = Order.Id;
            response.Price = Order.Price;
            response.ProductId = Order.ProductId;
            response.UserId = Order.UserId;
            response.StatusId = Order.StatusId;

            return response;
        }
    }
}
