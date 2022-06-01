using Application.Repositories.CategoryRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryReadRepository _CategoryReadRepository;
        private readonly ICategoryWriteRepository _CategoryWriteRepository;

        public UpdateCategoryCommandHandler(ICategoryWriteRepository CategoryWriteRepository, ICategoryReadRepository CategoryReadRepository)
        {

            _CategoryWriteRepository = CategoryWriteRepository;
            _CategoryReadRepository = CategoryReadRepository;
        }
        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var Category = await _CategoryReadRepository.GetByIdAsync(request.Id);
            if (Category == null)
            {
                return new UpdateCategoryCommandResponse
                {
                    Success = false,
                    Message = "Category not found"
                };
            }

            if (CheckRequestIsEmpty(request))
            {
                return new UpdateCategoryCommandResponse
                {
                    Success = false,
                    Message = "Request is empty"
                };
            }

            Category.Name = request.Name ?? Category.Name;
            Category.Description = request.Description ?? Category.Description;
            Category.Slug = request.Slug ?? Category.Slug;

            _CategoryWriteRepository.Update(Category);

            await _CategoryWriteRepository.SaveAsync();

            return new UpdateCategoryCommandResponse
            {
                Success = true,
                Message = "Category updated successfully"
            };
        }

        private bool CheckRequestIsEmpty(UpdateCategoryCommandRequest request)
        {
            if (request.Name == null &&
                request.Description == null &&
                request.Slug == null)
            {
                return true;
            }

            return false;
        }
    }
}
