using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CourseGroupUserConfiguration : IEntityTypeConfiguration<CourseGroupUser>
    {
        public void Configure(EntityTypeBuilder<CourseGroupUser> builder)
        {
            builder.ToTable("CourseGroupUser");

            builder.HasKey(x => new { x.UserId, x.CourseGroupId });
        }
    }
}
