using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class PersonContactConfig : IEntityTypeConfiguration<Personcontact>
    {
        public void Configure(EntityTypeBuilder<Personcontact> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("personcontact");

            builder.HasIndex(e => e.ContactTypeId, "ContactTypeId");

            builder.HasIndex(e => e.PersonId, "PersonId");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasOne(d => d.ContactType).WithMany(p => p.Personcontacts)
                .HasForeignKey(d => d.ContactTypeId)
                .HasConstraintName("personcontact_ibfk_2");

            builder.HasOne(d => d.Person).WithMany(p => p.Personcontacts)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("personcontact_ibfk_1");
        }
    }
}