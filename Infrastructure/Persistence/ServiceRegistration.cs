using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.NecdetRepository;
using Application.Repositories.NecdetRepository;
using Application.Repositories.UserRepository;
using Persistence.Repositories.UserRepository;
using Application.Repositories.BrandRepository;
using Persistence.Repositories.BrandRepository;
using Application.Repositories.ColorRepository;
using Persistence.Repositories.ColorRepository;
using Application.Repositories.CategoryRepository;
using Persistence.Repositories.CategoryRepository;
using Application.Repositories.UseCaseRepository;
using Persistence.Repositories.UseCaseRepository;

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

            // User
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            // Brand
            services.AddScoped<IBrandReadRepository, BrandReadRepository>();
            services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();

            // Color
            services.AddScoped<IColorReadRepository, ColorReadRepository>();
            services.AddScoped<IColorWriteRepository, ColorWriteRepository>();

            // Category
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            // UseCase
            services.AddScoped<IUseCaseReadRepository, UseCaseReadRepository>();
            services.AddScoped<IUseCaseWriteRepository, UseCaseWriteRepository>();
        }
    }
}
