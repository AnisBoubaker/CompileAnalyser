namespace Data.Configurations
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ErrorCodeConfiguration : IEntityTypeConfiguration<ErrorCode>
    {
        public void Configure(EntityTypeBuilder<ErrorCode> builder)
        {
            builder.ToTable("ErrorCode");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}