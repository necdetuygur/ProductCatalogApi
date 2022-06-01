using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Seed
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = Guid.NewGuid(), Name = "Electronic", Description = "Electronic", Slug = "electronic" },
                new Category { Id = Guid.NewGuid(), Name = "Shoes", Description = "Shoes", Slug = "shoes" },
                new Category { Id = Guid.NewGuid(), Name = "Cosmetic", Description = "Cosmetic", Slug = "cosmetic" },
                new Category { Id = Guid.NewGuid(), Name = "Dress", Description = "Dress", Slug = "dress" },
                new Category { Id = Guid.NewGuid(), Name = "Accessories", Description = "Accessories", Slug = "accessories" }
            );
        }
    }
}
