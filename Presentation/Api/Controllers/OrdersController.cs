using Application.Features.Commands.OrderCommands.CreateOrder;
using Application.Features.Commands.OrderCommands.DeleteOrder;
using Application.Features.Commands.OrderCommands.UpdateOrder;
using Application.Features.Queries.OrderQueries.GetAllOrders;
using Application.Features.Queries.OrderQueries.GetByIdOrder;
using Application.Features.Queries.OrderQueries.SearchOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllOrderQueryResponse>> Get()
        {
            return await _mediator.Send(new GetAllOrderQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetByIdOrderQueryResponse> GetById(string id)
        {
            return await _mediator.Send(new GetByIdOrderQueryRequest { Id = id });
        }


        [HttpPost]
        public async Task<CreateOrderCommandResponse> CreateOrder([FromBody] CreateOrderCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<UpdateOrderCommandResponse> UpdateOrder([FromForm] UpdateOrderCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteOrderCommandResponse> DeleteOrder(string id)
        {
            return await _mediator.Send(new DeleteOrderCommandRequest { Id = id });
        }

    }
}
