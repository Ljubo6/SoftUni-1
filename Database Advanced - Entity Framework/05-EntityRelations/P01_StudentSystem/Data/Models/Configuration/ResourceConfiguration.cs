using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data.Models.Configuration
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(r => r.ResourceId);

            builder.Property(r => r.Name).HasMaxLength(50).IsUnicode().IsRequired();

            builder.Property(r => r.Url).IsRequired();

            builder.Property(r => r.ResourceType).IsRequired();
        }
    }
}
