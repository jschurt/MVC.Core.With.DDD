using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Solution.Domain.Entities;
using Solution.Infraestructure.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution.Infraestructure.Data.Context
{
    public class SolutionContext : DbContext
    {

        public SolutionContext(DbContextOptions options) : base(options)
        { } //constructor

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // equivalent of modelBuilder.Conventions.AddFromAssembly(Assembly.GetExecutingAssembly());
            // look at this answer: https://stackoverflow.com/a/43075152/3419825

            // for the other conventions, we do a metadata model loop
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                entityType.Relational().TableName = entityType.DisplayName();

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            } //foreach

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

            base.OnModelCreating(modelBuilder);

        } //OnModelCreating


        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.GetType().GetProperty("DataCadastro") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }

            } //foreach

            return base.SaveChanges();

        } //SaveChanges

    } //class
} //namespace
