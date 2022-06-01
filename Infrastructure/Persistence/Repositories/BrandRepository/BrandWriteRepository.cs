using Application.Repositories.BrandRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.BrandRepository
{
    public class BrandWriteRepository : WriteRepository<Brand>, IBrandWriteRepository
    {
        public BrandWriteRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
