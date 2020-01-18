using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class StatLineConfiguration : IEntityTypeConfiguration<StatLine>
    {
        public void Configure(EntityTypeBuilder<StatLine> builder)
        {
            builder.ToTable("StatLine");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Stats).WithMany(s => s.Lines);
        }
    }
}
