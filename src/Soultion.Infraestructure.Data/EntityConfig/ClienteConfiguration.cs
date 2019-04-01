using Microsoft.EntityFrameworkCore;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Infraestructure.Data.EntityConfig
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cliente> builder)
        {
            builder
                .HasKey(c => c.ClienteId);

            builder
                .Property(c => c.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Property(c => c.Sobrenome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();


        }
    } //class
} //namespace
