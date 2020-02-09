namespace Data.Configurations
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CourseGroupUserConfiguration : IEntityTypeConfiguration<CourseGroupUser>
    {
        public void Configure(EntityTypeBuilder<CourseGroupUser> builder)
        {
            builder.ToTable("CourseGroupUser");

            builder.HasKey(x => new { x.UserId, x.CourseGroupId });
        }
    }
}
