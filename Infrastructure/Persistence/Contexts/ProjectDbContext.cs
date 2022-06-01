using System;
using Domain.Common;
using Domain.Entities;
using Domain.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Necdet> Necdets { get; set; }
        public DbSet<User> Users { get; set; }

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
            #endregion
        }
    }
}
