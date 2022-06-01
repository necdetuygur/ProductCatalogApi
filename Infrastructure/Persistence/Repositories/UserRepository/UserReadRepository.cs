using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Repositories.UserRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.UserRepository
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
