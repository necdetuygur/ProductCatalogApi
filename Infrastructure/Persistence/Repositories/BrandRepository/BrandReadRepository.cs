using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Repositories.BrandRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.BrandRepository
{
    public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRepository
    {
        public BrandReadRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
