using Application.Repositories.NecdetRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.NecdetRepository
{
    public class NecdetWriteRepository : WriteRepository<Necdet>, INecdetWriteRepository
    {
        public NecdetWriteRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
