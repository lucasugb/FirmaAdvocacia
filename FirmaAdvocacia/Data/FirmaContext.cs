using FirmaAdvocacia.Models;
using Microsoft.EntityFrameworkCore;

namespace FirmaAdvocacia.Data
{
    public class FirmaContext : DbContext
    {
        public FirmaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Advogado> Advogados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Processo> Processos { get; set; }
        public DbSet<ClienteProcesso> ClientesProcessos { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteProcesso>()
                .HasKey(cp => new { cp.ClienteId, cp.ProcessoId });

            modelBuilder.Entity<ClienteProcesso>()
                .HasOne(cp => cp.ClienteOrigem)
                .WithMany(c => c.ClientesProcessos)
                .HasForeignKey(cp => cp.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClienteProcesso>()
                .HasOne(cp => cp.ProcessoOrigem)
                .WithMany(p => p.ClientesProcessos)
                .HasForeignKey(cp => cp.ProcessoId)
                .OnDelete(DeleteBehavior.Restrict);

            foreach (var relationship in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }


    }

}
