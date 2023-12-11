using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("rol");
            builder.Property(p => p.Id)
                    .IsRequired();
            builder.Property(p => p.RolName)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
        }
    }
}