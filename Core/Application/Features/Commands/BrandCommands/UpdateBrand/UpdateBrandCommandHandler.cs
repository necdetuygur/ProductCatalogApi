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
        private readonly IBrandReadRepository _BrandReadRepository;
        private readonly IBrandWriteRepository _BrandWriteRepository;

        public UpdateBrandCommandHandler(IBrandWriteRepository BrandWriteRepository, IBrandReadRepository BrandReadRepository)
        {

            _BrandWriteRepository = BrandWriteRepository;
            _BrandReadRepository = BrandReadRepository;
        }
        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var Brand = await _BrandReadRepository.GetByIdAsync(request.Id);
            if (Brand == null)
            {
                return new UpdateBrandCommandResponse
                {
                    Success = false,
                    Message = "Brand not found"
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

            Brand.Name = request.Name ?? Brand.Name;

            _BrandWriteRepository.Update(Brand);

            await _BrandWriteRepository.SaveAsync();

            return new UpdateBrandCommandResponse
            {
                Success = true,
                Message = "Brand updated successfully"
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
