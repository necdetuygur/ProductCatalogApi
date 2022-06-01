using Application.Features.Commands.NecdetCommands.CreateNecdet;
using Application.Features.Commands.NecdetCommands.DeleteNecdet;
using Application.Features.Commands.NecdetCommands.UpdateNecdet;
using Application.Features.Queries.NecdetQueries.GetAllNecdets;
using Application.Features.Queries.NecdetQueries.GetByIdNecdet;
using Application.Features.Queries.NecdetQueries.SearchNecdet;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NecdetsController : ControllerBase
    {
        IMediator _mediator;

        public NecdetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllNecdetQueryResponse>> Get()
        {
            return await _mediator.Send(new GetAllNecdetQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetByIdNecdetQueryResponse> GetById(string id)
        {
            return await _mediator.Send(new GetByIdNecdetQueryRequest { Id = id });
        }


        [HttpPost]
        public async Task<CreateNecdetCommandResponse> CreateNecdet([FromBody] CreateNecdetCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<UpdateNecdetCommandResponse> UpdateNecdet([FromForm] UpdateNecdetCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteNecdetCommandResponse> DeleteNecdet(string id)
        {
            return await _mediator.Send(new DeleteNecdetCommandRequest { Id = id });
        }

    }
}
