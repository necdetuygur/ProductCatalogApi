using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Configuration
{
    public class NecdetConfiguration : IEntityTypeConfiguration<Necdet>
    {
        public void Configure(EntityTypeBuilder<Necdet> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Col1).IsRequired();
            entity.Property(e => e.Col2).IsRequired();
            entity.Property(e => e.Col3).IsRequired();
        }
    }
}
