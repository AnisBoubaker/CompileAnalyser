namespace Data.Configurations
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CodingLanguageConfiguration : IEntityTypeConfiguration<CodingLanguage>
    {
        public void Configure(EntityTypeBuilder<CodingLanguage> builder)
        {
            builder.ToTable("CodingLanguage");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x => x.ErrorCodes).WithOne(x => x.CodingLanguage);
            builder.HasMany(x => x.Courses).WithOne(x => x.CodingLanguage);
        }
    }
}
