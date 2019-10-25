using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CourseGroupClientConfiguration : IEntityTypeConfiguration<CourseGroupClient>
    {
        public void Configure(EntityTypeBuilder<CourseGroupClient> builder)
        {
            builder.ToTable("CourseGroupClient");

            builder.HasKey(x => new { x.ClientId, x.CourseGroupId });
        }
    }
}
