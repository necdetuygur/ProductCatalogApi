using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.NecdetRepository;
using Application.Repositories.NecdetRepository;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ProjectDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));

            // Necdet
            services.AddScoped<INecdetReadRepository, NecdetReadRepository>();
            services.AddScoped<INecdetWriteRepository, NecdetWriteRepository>();
        }
    }
}
