using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("client");

            builder.HasIndex(e => e.PersonId, "PersonId");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasOne(d => d.Person).WithMany(p => p.Clients)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("client_ibfk_1");
        }
    }
}