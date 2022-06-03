using Application.Repositories.OrderRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.OrderCommands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderWriteRepository _OrderWriteRepository;
        private readonly IOrderReadRepository _OrderReadRepository;

        public CreateOrderCommandHandler(IOrderWriteRepository OrderWriteRepository, IOrderReadRepository OrderReadRepository)
        {
            _OrderWriteRepository = OrderWriteRepository;
            _OrderReadRepository = OrderReadRepository;
        }
        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {

            var id = Guid.NewGuid();
            Order Order = new Order
            {
                Id = id,
                Price = request.Price,
                ProductId = request.ProductId,
                UserId = request.UserId,
                StatusId = request.StatusId
            };

            var result = await _OrderWriteRepository.AddAsync(Order);

            await _OrderWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateOrderCommandResponse { Success = result, Message = result ? "Order created successfully" : "Order creation failed" };
        }
    }
}
