using Application.Features.Commands.$TABLECommands.Create$TABLE;
using Application.Features.Commands.$TABLECommands.Delete$TABLE;
using Application.Features.Commands.$TABLECommands.Update$TABLE;
using Application.Features.Queries.$TABLEQueries.GetAll$TABLEs;
using Application.Features.Queries.$TABLEQueries.GetById$TABLE;
using Application.Features.Queries.$TABLEQueries.Search$TABLE;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class $TABLEsController : ControllerBase
    {
        IMediator _mediator;

        public $TABLEsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAll$TABLEQueryResponse>> Get()
        {
            return await _mediator.Send(new GetAll$TABLEQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetById$TABLEQueryResponse> GetById(string id)
        {
            return await _mediator.Send(new GetById$TABLEQueryRequest { Id = id });
        }


        [HttpPost]
        public async Task<Create$TABLECommandResponse> Create$TABLE([FromBody] Create$TABLECommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<Update$TABLECommandResponse> Update$TABLE([FromForm] Update$TABLECommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<Delete$TABLECommandResponse> Delete$TABLE(string id)
        {
            return await _mediator.Send(new Delete$TABLECommandRequest { Id = id });
        }

    }
}
