using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class ShiftConfig : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("shifts");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.EndTime).HasColumnType("time");
            builder.Property(e => e.Name).HasMaxLength(255);
            builder.Property(e => e.StartTime).HasColumnType("time");
        }
    }
}