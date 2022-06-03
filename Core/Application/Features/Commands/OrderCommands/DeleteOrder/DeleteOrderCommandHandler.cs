using Application.Repositories.OrderRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.OrderCommands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
    {
        private readonly IOrderWriteRepository _OrderWriteRepository;
        private readonly IOrderReadRepository _OrderReadRepository;

        public DeleteOrderCommandHandler(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _OrderWriteRepository = orderWriteRepository;
            _OrderReadRepository = orderReadRepository;
        }
        public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var Order = await _OrderReadRepository.GetByIdAsync(request.Id);

            if (Order is null)
            {
                return new DeleteOrderCommandResponse
                {
                    Message = "Order is null.",
                    Success = false
                };
            }

            _OrderWriteRepository.Remove(Order);

            var result = await _OrderWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteOrderCommandResponse
            {
                Message = result == true ? "Order is deleted" : "Order is not deleted",
                Success = result
            };

        }
    }
}
