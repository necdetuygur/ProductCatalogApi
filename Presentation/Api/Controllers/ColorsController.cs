using Application.Features.Commands.ColorCommands.CreateColor;
using Application.Features.Commands.ColorCommands.DeleteColor;
using Application.Features.Commands.ColorCommands.UpdateColor;
using Application.Features.Queries.ColorQueries.GetAllColors;
using Application.Features.Queries.ColorQueries.GetByIdColor;
using Application.Features.Queries.ColorQueries.SearchColor;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IMediator _mediator;

        public ColorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllColorQueryResponse>> GetColors()
        {
            return await _mediator.Send(new GetAllColorQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetByIdColorQueryResponse> GetById(string id)
        {
            return await _mediator.Send(new GetByIdColorQueryRequest { Id = id });
        }


        //[HttpPost]
        //public async Task<CreateColorCommandResponse> CreateColor([FromBody] CreateColorCommandRequest request)
        //{
        //    return await _mediator.Send(request);
        //}

        //[HttpPut]
        //public async Task<UpdateColorCommandResponse> UpdateColor([FromForm] UpdateColorCommandRequest request)
        //{
        //    return await _mediator.Send(request);
        //}

        //[HttpDelete("{id}")]
        //public async Task<DeleteColorCommandResponse> DeleteColor(string id)
        //{
        //    return await _mediator.Send(new DeleteColorCommandRequest { Id = id });
        //}

    }
}
