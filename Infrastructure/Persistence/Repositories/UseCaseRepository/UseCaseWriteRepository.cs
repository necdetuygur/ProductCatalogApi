using Application.Repositories.UseCaseRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.UseCaseRepository
{
    public class UseCaseWriteRepository : WriteRepository<UseCase>, IUseCaseWriteRepository
    {
        public UseCaseWriteRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
