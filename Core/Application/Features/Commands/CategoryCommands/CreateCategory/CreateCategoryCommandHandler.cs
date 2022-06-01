using Application.Repositories.CategoryRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _CategoryWriteRepository;
        private readonly ICategoryReadRepository _CategoryReadRepository;

        public CreateCategoryCommandHandler(ICategoryWriteRepository CategoryWriteRepository, ICategoryReadRepository CategoryReadRepository)
        {
            _CategoryWriteRepository = CategoryWriteRepository;
            _CategoryReadRepository = CategoryReadRepository;
        }
        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {

            var id = Guid.NewGuid();
            Category Category = new Category
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
                Slug = request.Slug
            };

            var result = await _CategoryWriteRepository.AddAsync(Category);

            await _CategoryWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateCategoryCommandResponse { Success = result, Message = result ? "Category created successfully" : "Category creation failed" };
        }
    }
}
