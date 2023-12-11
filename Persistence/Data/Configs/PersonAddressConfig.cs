using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class PersonAddressConfig : IEntityTypeConfiguration<Personaddress>
    {
        public void Configure(EntityTypeBuilder<Personaddress> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("personaddress");

            builder.HasIndex(e => e.AddressTypeId, "AddressTypeId");

            builder.HasIndex(e => e.PersonId, "PersonId");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Address).HasMaxLength(255);

            builder.HasOne(d => d.AddressType).WithMany(p => p.Personaddresses)
                .HasForeignKey(d => d.AddressTypeId)
                .HasConstraintName("personaddress_ibfk_2");

            builder.HasOne(d => d.Person).WithMany(p => p.Personaddresses)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("personaddress_ibfk_1");
        }
    }
}