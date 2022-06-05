using Application.Features.Commands.UseCaseCommands.CreateUseCase;
using Application.Features.Commands.UseCaseCommands.DeleteUseCase;
using Application.Features.Commands.UseCaseCommands.UpdateUseCase;
using Application.Features.Queries.UseCaseQueries.GetAllUseCases;
using Application.Features.Queries.UseCaseQueries.GetByIdUseCase;
using Application.Features.Queries.UseCaseQueries.SearchUseCase;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCasesController : ControllerBase
    {
        IMediator _mediator;

        public UseCasesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllUseCaseQueryResponse>> GetUseCases()
        {
            return await _mediator.Send(new GetAllUseCaseQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetByIdUseCaseQueryResponse> GetById(string id)
        {
            return await _mediator.Send(new GetByIdUseCaseQueryRequest { Id = id });
        }


        //[HttpPost]
        //public async Task<CreateUseCaseCommandResponse> CreateUseCase([FromBody] CreateUseCaseCommandRequest request)
        //{
        //    return await _mediator.Send(request);
        //}

        //[HttpPut]
        //public async Task<UpdateUseCaseCommandResponse> UpdateUseCase([FromForm] UpdateUseCaseCommandRequest request)
        //{
        //    return await _mediator.Send(request);
        //}

        //[HttpDelete("{id}")]
        //public async Task<DeleteUseCaseCommandResponse> DeleteUseCase(string id)
        //{
        //    return await _mediator.Send(new DeleteUseCaseCommandRequest { Id = id });
        //}

    }
}
