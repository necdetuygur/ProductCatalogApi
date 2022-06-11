using Application.Repositories.BrandRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.BrandCommands.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommandRequest, DeleteBrandCommandResponse>
    {
        private readonly IBrandWriteRepository _brandWriteRepository;
        private readonly IBrandReadRepository _brandReadRepository;

        public DeleteBrandCommandHandler(IBrandWriteRepository brandWriteRepository, IBrandReadRepository brandReadRepository)
        {
            _brandWriteRepository = brandWriteRepository;
            _brandReadRepository = brandReadRepository;
        }
        public async Task<DeleteBrandCommandResponse> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brand = await _brandReadRepository.GetByIdAsync(request.Id);

            if (brand is null)
            {
                return new DeleteBrandCommandResponse
                {
                    Message = "Brand is null.",
                    Success = false
                };
            }

            _brandWriteRepository.Remove(brand);

            var result = await _brandWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteBrandCommandResponse
            {
                Message = result == true ? "Brand is deleted" : "Brand is not deleted",
                Success = result
            };

        }
    }
}
