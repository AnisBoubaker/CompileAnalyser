namespace Data
{
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

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseGroup> CourseGroups { get; set; }

        public DbSet<Institution> Institutions { get; set; }

        public DbSet<Term> Terms { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CodingLanguage> CodingLanguages { get; set; }

        public DbSet<Stats> Stats { get; set; }

        public DbSet<StatLine> StatLines { get; set; }

        public DbSet<ErrorCategory> ErrorCategories { get; set; }

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
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseGroupConfiguration());
            modelBuilder.ApplyConfiguration(new CourseGroupClientConfiguration());
            modelBuilder.ApplyConfiguration(new CourseGroupUserConfiguration());
            modelBuilder.ApplyConfiguration(new InstitutionConfiguration());
            modelBuilder.ApplyConfiguration(new TermConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CodingLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new StatsConfiguration());
            modelBuilder.ApplyConfiguration(new StatLineConfiguration());
            modelBuilder.ApplyConfiguration(new ErrorCategoryConfiguration());
        }
    }
}
