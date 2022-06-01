using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Repositories.ColorRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.ColorRepository
{
    public class ColorReadRepository : ReadRepository<Color>, IColorReadRepository
    {
        public ColorReadRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
