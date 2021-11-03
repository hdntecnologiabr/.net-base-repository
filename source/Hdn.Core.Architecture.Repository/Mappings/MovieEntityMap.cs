using Hdn.Core.Architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Hdn.Core.Architecture.Repository.Mappings
{
    public class MovieEntityMap : IEntityTypeConfiguration<MovieEntity>
    {
        public void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder.ToTable("movie");
            
            builder.Property(m => m.Description)
                   .HasMaxLength(255);
        }
    }
}
