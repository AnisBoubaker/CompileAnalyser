namespace Data.Configurations
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TermConfiguration : IEntityTypeConfiguration<Term>
    {
        public void Configure(EntityTypeBuilder<Term> builder)
        {
            builder.ToTable("Term");

            builder.HasKey(x => x.Id);
        }
    }
}
