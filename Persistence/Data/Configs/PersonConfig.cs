using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("person");

            builder.HasIndex(e => e.CityId, "CityId");

            builder.HasIndex(e => e.PersonCategoryId, "PersonCategoryId");

            builder.HasIndex(e => e.PersonId, "PersonId").IsUnique();

            builder.HasIndex(e => e.PersonTypeId, "PersonTypeId");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Name).HasMaxLength(255);

            builder.HasOne(d => d.City).WithMany(p => p.People)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("person_ibfk_3");

            builder.HasOne(d => d.PersonCategory).WithMany(p => p.People)
                .HasForeignKey(d => d.PersonCategoryId)
                .HasConstraintName("person_ibfk_2");

            builder.HasOne(d => d.PersonType).WithMany(p => p.People)
                .HasForeignKey(d => d.PersonTypeId)
                .HasConstraintName("person_ibfk_1");
        }
    }
}