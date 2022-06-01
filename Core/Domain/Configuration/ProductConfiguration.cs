﻿using Microsoft.EntityFrameworkCore;
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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Price).IsRequired();
            entity.Property(e => e.Picture).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.CategoryId).IsRequired();
            entity.Property(e => e.BrandId).IsRequired();
            entity.Property(e => e.ColorId).IsRequired();
            entity.Property(e => e.UseCaseId).IsRequired();
            entity.Property(e => e.IsOfferable).IsRequired();
            // entity.Property(e => e.IsSold).IsRequired();
        }
    }
}
