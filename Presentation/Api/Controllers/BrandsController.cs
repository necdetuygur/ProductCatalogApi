using Application.Features.Commands.BrandCommands.CreateBrand;
using Application.Features.Commands.BrandCommands.DeleteBrand;
using Application.Features.Commands.BrandCommands.UpdateBrand;
using Application.Features.Queries.BrandQueries.GetAllBrands;
using Application.Features.Queries.BrandQueries.GetByIdBrand;
using Application.Features.Queries.BrandQueries.SearchBrand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllBrandQueryResponse>> GetBrands()
        {
            return await _mediator.Send(new GetAllBrandQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetByIdBrandQueryResponse> GetById(string id)
        {
            return await _mediator.Send(new GetByIdBrandQueryRequest { Id = id });
        }


        //[HttpPost]
        //public async Task<CreateBrandCommandResponse> CreateBrand([FromBody] CreateBrandCommandRequest request)
        //{
        //    return await _mediator.Send(request);
        //}

        //[HttpPut]
        //public async Task<UpdateBrandCommandResponse> UpdateBrand([FromForm] UpdateBrandCommandRequest request)
        //{
        //    return await _mediator.Send(request);
        //}

        //[HttpDelete("{id}")]
        //public async Task<DeleteBrandCommandResponse> DeleteBrand(string id)
        //{
        //    return await _mediator.Send(new DeleteBrandCommandRequest { Id = id });
        //}

    }
}
