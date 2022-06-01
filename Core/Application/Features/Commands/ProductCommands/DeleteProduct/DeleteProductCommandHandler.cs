using Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductWriteRepository _ProductWriteRepository;
        private readonly IProductReadRepository _ProductReadRepository;

        public DeleteProductCommandHandler(IProductWriteRepository orderWriteRepository, IProductReadRepository orderReadRepository)
        {
            _ProductWriteRepository = orderWriteRepository;
            _ProductReadRepository = orderReadRepository;
        }
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var Product = await _ProductReadRepository.GetByIdAsync(request.Id);

            if (Product is null)
            {
                return new DeleteProductCommandResponse
                {
                    Message = "Product is null.",
                    Success = false
                };
            }

            _ProductWriteRepository.Remove(Product);

            var result = await _ProductWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteProductCommandResponse
            {
                Message = result == true ? "Product is deleted" : "Product is not deleted",
                Success = result
            };

        }
    }
}
