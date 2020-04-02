using ProjIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProjIntegrador.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Instalacao> Instalacao { get; set; }
        public DbSet<Instalador> Instalador { get; set; }
        public DbSet<Interessado> Interessado { get; set; }
        public DbSet<ItensVenda> ItensVenda { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaFuncionario> VendaFuncionario { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(100));

            modelBuilder.Entity<ItensVenda>().HasKey(iv => new { iv.VendaId, iv.ProdutoId });

            modelBuilder.Entity<VendaFuncionario>().HasKey(vf => new { vf.VendaId, vf.VendedorId });

            modelBuilder.Entity<Funcionario>()
                        .HasRequired(c => c.Endereco)
                        .WithMany()
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Instalacao>()
                        .HasRequired(c => c.Venda)
                        .WithMany()
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<VendaFuncionario>()
                        .HasRequired(c => c.Vendedor)
                        .WithMany()
                        .WillCascadeOnDelete(false);
        }

    }
}