using Application.Repositories.ColorRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.ColorRepository
{
    public class ColorWriteRepository : WriteRepository<Color>, IColorWriteRepository
    {
        public ColorWriteRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
