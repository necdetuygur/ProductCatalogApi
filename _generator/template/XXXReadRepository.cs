using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Repositories.$TABLERepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.$TABLERepository
{
    public class $TABLEReadRepository : ReadRepository<$TABLE>, I$TABLEReadRepository
    {
        public $TABLEReadRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
