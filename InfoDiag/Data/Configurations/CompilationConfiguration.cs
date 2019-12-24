using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    internal class CompilationConfiguration : IEntityTypeConfiguration<Compilation>
    {
        public void Configure(EntityTypeBuilder<Compilation> builder)
        {
            builder.ToTable("Compilation");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
