using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Seed
{
    public class UseCaseSeed : IEntityTypeConfiguration<UseCase>
    {
        public void Configure(EntityTypeBuilder<UseCase> builder)
        {
            builder.HasData(
                new UseCase { Id = Guid.NewGuid(), Name = "New" },
                new UseCase { Id = Guid.NewGuid(), Name = "New & Labeled" },
                new UseCase { Id = Guid.NewGuid(), Name = "Barely Used" }
            );
        }
    }
}
