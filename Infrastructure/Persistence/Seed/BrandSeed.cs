using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Seed
{
    public class BrandSeed : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand { Id = Guid.NewGuid(), Name = "Apple" },
                new Brand { Id = Guid.NewGuid(), Name = "Samsung" },
                new Brand { Id = Guid.NewGuid(), Name = "Nike" },
                new Brand { Id = Guid.NewGuid(), Name = "Adidas" },
                new Brand { Id = Guid.NewGuid(), Name = "Converse" },
                new Brand { Id = Guid.NewGuid(), Name = "MAC" },
                new Brand { Id = Guid.NewGuid(), Name = "Maybelline" },
                new Brand { Id = Guid.NewGuid(), Name = "KIKO" },
                new Brand { Id = Guid.NewGuid(), Name = "ZARA" },
                new Brand { Id = Guid.NewGuid(), Name = "LCWaikiki" },
                new Brand { Id = Guid.NewGuid(), Name = "Armani" },
                new Brand { Id = Guid.NewGuid(), Name = "Prada" }
            );
        }
    }
}
