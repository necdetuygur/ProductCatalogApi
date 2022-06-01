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
        private readonly IBrandWriteRepository _BrandWriteRepository;
        private readonly IBrandReadRepository _BrandReadRepository;

        public DeleteBrandCommandHandler(IBrandWriteRepository orderWriteRepository, IBrandReadRepository orderReadRepository)
        {
            _BrandWriteRepository = orderWriteRepository;
            _BrandReadRepository = orderReadRepository;
        }
        public async Task<DeleteBrandCommandResponse> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var Brand = await _BrandReadRepository.GetByIdAsync(request.Id);

            if (Brand is null)
            {
                return new DeleteBrandCommandResponse
                {
                    Message = "Brand is null.",
                    Success = false
                };
            }

            _BrandWriteRepository.Remove(Brand);

            var result = await _BrandWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteBrandCommandResponse
            {
                Message = result == true ? "Brand is deleted" : "Brand is not deleted",
                Success = result
            };

        }
    }
}
