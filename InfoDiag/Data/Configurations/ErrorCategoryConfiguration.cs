using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ErrorCategoryConfiguration : IEntityTypeConfiguration<ErrorCategory>
    {
        public void Configure(EntityTypeBuilder<ErrorCategory> builder)
        {
            builder.ToTable("ErrorCategory");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x => x.RelatedErrors)
                .WithOne(re => re.ErrorCategory)
                .HasForeignKey(re => re.ErrorCategoryId);
        }
    }
}
