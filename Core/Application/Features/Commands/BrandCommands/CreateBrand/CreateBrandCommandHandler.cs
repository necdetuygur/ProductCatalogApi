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
        private readonly IBrandWriteRepository _brandWriteRepository;
        private readonly IBrandReadRepository _brandReadRepository;

        public CreateBrandCommandHandler(IBrandWriteRepository brandWriteRepository, IBrandReadRepository brandReadRepository)
        {
            _brandWriteRepository = brandWriteRepository;
            _brandReadRepository = brandReadRepository;
        }
        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {

            var id = Guid.NewGuid();
            Brand brand = new Brand
            {
                Id = id,
                Name = request.Name,
            };

            var result = await _brandWriteRepository.AddAsync(brand);

            await _brandWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateBrandCommandResponse { Success = result, Message = result ? "Brand is created successfully" : "Brand creation is failed" };
        }
    }
}
