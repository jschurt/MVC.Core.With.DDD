using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Infraestructure.Data.EntityConfig
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder
                .HasKey(p => p.ProdutoId);

            builder
                .Property(p => p.Nome)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder
                .Property(p => p.Valor)
                .IsRequired();

            builder
                .HasOne(p => p.Cliente)
                    .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.ClienteId)
                .HasPrincipalKey(c => c.ClienteId);

        } //Configure

        

    } //class
} //namespace
