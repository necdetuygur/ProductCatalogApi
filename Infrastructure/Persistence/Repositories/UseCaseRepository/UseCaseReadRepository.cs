using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Repositories.UseCaseRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.UseCaseRepository
{
    public class UseCaseReadRepository : ReadRepository<UseCase>, IUseCaseReadRepository
    {
        public UseCaseReadRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
