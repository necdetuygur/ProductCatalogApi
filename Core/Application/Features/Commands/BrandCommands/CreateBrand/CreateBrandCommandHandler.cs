using Application.Repositories.BrandRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.BrandCommands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
    {
        private readonly IBrandWriteRepository _BrandWriteRepository;
        private readonly IBrandReadRepository _BrandReadRepository;

        public CreateBrandCommandHandler(IBrandWriteRepository BrandWriteRepository, IBrandReadRepository BrandReadRepository)
        {
            _BrandWriteRepository = BrandWriteRepository;
            _BrandReadRepository = BrandReadRepository;
        }
        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {

            var id = Guid.NewGuid();
            Brand Brand = new Brand
            {
                Id = id,
                Name = request.Name,
            };

            var result = await _BrandWriteRepository.AddAsync(Brand);

            await _BrandWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateBrandCommandResponse { Success = result, Message = result ? "Brand created successfully" : "Brand creation failed" };
        }
    }
}
