using Application.Repositories.BrandRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.BrandCommands.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        private readonly IBrandReadRepository _brandReadRepository;
        private readonly IBrandWriteRepository _brandWriteRepository;

        public UpdateBrandCommandHandler(IBrandWriteRepository brandWriteRepository, IBrandReadRepository brandReadRepository)
        {

            _brandWriteRepository = brandWriteRepository;
            _brandReadRepository = brandReadRepository;
        }
        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brand = await _brandReadRepository.GetByIdAsync(request.Id);
            if (brand == null)
            {
                return new UpdateBrandCommandResponse
                {
                    Success = false,
                    Message = "Brand is not found"
                };
            }

            if (CheckRequestIsEmpty(request))
            {
                return new UpdateBrandCommandResponse
                {
                    Success = false,
                    Message = "Request is empty"
                };
            }

            brand.Name = request.Name ?? brand.Name;

            _brandWriteRepository.Update(brand);

            await _brandWriteRepository.SaveAsync();

            return new UpdateBrandCommandResponse
            {
                Success = true,
                Message = "Brand is updated successfully"
            };
        }

        private bool CheckRequestIsEmpty(UpdateBrandCommandRequest request)
        {
            if (request.Name == null)
            {
                return true;
            }

            return false;
        }
    }
}
