using Data.Configurations;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class InfoDiagContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Compilation> Compilations { get; set; }

        public DbSet<CompilationError> CompilationErrors { get; set; }

        public DbSet<CompilationErrorLine> CompilationErrorLines { get; set; }

        public InfoDiagContext(DbContextOptions<InfoDiagContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new CompilationConfiguration());
            modelBuilder.ApplyConfiguration(new CompilationErrorConfiguration());
            modelBuilder.ApplyConfiguration(new CompilationErrorLineConfiguration());
        }
    }
}
