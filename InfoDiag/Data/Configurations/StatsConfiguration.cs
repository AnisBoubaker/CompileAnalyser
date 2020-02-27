namespace Data.Configurations
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StatsConfiguration : IEntityTypeConfiguration<Stats>
    {
        public void Configure(EntityTypeBuilder<Stats> builder)
        {
            builder.ToTable("Stats");

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Lines).WithOne(l => l.Stats);

            builder.HasOne(x => x.Compilation);
        }
    }
}
