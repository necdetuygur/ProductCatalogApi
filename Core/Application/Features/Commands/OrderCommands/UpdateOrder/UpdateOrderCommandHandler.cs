using Application.Repositories.OrderRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.OrderCommands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
    {
        private readonly IOrderReadRepository _OrderReadRepository;
        private readonly IOrderWriteRepository _OrderWriteRepository;

        public UpdateOrderCommandHandler(IOrderWriteRepository OrderWriteRepository, IOrderReadRepository OrderReadRepository)
        {

            _OrderWriteRepository = OrderWriteRepository;
            _OrderReadRepository = OrderReadRepository;
        }
        public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var Order = await _OrderReadRepository.GetByIdAsync(request.Id);
            if (Order == null)
            {
                return new UpdateOrderCommandResponse
                {
                    Success = false,
                    Message = "Order not found"
                };
            }

            if (CheckRequestIsEmpty(request))
            {
                return new UpdateOrderCommandResponse
                {
                    Success = false,
                    Message = "Request is empty"
                };
            }

            Order.Price = request.Price ?? Order.Price;
            Order.ProductId = request.ProductId ?? Order.ProductId;
            Order.UserId = request.UserId ?? Order.UserId;
            Order.StatusId = request.StatusId ?? Order.StatusId;

            _OrderWriteRepository.Update(Order);

            await _OrderWriteRepository.SaveAsync();

            return new UpdateOrderCommandResponse
            {
                Success = true,
                Message = "Order updated successfully"
            };
        }

        private bool CheckRequestIsEmpty(UpdateOrderCommandRequest request)
        {
            if (request.Price == null &&
                request.ProductId == null &&
                request.UserId == null &&
                request.StatusId == null)
            {
                return true;
            }

            return false;
        }
    }
}
