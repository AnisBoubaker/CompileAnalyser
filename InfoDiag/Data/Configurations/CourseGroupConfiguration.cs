namespace Data.Configurations
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CourseGroupConfiguration : IEntityTypeConfiguration<CourseGroup>
    {
        public void Configure(EntityTypeBuilder<CourseGroup> builder)
        {
            builder.ToTable("CourseGroup");

            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.CourseGroupClients);
            builder.Ignore(x => x.Clients);
            builder.HasMany(x => x.CourseGroupUsers);
            builder.Ignore(x => x.Users);
        }
    }
}
