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
        public DbSet<AdvogadoProcesso> AdvogadoProcessos { get; set; }
        public DbSet<ClienteProcesso> ClientesProcessos { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteProcesso>()
                .HasKey(cp => new { cp.ClienteId, cp.ProcessoId });

            modelBuilder.Entity<ClienteProcesso>()
                .HasOne(cp => cp.ClienteOrigem)
                .WithMany(c => c.ClientesProcessos)
                .HasForeignKey(cp => cp.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ClienteProcesso>()
                .HasOne(cp => cp.ProcessoOrigem)
                .WithMany(p => p.ClientesProcessos)
                .HasForeignKey(cp => cp.ProcessoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AdvogadoProcesso>()
                .HasKey(ap => new { ap.AdvogadoId, ap.ProcessoId });

            modelBuilder.Entity<AdvogadoProcesso>()
                .HasOne(ap => ap.AdvogadoOrigem)
                .WithMany(a => a.AdvogadosProcessos)
                .HasForeignKey(ap => ap.AdvogadoId);

            modelBuilder.Entity<AdvogadoProcesso>()
                .HasOne(ap => ap.ProcessoOrigem)
                .WithMany(p => p.AdvogadosProcessos)
                .HasForeignKey(ap => ap.ProcessoId)
                .OnDelete(DeleteBehavior.Cascade); 

        }


    }

}
