﻿using Domain.Common;
using Domain.Entities;
using Domain.Configuration;
using Microsoft.EntityFrameworkCore;
using Persistence.Seed;

namespace Persistence.Contexts
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Necdet> Necdets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UseCase> UseCases { get; set; }
        public DbSet<Product> Products { get; set; }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow,
                    EntityState.Deleted => data.Entity.DeleteDate = DateTime.UtcNow,
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Project
            modelBuilder.ApplyConfiguration(new NecdetConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new BrandSeed());
            modelBuilder.ApplyConfiguration(new ColorConfiguration());
            modelBuilder.ApplyConfiguration(new ColorSeed());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategorySeed());
            modelBuilder.ApplyConfiguration(new UseCaseConfiguration());
            modelBuilder.ApplyConfiguration(new UseCaseSeed());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            #endregion
        }
    }
}
