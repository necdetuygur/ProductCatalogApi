using Application.Repositories.$TABLERepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.$TABLERepository
{
    public class $TABLEWriteRepository : WriteRepository<$TABLE>, I$TABLEWriteRepository
    {
        public $TABLEWriteRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
