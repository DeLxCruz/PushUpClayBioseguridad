using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class AddressTypeConfig : IEntityTypeConfiguration<Addresstype>
    {
        public void Configure(EntityTypeBuilder<Addresstype> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("addresstype");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Description).HasMaxLength(255);
        }
    }
}