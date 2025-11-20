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

    }

}
