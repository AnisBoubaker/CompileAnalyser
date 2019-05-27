namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Data.Configurations;
    using Entity;
    using Microsoft.EntityFrameworkCore;

    public class InfoDiagContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Compilation> Compilations { get; set; }

        public DbSet<CompilationError> CompilationErrors { get; set; }

        public DbSet<CompilationErrorLine> CompilationErrorLines { get; set; }

        public DbSet<ErrorCode> ErrorCodes { get; set; }

        public InfoDiagContext(DbContextOptions<InfoDiagContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new CompilationConfiguration());
            modelBuilder.ApplyConfiguration(new CompilationErrorConfiguration());
            modelBuilder.ApplyConfiguration(new CompilationErrorLineConfiguration());
            modelBuilder.ApplyConfiguration(new ErrorCodeConfiguration());
        }
    }
}
