using Application.Features.Commands.UserCommands.CreateUser;
using Application.Features.Commands.UserCommands.DeleteUser;
using Application.Features.Commands.UserCommands.UpdateUser;
using Application.Features.Queries.UserQueries.GetAllUsers;
using Application.Features.Queries.UserQueries.GetByIdUser;
using Application.Features.Queries.UserQueries.SearchUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllUserQueryResponse>> Get()
        {
            return await _mediator.Send(new GetAllUserQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetByIdUserQueryResponse> GetById(string id)
        {
            return await _mediator.Send(new GetByIdUserQueryRequest { Id = id });
        }


        [HttpPost]
        public async Task<CreateUserCommandResponse> CreateUser([FromBody] CreateUserCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<UpdateUserCommandResponse> UpdateUser([FromForm] UpdateUserCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteUserCommandResponse> DeleteUser(string id)
        {
            return await _mediator.Send(new DeleteUserCommandRequest { Id = id });
        }

    }
}
