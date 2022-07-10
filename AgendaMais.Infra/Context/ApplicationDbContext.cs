using AgendaMais.Domain.Entities;
using AgendaMais.Infra.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace AgendaMais.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Consulta>? Consultas { get; set; }
        public DbSet<Profissional>? Profissional { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Server =.\\SQLEXPRESS; Database = AgendaMais; Trusted_Connection = True; TrustServerCertificate = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ConsultaConfiguration());
            modelBuilder.ApplyConfiguration(new ProfissionalConfiguration());
        }
    }
}
