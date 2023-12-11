using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class ContractConfig : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contract");

            builder.HasIndex(e => e.ClientId, "ClientId");

            builder.HasIndex(e => e.ContractTypeId, "ContractTypeId");

            builder.HasIndex(e => e.EmployeeId, "EmployeeId");

            builder.HasIndex(e => e.StateId, "StateId");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasOne(d => d.Client).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("contract_ibfk_1");

            builder.HasOne(d => d.ContractType).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ContractTypeId)
                .HasConstraintName("contract_ibfk_4");

            builder.HasOne(d => d.Employee).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("contract_ibfk_2");

            builder.HasOne(d => d.State).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("contract_ibfk_3");
        }
    }
}