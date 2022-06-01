using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Repositories.NecdetRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.NecdetRepository
{
    public class NecdetReadRepository : ReadRepository<Necdet>, INecdetReadRepository
    {
        public NecdetReadRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
