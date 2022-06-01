using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Seed
{
    public class ColorSeed : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasData(
              new Color { Id = Guid.NewGuid(), Name = "White" },
              new Color { Id = Guid.NewGuid(), Name = "Grey" },
              new Color { Id = Guid.NewGuid(), Name = "Brown" },
              new Color { Id = Guid.NewGuid(), Name = "Red" },
              new Color { Id = Guid.NewGuid(), Name = "Dark Blue" },
              new Color { Id = Guid.NewGuid(), Name = "Blue" },
              new Color { Id = Guid.NewGuid(), Name = "Purple" },
              new Color { Id = Guid.NewGuid(), Name = "Pink" },
              new Color { Id = Guid.NewGuid(), Name = "Yellow" },
              new Color { Id = Guid.NewGuid(), Name = "Black" },
              new Color { Id = Guid.NewGuid(), Name = "Orange" },
              new Color { Id = Guid.NewGuid(), Name = "Green" }
          );
        }
    }
}
