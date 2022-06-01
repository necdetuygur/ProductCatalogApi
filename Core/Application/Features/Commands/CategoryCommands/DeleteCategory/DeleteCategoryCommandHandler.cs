using Application.Repositories.CategoryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _CategoryWriteRepository;
        private readonly ICategoryReadRepository _CategoryReadRepository;

        public DeleteCategoryCommandHandler(ICategoryWriteRepository orderWriteRepository, ICategoryReadRepository orderReadRepository)
        {
            _CategoryWriteRepository = orderWriteRepository;
            _CategoryReadRepository = orderReadRepository;
        }
        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var Category = await _CategoryReadRepository.GetByIdAsync(request.Id);

            if (Category is null)
            {
                return new DeleteCategoryCommandResponse
                {
                    Message = "Category is null.",
                    Success = false
                };
            }

            _CategoryWriteRepository.Remove(Category);

            var result = await _CategoryWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteCategoryCommandResponse
            {
                Message = result == true ? "Category is deleted" : "Category is not deleted",
                Success = result
            };

        }
    }
}
